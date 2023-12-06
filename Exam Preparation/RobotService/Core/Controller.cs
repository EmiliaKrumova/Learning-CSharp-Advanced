using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Repositories.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IRobot> robots;
        private readonly IRepository<ISupplement> supplements;
        //ctor
        public Controller()
        {
            this.robots = new RobotRepository();
            supplements = new SupplementRepository();
        }
        public string CreateRobot(string model, string typeName)
        {
            if(typeName!= nameof(DomesticAssistant) && typeName != nameof(IndustrialAssistant))
            {
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }

            IRobot robot = null;
            if(typeName== nameof(DomesticAssistant))
            {
                robot = new DomesticAssistant(model);
            }
            else
            {
                robot = new IndustrialAssistant(model);
            }
            robots.AddNew(robot);
            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName,model);
        }

        public string CreateSupplement(string typeName)
        {
           if(typeName != nameof(LaserRadar)&& typeName != nameof(SpecializedArm))
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }
           ISupplement supplement = null;
            if(typeName== nameof(SpecializedArm))
            {
                supplement = new SpecializedArm();

            }
            else
            {
                supplement = new LaserRadar();
            }
            supplements.AddNew(supplement);
            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            var robotsWithIF = robots.Models().Where(r => r.InterfaceStandards.Any(standart => standart == intefaceStandard));
            if(robotsWithIF.Count() == 0)
            {
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }
            var orderedByBattery = robotsWithIF.OrderByDescending(r => r.BatteryLevel);
            int sum = 0;
            foreach(var robot in orderedByBattery)
            {
                sum += robot.BatteryLevel;
            }
            if (sum < totalPowerNeeded)
            {
                int neededPower = totalPowerNeeded - sum;
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, neededPower);
            }
            else
            {
                int countOfWorkedRobots = 0;
                foreach(var robot in orderedByBattery)
                {
                    countOfWorkedRobots++;
                    if (robot.BatteryLevel >= totalPowerNeeded)
                    {
                                              
                        robot.ExecuteService(totalPowerNeeded);
                        break;
                    }
                    else
                    {
                        
                        totalPowerNeeded -= robot.BatteryLevel;
                        robot.ExecuteService(robot.BatteryLevel);
                    }
                }
                return string.Format(OutputMessages.PerformedSuccessfully, serviceName, countOfWorkedRobots);
            }
            
        }

        public string Report()
        {
            var orderInRobots = robots.Models().OrderByDescending(r => r.BatteryLevel).ThenBy(r => r.BatteryCapacity);
            StringBuilder stringBuilder = new StringBuilder();
            foreach(var robot in orderInRobots)
            {
                stringBuilder.AppendLine(robot.ToString());
            }
            return stringBuilder.ToString().Trim();
        }

        public string RobotRecovery(string model, int minutes)
        {
            var robotsToFeed = robots.Models().Where(r => r.Model == model && r.BatteryLevel * 2 < r.BatteryCapacity);
            int countOfFeededRobots = 0;
            foreach(var robot in robotsToFeed)
            {
                robot.Eating(minutes);
                countOfFeededRobots++;
            }
            return string.Format(OutputMessages.RobotsFed, countOfFeededRobots);
        }
       
        public string UpgradeRobot(string model, string supplementTypeName)
        {
            int supplementInterfaceValue = supplements.Models().First(s => s.GetType().Name == supplementTypeName).InterfaceStandard;
            ISupplement supplement = supplements.Models().First(s => s.GetType().Name == supplementTypeName);
            //намирам първия суплемент , от този тип и взимам стойността на неговия Интерфейс 
            var models = robots.Models().Where(r => r.Model == model);
            //от всички роботи в репозиторито, взимам тези които отговарят на модела
            var robotsToUpgrade = models.Where(r => r.InterfaceStandards.All(s => s != supplementInterfaceValue));
            // от роботите от този модел, търся такива, които НЯМАТ!!! този Интерфейс
            if(robotsToUpgrade.Count()== 0 )
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }
            else
            {
                var robotToUpgrade = robotsToUpgrade.First();
                robotToUpgrade.InstallSupplement(supplement);
                supplements.RemoveByName(supplementTypeName);
                return string.Format(OutputMessages.UpgradeSuccessful, model,supplementTypeName);
            }

        }
    }
}

using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private readonly List<IRobot> robots;
        //ctor
        public RobotRepository()
        {
            robots = new List<IRobot>();
        }
        public void AddNew(IRobot model)
        {
            robots.Add(model);
        }

        public IRobot FindByStandard(int interfaceStandard)
        {
            var robot = robots.FirstOrDefault(r=>r.InterfaceStandards.Contains(interfaceStandard));
            return robot;
        }

        public IReadOnlyCollection<IRobot> Models() =>this.robots.AsReadOnly();
        

        public bool RemoveByName(string typeName)
        {
            var robotToRemove = robots.FirstOrDefault(r => r.Model == typeName);
            if (robotToRemove != null)
            {
                robots.Remove(robotToRemove);
                return true;
            }
            return false;
        }
    }
}

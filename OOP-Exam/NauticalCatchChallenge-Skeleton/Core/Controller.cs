using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        private IRepository<IDiver> divers;
        private IRepository<IFish> fishes;

        public Controller()
        {
            divers = new DiverRepository();
            fishes = new FishRepository();
        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            IDiver diver = divers.GetModel(diverName);
            if (diver == null)
            {
                return $"{divers.GetType().Name} has no {diverName} registered for the competition.";
            }
            IFish fish = fishes.GetModel(fishName);
            if(fish == null)
            {
                return $"{fishName} is not allowed to be caught in this competition.";
            }
            if(diver.HasHealthIssues)
            {
                return $"{diverName} will not be allowed to dive, due to health issues.";
            }
            if (diver.OxygenLevel < fish.TimeToCatch)
            {
                diver.Miss(fish.TimeToCatch);
                if (diver.OxygenLevel <= 0)
                {
                    diver.UpdateHealthStatus();
                }
                return $"{diverName} missed a good {fishName}.";
            }
            else if(diver.OxygenLevel==fish.TimeToCatch) 
            {
                if (isLucky)
                {
                    diver.Hit(fish);
                    if (diver.OxygenLevel <= 0)
                    {
                        diver.UpdateHealthStatus();
                    }
                    return $"{diver.Name} hits a {fish.Points}pt. {fish.Name}.";
                }
                else
                {
                    diver.Miss(fish.TimeToCatch);
                    if (diver.OxygenLevel <= 0)
                    {
                        diver.UpdateHealthStatus();
                    }
                    return $"{diverName} missed a good {fishName}.";


                }
            }
            else
            {
                diver.Hit(fish);
                if (diver.OxygenLevel <= 0)
                {
                    diver.UpdateHealthStatus();
                }
                return $"{diver.Name} hits a {fish.Points}pt. {fish.Name}.";
            }
        }

        public string CompetitionStatistics()
        {
            var orderedDivers = divers.Models.OrderByDescending(d => d.CompetitionPoints).ThenByDescending(d => d.Catch.Count).ThenBy(d => d.Name).Where(d => d.HasHealthIssues == false);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("**Nautical-Catch-Challenge**");
            foreach(var diver in orderedDivers)
            {
                stringBuilder.AppendLine(diver.ToString());
            }
            return stringBuilder.ToString().Trim();
        }

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            if(diverType !=nameof(FreeDiver)&& diverType != nameof(ScubaDiver))
            {
                return $"{diverType} is not allowed in our competition.";
            }
            if(divers.Models.Any(d=>d.Name==diverName))
            {
                return $"{diverName} is already a participant -> {divers.GetType().Name}.";

            }
            IDiver diver;
            if(diverType== nameof(FreeDiver))
            {
                diver = new FreeDiver(diverName);
            }
            else
            {
                diver = new ScubaDiver(diverName);
            }
            divers.AddModel(diver);
            return $"{diver.Name} is successfully registered for the competition -> {divers.GetType().Name}.";
        }

        public string DiverCatchReport(string diverName)
        {
            IDiver diver = divers.GetModel(diverName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Diver [ Name: {diver.Name}, Oxygen left: {diver.OxygenLevel}, Fish caught: {diver.Catch.Count}, Points earned: {diver.CompetitionPoints} ]");
            sb.AppendLine("Catch Report:");
            foreach(var fish in diver.Catch)
            {
                var currFish = this.fishes.GetModel(fish);
                sb.AppendLine(currFish.ToString());
            }
            return sb.ToString().Trim();
        }

        public string HealthRecovery()
        {
            var diversToRecover = divers.Models.Where(d => d.HasHealthIssues);
            int count = diversToRecover.Count();
            foreach(var diver in diversToRecover)
            {
                diver.UpdateHealthStatus();
                diver.RenewOxy();
            }
            return $"Divers recovered: {count}";
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {

            if (fishType != nameof(DeepSeaFish) && fishType != nameof(PredatoryFish)&& fishType!=nameof(ReefFish))
            {
                return $"{fishType} is forbidden for chasing in our competition.";
            }
            if (fishes.Models.Any(d => d.Name == fishName))
            {
                return $"{fishName} is already allowed -> {fishes.GetType().Name}.";

            }
            IFish fish;

            if (fishType == nameof(DeepSeaFish))
            {
                fish = new DeepSeaFish(fishName, points);
            }
            else if(fishType== nameof(PredatoryFish))
            {
                fish = new PredatoryFish(fishName, points);
            }else
            {
                fish = new ReefFish(fishName, points);
            }
           fishes.AddModel(fish);
            return $"{fish.Name} is allowed for chasing.";
        }
    }
}

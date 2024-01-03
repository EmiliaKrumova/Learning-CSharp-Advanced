using NauticalCatchChallenge.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private string name;
        
        private List<string> catched;
        private double competitionPoints;
        private bool isHealth;
        //ctor
        public Diver(string name, int oxygenLevel)
        {
            this.Name = name;
            this.OxygenLevel = oxygenLevel;
            this.catched = new List<string>();
            this.competitionPoints = 0;
            this.isHealth = false;
            
        }
        public string Name 
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Diver's name cannot be null or empty.");
                }
                name = value;
            }
        }

        public int OxygenLevel { get; protected set; }// proverka dali e pod 0??

        public IReadOnlyCollection<string> Catch => this.catched.AsReadOnly();// ???

        public double CompetitionPoints
        {
            
            get
            {
                return Math.Round(this.competitionPoints, 1);

            }
            private set
            {
                this.competitionPoints = value;
            }
        }

        public bool HasHealthIssues
        {
            get
            {
                return isHealth;
            }
            private set
            {
                
                isHealth = value;
            }
        }

        public void Hit(IFish fish)
        {
            this.OxygenLevel -= fish.TimeToCatch;
            this.catched.Add(fish.Name);
            this.CompetitionPoints += fish.Points;
        }

        public abstract void Miss(int TimeToCatch);//or virtual


        public abstract void RenewOxy();//or virtual
        

        public void UpdateHealthStatus()
        {
            if (this.HasHealthIssues == true)
            {
                this.HasHealthIssues = false;
            }
            else
            {
                this.HasHealthIssues = true;
            }
        }
        public override string ToString()
        {
            return $"Diver [ Name: {this.Name}, Oxygen left: {this.OxygenLevel}, Fish caught: {this.Catch.Count}, Points earned: { this.CompetitionPoints} ]";
        }
    }
}

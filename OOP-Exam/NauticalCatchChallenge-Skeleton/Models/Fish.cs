using NauticalCatchChallenge.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public abstract class Fish : IFish
    {
        private string name;
        private double points;
        //ctor
        protected Fish(string name, double points, int timeToCatch)
        {
            this.Name = name;
            this.Points = points;
            this.TimeToCatch = timeToCatch;
                
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
                    throw new ArgumentException("Fish name should be determined.");
                }
                name = value;
            }
        }

        public double Points {
            get
            {
                return points;
            }
            private set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentException("Points must be a numeric value, between 1 and 10.");
                }
              
                points = Math.Round(value, 1);// dali e taka???
            }
        }

        public int TimeToCatch { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Name} [ Points: {this.Points}, Time to Catch: {this.TimeToCatch} seconds ]";
        }
        
    }
}

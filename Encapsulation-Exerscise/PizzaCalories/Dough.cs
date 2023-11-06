using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Dough
    {
        private const double baseDoughCallPerGram = 2;
        private string flourType;
        private string bakeTehnique;
        private double weight;
        private Dictionary<string, double> floorModifiyersPerGram;
        private Dictionary<string, double> bakingModifiyersPerGram;
        public Dough(string flourType, string bakeTehnique, double weight)
        {
            floorModifiyersPerGram = new Dictionary<string, double> { { "white", 1.5 }, { "wholegrain", 1.0 } };
            bakingModifiyersPerGram = new Dictionary<string, double> { { "crispy", 0.9 }, { "chewy", 1.1 }, { "homemade", 1.0 } };
            this.FlourType = flourType;
            this.BakeTehnique = bakeTehnique;
            this.Weight = weight;
        }


        public string FlourType
        {
            get { return flourType; }
            private set 
            {
                if (!floorModifiyersPerGram.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value.ToLower(); 
            }
        }


        public string BakeTehnique
        {
            get { return bakeTehnique; }
            private set 
            {
                if (!bakingModifiyersPerGram.ContainsKey((value.ToLower())))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakeTehnique = value.ToLower(); 
            }
        }


        public double Weight
        {
            get { return weight; }
            private set 
            { 
                if(value < 1.0 || value> 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value; 
            }
        }
        public double CaloriesPerGram
        {
            get
            {
                double flourModifiyer = floorModifiyersPerGram[FlourType];
                double bakingModifiyer = bakingModifiyersPerGram[BakeTehnique];

                double calories = baseDoughCallPerGram * flourModifiyer * bakingModifiyer * Weight;

                return calories;
            }
            

        }


    }
}

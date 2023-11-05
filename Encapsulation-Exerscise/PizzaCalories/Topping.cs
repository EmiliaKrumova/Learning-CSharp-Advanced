using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Topping
    {
        private const double baseModifiyer = 2.0;
        Dictionary<string, double> topings;
        private string toppingType;
        private double weight;
      
        public Topping(string type, double weight)
        {
            topings = new Dictionary<string, double> { { "Meat", 1.2 }, { "Veggies", 0.8 }, { "Cheese", 1.1 }, { "Sauce", 0.9 } };

            this.ToppingType = type;
            this.Weight = weight;
            
        }


        public string ToppingType
        {
            get { return toppingType; }
            private set 
            {
                if(!topings.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppingType = value.ToLower(); 
            }

           
        }
        

        public double Weight
        {
            get { return weight; }
           private set 
            { 
                if(value< 1|| value > 50)
                {
                    throw new ArgumentException ($"{ToppingType} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }
        private double toppingCalories;

        public double ToppingCalories
        {
            get 
            { 
                double topingModifiyer = topings[toppingType];
                double calories = weight * baseModifiyer * topingModifiyer;
                return calories; 
            }
            
        }



    }
}

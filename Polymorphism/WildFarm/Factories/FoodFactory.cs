using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Factories.Interfaces;
using WildFarm.Models.Food;
using WildFarm.Models.Interfaces;

namespace WildFarm.Factories
{
    public class FoodFactory : IFoodFactory
    {
        public IFood CreateFood(string[] foodTokens)
        {
            string type = foodTokens[0];
            int quantity = int.Parse(foodTokens[1]);
            if (type == "Fruit")
            {
                return new Fruit(quantity);
            }
            else if(type == "Meat")
            {
                return new Meat(quantity);
            }
            else if(type == "Seeds")
            {
                return new Seeds(quantity);
            }else if(type == "Vegetable")
            {
                return new Vegetable(quantity);
            }
            else
            {
                throw new ArgumentException("Invalid Type of food");// ??? това си го измислих
            }
            
        }
    }
}

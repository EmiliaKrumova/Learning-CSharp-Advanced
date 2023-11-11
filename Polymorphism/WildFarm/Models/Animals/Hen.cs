using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double HenFoodMultiplier = 0.35;
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        protected override IReadOnlyCollection<Type> PrefferedFoodTypes => new List<Type>()
        {
            typeof(Fruit),
            typeof(Meat),
            typeof(Seeds),
            typeof(Vegetable)
        };

        protected override double FoodMultiplier => HenFoodMultiplier;

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}

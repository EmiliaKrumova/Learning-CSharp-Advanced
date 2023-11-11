using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private const double OwlFoodMultiplier = 0.25;
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        protected override IReadOnlyCollection<Type> PrefferedFoodTypes => new List<Type>()
        {
            typeof(Meat)
        };

        protected override double FoodMultiplier => OwlFoodMultiplier;

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}

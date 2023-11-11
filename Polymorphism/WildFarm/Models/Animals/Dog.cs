using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        private const double DogFoodMultiplier = 0.40;
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        protected override IReadOnlyCollection<Type> PrefferedFoodTypes => new List<Type>()
        {
            typeof(Meat)
        };

        protected override double FoodMultiplier => DogFoodMultiplier;

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private const double CatFoodMultiplier = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override IReadOnlyCollection<Type> PrefferedFoodTypes => new List<Type>()
        {
            typeof(Vegetable),
            typeof(Meat)
        };

        protected override double FoodMultiplier => CatFoodMultiplier;

        public override string ProduceSound() => "Meow";
       
    }
}

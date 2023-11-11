using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        private const double TigerFoodMultiplier = 1.00;
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override IReadOnlyCollection<Type> PrefferedFoodTypes => new List<Type>()
        {
            typeof(Meat)
        };

        protected override double FoodMultiplier => TigerFoodMultiplier;

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}

using WildFarm.Factories.Interfaces;
using WildFarm.Factories;
using WildFarm.Core;

namespace WildFarm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IAnimalFactory animalFactory = new AnimalFactory();
            IFoodFactory foodFactory = new FoodFactory();
            IEngine engine = new Engine(foodFactory,animalFactory);
            engine.RunProgram();

            
        }
    }
}
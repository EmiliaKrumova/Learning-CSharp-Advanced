using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Factories.Interfaces;
using WildFarm.Models.Interfaces;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly IFoodFactory foodFactory;
        private readonly IAnimalFactory animalFactory;
        private readonly ICollection<IAnimal> animals;

        public Engine(IFoodFactory foodFactory, IAnimalFactory animalFactory)
        {
            this.foodFactory = foodFactory;
            this.animalFactory = animalFactory;
            animals = new List<IAnimal>();
        }

        public void RunProgram()
        {
            string command;
           
            

            while ((command  = Console.ReadLine())!= "End")
            {
                string[] foodTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                IAnimal animal = null;
                try
                {

                    string[] animalTokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    


                    animal = animalFactory.CreateAnimal(animalTokens);
                    IFood food = foodFactory.CreateFood(foodTokens);
                    Console.WriteLine(animal.ProduceSound());
                    animal.Eat(food);


                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                animals.Add(animal);


            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}

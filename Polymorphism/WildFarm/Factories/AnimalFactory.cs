using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Factories.Interfaces;
using WildFarm.Models.Animals;
using WildFarm.Models.Interfaces;

namespace WildFarm.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string[] animalInfo)
        {
            //Birds - "{Type} {Name} {Weight} {WingSize}"
            //Mice and Dogs - "{Type} {Name} {Weight} {LivingRegion}
            //Felines - "{Type} {Name} {Weight} {LivingRegion} {Breed}"

            string type = animalInfo[0];
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);
            string param3 = animalInfo[3];
            switch (type)
            {
                case "Owl":
                    
                    return new Owl(name, weight, double.Parse(param3));
                case "Hen":
                    
                    return new Hen(name, weight,double.Parse( param3));
                case "Mouse":
                    return new Mouse(name, weight, param3);
                case "Dog":
                    return new Dog(name, weight, param3);
                case "Cat":
                    string breed = animalInfo[4];
                    return new Cat(name, weight,param3, breed); ;
                case "Tiger":
                    string TigerBreed = animalInfo[4];
                    return new Tiger(name, weight,param3, TigerBreed);
                default:
                    throw new ArgumentException(" Invalid Animal Type!");// това го няма по условие!!!
                    

            }
        }
    }
}

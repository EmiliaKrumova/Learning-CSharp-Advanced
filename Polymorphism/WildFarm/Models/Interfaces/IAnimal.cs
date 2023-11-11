using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models.Interfaces
{
    public interface IAnimal
    //string Name, double Weight, int FoodEaten
    {
        public string Name { get; }
        public double Weight { get; }
        public int FoodEaten { get; }
        string ProduceSound();
        void Eat(IFood food);
    }
}

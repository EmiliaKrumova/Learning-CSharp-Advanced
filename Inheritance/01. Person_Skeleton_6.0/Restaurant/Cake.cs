using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double defaultCakeGrams = 250;
        private const double defaultCakeCalories = 1000;
        private const decimal CakePrice = 5m;
        public Cake(string name) : base(name, CakePrice, defaultCakeGrams, defaultCakeCalories)
        {
        }
       
    }
}

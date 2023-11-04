using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Frog : Animal
    {
        private const string Sound = "Ribbit";
        public Frog(string name, int age, string gender) : base(name, age, gender)
        {
        }
        public override string ProduceSound() => Sound;
        
    }
}

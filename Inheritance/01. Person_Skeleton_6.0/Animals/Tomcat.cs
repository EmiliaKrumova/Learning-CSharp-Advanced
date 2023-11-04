using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    internal class Tomcat : Cat
    {
        private const string TomGender = "Male";
        private const string Sound = "MEOW";
        public Tomcat(string name, int age) : base(name, age, TomGender)
        {
        }
        public override string ProduceSound() => Sound;
        
    }
}

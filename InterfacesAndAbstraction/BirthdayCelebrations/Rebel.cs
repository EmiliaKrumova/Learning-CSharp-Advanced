using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations
{
    public class Rebel : IBuyer
    {

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            

        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Group { get; set; }

        private int food;

        public int Food
        {
            get { return food; }
            private set 
            {
                food = value; 
            }
        }


        public void BuyFood()
        {
            Food += 5;
            //return this.Food;
        }
    }

    
}


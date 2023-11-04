using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person
    {
        private string name;// field
        private int age;// field
        public string Name// prop
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public virtual int Age// prop with modifiyed setter
        {
            get
            {
                return age;
            }
            set
            {
                if(value>0)// chek if age from console is bigger than 0, and then set the age
                {
                    age = value;
                }
            }
        }
        public Person(string name, int age)// ctor
        {
            this.Name = name;
            this.Age = age;
            
        }
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}

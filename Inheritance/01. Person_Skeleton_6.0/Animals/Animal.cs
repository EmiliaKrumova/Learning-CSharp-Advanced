using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;
        public string Name 
        {
            get 
            { 
                return name;
            }
            set
            {
                if(value == null || value==String.Empty)
                {
                    throw new ArgumentException("Invalid input!");
                }
                name = value;
            }
        }
        public int Age {
            get
            {
                return age;
            }
            set
            {
                if (value <=0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                age = value;
            }
        }
        public string Gender {
            get
            {
                return gender;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                gender = value;
            }
        }
        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
            
        }
        public abstract string ProduceSound();
        public override string ToString()
        {
            return $"{Name} {Age} {Gender}{Environment.NewLine}" 
                + $"{ProduceSound()}";
        }

    }
}

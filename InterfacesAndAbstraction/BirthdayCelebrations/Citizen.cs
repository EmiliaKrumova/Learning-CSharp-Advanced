using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations
{
    public class Citizen : IBirthable, IIdentifiable
    {
        public Citizen(string name, int age, string id, string bday)
        {
            Name = name;
            Age = age;
            ID = id;
            Birthdate = bday;
        }
        public string Birthdate { get; private set; }

        public string ID { get; private set; }
        public int Age { get; private set; }
        public string Name { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations
{
    public class Pet : IBirthable
    {
        public Pet(string name, string bday)
        {
            Name = name;
            Birthdate = bday;
        }
        public string Name { get; set; }
        public string Birthdate { get; private set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonInfo
{
    public class Citizen : IPerson,IIdentifiable,IBirthable
    {
        public Citizen(string name, int age, string id, string birthDay)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthDay;
            
        }
        public string Name { get ; set ; }
        public int Age { get ; set ; }
        public string Id { get ; set; }
        public string Birthdate { get ; set ; }
    }
}

using BirthdayCelebrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public class Robot : IIdentifiable
    {
        public Robot(string model, string id)
        {
            
            Model = model;
            ID = id;
        }
        public string ID { get; private set; }
        
        public string Model { get; private set; }
    }
}

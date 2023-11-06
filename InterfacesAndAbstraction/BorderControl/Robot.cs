using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public class Robot : IIdentifiable
    {
        public Robot(string name, string id)
        {
            Name = name;
            ID = id;
        }
        public string ID { get; private set; }
        public string Name { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitInterfaces
{
    public interface IResident
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public string GetName()
        {
            return $"Mr/Ms/Mrs {Name}";
        }
            
    }
}

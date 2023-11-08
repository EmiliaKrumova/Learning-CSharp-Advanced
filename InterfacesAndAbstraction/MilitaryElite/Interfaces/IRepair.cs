using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Interfaces
{
    public interface IRepair
    {
        public string PartName { get; set; }
        public int HoursWorked { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class SpecializedArm : Supplement
    {
        private const int defaultInterfaceStandard = 10045;
        private const int defaultBatteryUsage = 10000;


        public SpecializedArm() 
            : base(defaultInterfaceStandard, defaultBatteryUsage)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    
    public class FreeDiver : Diver
    {
        private const int maxOxy = 120;
        public FreeDiver(string name) 
            : base(name, maxOxy)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            OxygenLevel -= (int)Math.Round((double) TimeToCatch*0.6, MidpointRounding.AwayFromZero);

        }

        public override void RenewOxy()
        {
            this.OxygenLevel = maxOxy;
        }
    }
}

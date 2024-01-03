using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public class ScubaDiver : Diver
    {
        private const int maxOxy = 540;
        public ScubaDiver(string name)
            : base(name, maxOxy)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            this.OxygenLevel -= (int)Math.Round((double)TimeToCatch*0.3, MidpointRounding.AwayFromZero);
        }

        public override void RenewOxy()
        {
            this.OxygenLevel = maxOxy;
        }
    }
}

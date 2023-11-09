using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public class Paladin : Hero
    {
        private const int PaladinPower = 100;
        public Paladin(string name) 
            : base(name, PaladinPower)
        {
        }

        public override string CastAbility()
        => $"{this.GetType().Name} - {Name} healed for {Power}";
    }
}

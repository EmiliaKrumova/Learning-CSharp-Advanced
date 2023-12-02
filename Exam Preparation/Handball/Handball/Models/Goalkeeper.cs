using Handball.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class Goalkeeper : Player,IPlayer
    {
        public Goalkeeper(string name)
            : base(name,2.5)
        {
            
        }

        public override void DecreaseRating()
        {
            if (base.Rating - 1.25 < 1)
            {
                base.Rating = 1;
            }
            else
            {
                base.Rating -= 1.25;
            }
        }

        public override void IncreaseRating()
        {
            if (base.Rating + 0.75 > 10)
            {
                base.Rating = 10;
            }
            else
            {
                base.Rating += 0.75;
            }
            
        }
    }
}

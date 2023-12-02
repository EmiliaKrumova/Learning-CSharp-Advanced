using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class CenterBack : Player
    {
        public CenterBack(string name) 
            : base(name, 4)
        {
        }

        public override void DecreaseRating()
        {
            if (base.Rating - 1 < 1)
            {
                base.Rating = 1;
            }
            else
            {
                base.Rating -= 1;
            }
        }

        public override void IncreaseRating()
        {
            if (base.Rating + 1 > 10)
            {
                base.Rating = 10;
            }
            else
            {
                base.Rating += 1;
            }
        }
    }
}

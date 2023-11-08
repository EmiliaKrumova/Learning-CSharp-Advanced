using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<IPrivate>();
        }

        public List<IPrivate> Privates { get;set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string baseString =  base.ToString();
            sb.AppendLine(baseString);
            sb.AppendLine("Privates:");
            foreach (IPrivate priv in Privates)
            {
                sb.AppendLine($"  {priv.ToString()}");
            }
            return sb.ToString().Trim();
        }
    }
}

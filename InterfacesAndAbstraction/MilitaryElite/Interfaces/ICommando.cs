using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Interfaces
{
    public interface ICommando:ISpecialisedSoldier
    {
        public List<IMission> Missions { get; set; }
        public void CompleteMission(string codeName);
       
    }
}

using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private List<ISupplement> supplements;
        //ctor
        public SupplementRepository()
        {
            supplements = new List<ISupplement>();
        }
        public void AddNew(ISupplement model)
        {
            supplements.Add(model);
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
            var suplement = supplements.FirstOrDefault(s=>s.InterfaceStandard == interfaceStandard);
            return suplement;
        }

        public IReadOnlyCollection<ISupplement> Models() =>this.supplements.AsReadOnly();
        

        public bool RemoveByName(string typeName)
        {
            var SupplementToRemove = supplements.FirstOrDefault(s=>s.GetType().Name == typeName);
            if(SupplementToRemove != null)
            {
                supplements.Remove(SupplementToRemove);
                return true;
            }
            return false;
        }
    }
}

using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Repositories
{
    public class DiverRepository : IRepository<IDiver>
    {
        private List<IDiver> divers;
        public DiverRepository()
        {
            divers = new List<IDiver>();
        }
        public IReadOnlyCollection<IDiver> Models => this.divers;

        public void AddModel(IDiver model)
        {
            this.divers.Add(model);
        }

        public IDiver GetModel(string name)
        {
            return this.divers.FirstOrDefault(d => d.Name == name);
        }
    }
}

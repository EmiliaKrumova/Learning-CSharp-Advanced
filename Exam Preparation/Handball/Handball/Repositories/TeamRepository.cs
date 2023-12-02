using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private List<ITeam> internalListOfTeams;
        public IReadOnlyCollection<ITeam> Models{get; }

        public TeamRepository()
        {
            internalListOfTeams = new List<ITeam>();
            Models = new ReadOnlyCollection<ITeam>(internalListOfTeams);
        }

        public void AddModel(ITeam model)
        {
           internalListOfTeams.Add(model);
        }

        public bool ExistsModel(string name)
        {
            var team = Models.Where(t => t.Name == name).FirstOrDefault();
            if (team != null)
            {
                
                return true;
            }
            return false;
        }

        public ITeam GetModel(string name)
        {
            ITeam team = Models.Where(t => t.Name == name).FirstOrDefault();
            if (team != null)
            {
                return team;
            }
            return null;
        }

        public bool RemoveModel(string name)
        {
            var teamToRemove = Models.Where(t => t.Name == name).FirstOrDefault();
            if (teamToRemove!=null)
            {
                internalListOfTeams.Remove(teamToRemove);
                return true;
            }
            return false;
        }
    }
}

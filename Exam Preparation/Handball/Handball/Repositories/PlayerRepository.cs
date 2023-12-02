using Handball.Models;
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
    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly List<IPlayer> internalListOfAllPlayers;

        //ctor
        public PlayerRepository()
        {
            Models = new ReadOnlyCollection<IPlayer>(internalListOfAllPlayers);
            
        }
        public IReadOnlyCollection<IPlayer> Models { get; }

        public void AddModel(IPlayer model)
        {
            internalListOfAllPlayers.Add(model);
        }

        public bool ExistsModel(string name)
        {
            var player = Models.Where(predicate => predicate.Name == name).FirstOrDefault();
            if (player != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IPlayer GetModel(string name)
        {
            IPlayer player = Models.Where(predicate => predicate.Name == name).FirstOrDefault();
            if (player != null)
            {
                return player;
            }
            return null;
        }

        public bool RemoveModel(string name)
        {
           var playerToRemove = Models.Where(predicate => predicate.Name == name).FirstOrDefault();
            if (playerToRemove != null)
            {
                internalListOfAllPlayers.Remove(playerToRemove);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

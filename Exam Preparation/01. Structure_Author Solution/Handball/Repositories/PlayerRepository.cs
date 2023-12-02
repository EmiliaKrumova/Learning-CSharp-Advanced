using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handball.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models => this.players.AsReadOnly();

        public void AddModel(IPlayer model)
        {
            this.players.Add(model);
        }

        public bool ExistsModel(string name) => this.players.Any(p => p.Name == name);

        public IPlayer GetModel(string name) => this.players.FirstOrDefault(p => p.Name == name);

        public bool RemoveModel(string name) => this.players.Remove(this.players.FirstOrDefault(p => p.Name == name));
    }
}

using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Core.Contracts
{
    public class Controller : IController
    {
        private IRepository<IPlayer> players;
        private IRepository<ITeam> teams;

        //ctor
        public Controller()
        {
            this.players = new PlayerRepository();
            this.teams = new TeamRepository();
        }
        //TODO
        //NewContract Command


        public string LeagueStandings()
        {
            throw new NotImplementedException();
        }

        public string NewContract(string playerName, string teamName)
        {
            throw new NotImplementedException();
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            throw new NotImplementedException();
        }

        public string NewPlayer(string typeName, string name)
        {
            if(typeName!=nameof(Goalkeeper)||typeName!=nameof(ForwardWing) || typeName != nameof(CenterBack))
            {
                return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }
            if (players.ExistsModel(name))
            {
                string currPlayer = players.GetModel(name).GetType().Name;
                return string.Format(OutputMessages.PlayerIsAlreadyAdded, name, nameof(PlayerRepository), currPlayer);
            }
            IPlayer player = null;
            if (typeName == nameof(Goalkeeper))
            {
                player = new Goalkeeper(name);
            }else if (typeName == nameof(ForwardWing))
            {
                player = new ForwardWing(name);
            }else if(typeName == nameof(CenterBack))
            {
                player = new CenterBack(name);
            }

            players.AddModel(player);
            return string.Format(OutputMessages.PlayerAddedSuccessfully, name);



        }

        public string NewTeam(string name)
        {
            ITeam team = new Team(name);
            if(!this.teams.ExistsModel(name))
            {
                teams.AddModel(team);
                return string.Format(OutputMessages.TeamSuccessfullyAdded,team.Name, typeof(TeamRepository));
            }
            return string.Format(OutputMessages.TeamAlreadyExists,name,typeof(TeamRepository));
        }

        public string PlayerStatistics(string teamName)
        {
            throw new NotImplementedException();
        }
    }
}

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
        


        public string LeagueStandings()
        {
            IEnumerable<ITeam> orderedTeams = teams.Models.OrderByDescending(t=> t.PointsEarned).ThenByDescending(t=>t.OverallRating).ThenBy(t=>t.Name);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"***League Standings***");
            foreach (var team in orderedTeams)
            {
                sb.AppendLine(team.ToString());
            }
            return sb.ToString().Trim();
        }

        public string NewContract(string playerName, string teamName)
        {
            if(!players.ExistsModel(playerName))
            {
                return string.Format(OutputMessages.PlayerNotExisting, playerName,nameof(PlayerRepository));
            }
            if(!teams.ExistsModel(teamName))
            {
                return string.Format(OutputMessages.TeamNotExisting, teamName,nameof(TeamRepository));
            }
            IPlayer player = players.GetModel(playerName);
            ITeam team = teams.GetModel(teamName);
            if (player.Team != null)
            {
                return string.Format(OutputMessages.PlayerAlreadySignedContract, playerName, player.Team);
            }
            player.JoinTeam(teamName);
            team.SignContract(player);
            return string.Format(OutputMessages.SignContract, playerName, teamName);
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam first = this.teams.GetModel(firstTeamName);
            ITeam second = this.teams.GetModel(secondTeamName);
            
            
            if(first.OverallRating!= second.OverallRating)
            {
                ITeam winner;
                ITeam looser;
                if (first.OverallRating > second.OverallRating)
                {
                    winner = first;
                    looser = second;
                }
                else 
                {
                    winner = second;
                    looser = first;
                }
                winner.Win();
                looser.Lose();
                
                return string.Format(OutputMessages.GameHasWinner, winner.Name, looser.Name);
            }
            else
            {
                first.Draw();
                second.Draw();
                return string.Format(OutputMessages.GameIsDraw, first.Name, second.Name);
            }
           
           
        }

        public string NewPlayer(string typeName, string name)
        {
            if(typeName!=nameof(Goalkeeper)&&typeName!=nameof(ForwardWing) && typeName != nameof(CenterBack))
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
                return string.Format(OutputMessages.TeamSuccessfullyAdded,team.Name, nameof(TeamRepository));
            }
            return string.Format(OutputMessages.TeamAlreadyExists,name,nameof(TeamRepository));
        }

        public string PlayerStatistics(string teamName)
        {
            ITeam currteam = teams.GetModel(teamName);
            var playersOfThisTeam = currteam.Players.OrderByDescending(p=> p.Rating).ThenBy(p=> p.Name).ToList();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"***{teamName}***");
            foreach(var p in playersOfThisTeam)
            {
                sb.AppendLine(p.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}

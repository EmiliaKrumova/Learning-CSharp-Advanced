using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{


    public class Team : ITeam
    {
        
        private readonly List<IPlayer> internalListOfPlayers;
        private string name;
        private int pointsEarned;

        public Team(string name)
        {
            Name = name;
            pointsEarned = 0;
            internalListOfPlayers = new List<IPlayer>();
            Players = new ReadOnlyCollection<IPlayer>(internalListOfPlayers);
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.TeamNameNull);
                }
                name = value;
            }
        }

       

        public int PointsEarned
        {
            get { return pointsEarned; }
            private set { pointsEarned = value; }
        }

        private double overallRating;

        public double OverallRating
        {
            get
            {
                if (Players.Count > 0)
                {
                    overallRating = Math.Round(Players.Average(p => p.Rating),2);
                }
                else
                {
                    overallRating = 0;
                }
                return overallRating; }
           //private set
           // {
               
           // }
        }



        public IReadOnlyCollection<IPlayer> Players { get; }

        public void Draw()
        {
            this.PointsEarned += 1;
           // var goalkeeper = Players.Where(p => p.GetType().Name == "Goalkeeper").First();
           // goalkeeper.IncreaseRating();
            this.Players.FirstOrDefault(p => p.GetType().Name == nameof(Goalkeeper)).IncreaseRating();
        }

        public void Lose()
        {
            foreach(var player in internalListOfPlayers)//???
            {
                player.DecreaseRating();
            }
        }

        public void SignContract(IPlayer player)
        {
            internalListOfPlayers.Add(player);
        }

        public void Win()
        {
            PointsEarned += 3;
            foreach (var player in internalListOfPlayers)//???
            {
                player.IncreaseRating();
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Team: {Name} Points: {PointsEarned}");
            sb.AppendLine($"--Overall rating: {OverallRating}");
            sb.Append("--Players: ");
            if (internalListOfPlayers.Count == 0)
            {
                sb.Append("none");
            }
            else
            {
                var namesOfPlayers = internalListOfPlayers.Select(p => p.Name).ToArray();
                  sb.Append(String.Join(", ",namesOfPlayers));
                
            }
            
            return sb.ToString();
        }
    }
}

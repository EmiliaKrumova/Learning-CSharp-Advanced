using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Handball.Models
{
    public abstract class Player : IPlayer
    {
        private string name;
        private string team;
        private double rating;

        protected Player(string name, double rating)
        {
            Name = name;
            Rating = rating;
        }

        public string Name 
        { 
            get => name; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.PlayerNameNull);
                }
                name = value;
            }
        }
        public double Rating { get => rating; protected set => rating = value; }
        public string Team { get => team; private set => team = value; }


        public abstract void DecreaseRating();

        public abstract void IncreaseRating();

        public void JoinTeam(string name)
        {
            this.Team = name;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}: {this.Name}");
            sb.AppendLine($"--Rating: {this.Rating}");

            return sb.ToString().TrimEnd();
        }
    }
}

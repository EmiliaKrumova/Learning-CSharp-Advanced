using System.Xml.Linq;

namespace FootballTeam.Models
{
    public class Team
    {
        private string name;

        public Team(string name)
        {
            Name = name;
            Players = new List<Player>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        public List<Player> Players { get; set; }

        public double Rating => Math.Round(Players.Average(p => p.Skills));

        public void AddPlayer(Player player) 
        {
            Players.Add(player);
        }

        public void RemovePlayer(string player)
        {
            var playerToREmove = Players.FirstOrDefault(p => p.Name == player);
            if (playerToREmove == null)
            {
                Console.WriteLine($"Player {player} is not in {Name} team.");
            }
            else 
            {
                Players.Remove(playerToREmove);
            }
        }
    }
}




namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;       
        private const string EmptyNameExceptionMessage = "A name should not be empty.";
        private const string PlayerNotFoundExceptionMessage = "Player {0} is not in {1} team.";
        public Team(string name)
        {
            players = new List<Player>();
            Name = name;
        }

        public double SkillLevelOfTeam
        {
            get
            {
                if (players.Count == 0)
                {
                    return 0;
                }
                double skinlevel = Math.Round(players.Average(p => p.SkillLevel));
                return skinlevel;
            }

        }


        public List<Player> Players
        {
            get { return players; }
            private set { players = value; }
        }


        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(EmptyNameExceptionMessage);
                }
                name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        public void RemovePlayer(string playerName)
        {
            Player player = players.FirstOrDefault(p => p.Name == playerName);
            if (player == null)
            {
                throw new ArgumentException(string.Format(PlayerNotFoundExceptionMessage, playerName, Name));

            }

            players.Remove(player);
        }


    }
}

namespace FootballTeam.Models
{
    public class Player
    {
        private const string EceptionSkillRange = "should be between 0 and 100.";
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
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

        private int Endurance
        {
            get => endurance;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(Endurance)} {EceptionSkillRange}");
                }
                endurance = value;
            }
        }

        private int Sprint
        {
            get => sprint;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(Sprint)} {EceptionSkillRange}");
                }
                sprint = value;
            }
        }

        private int Dribble
        {
            get => dribble;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(Dribble)} {EceptionSkillRange}");
                }
                dribble = value;
            }
        }

        private int Passing
        {
            get => passing;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(Passing)} {EceptionSkillRange}");
                }
                passing = value;
            }
        }

        private int Shooting
        {
            get => shooting;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(Shooting)} {EceptionSkillRange}");
                }
                shooting = value;
            }
        }

        public double Skills => (Endurance + Sprint + Dribble + Passing + Shooting) * 0.2;
    }
}

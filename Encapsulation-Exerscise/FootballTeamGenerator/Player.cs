using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        private const int minSkill = 0;
        private const int maxSkill = 100;
        private const string OutOfRangeExceptionMessage = "{0} should be between 0 and 100.";
        private const string EmptyNameExceptionMessage = "A name should not be empty.";

        private int skillLevel;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;

        }





        public int Shooting
        {
            get { return shooting; }
            private set
            {
                if (value < minSkill || value > maxSkill)
                {
                    throw new ArgumentException(String.Format(OutOfRangeExceptionMessage, nameof(Shooting)));
                }
                shooting = value;
            }
        }


        public int Passing
        {
            get { return passing; }
            private set
            {
                if (value < minSkill || value > maxSkill)
                {
                    throw new ArgumentException(String.Format(OutOfRangeExceptionMessage, nameof(Passing)));
                }
                passing = value;
            }
        }


        public int Dribble
        {
            get { return dribble; }
            private set
            {
                if (value < minSkill || value > maxSkill)
                {
                    throw new ArgumentException(String.Format(OutOfRangeExceptionMessage, nameof(Dribble)));
                }
                dribble = value;
            }
        }


        public int Sprint
        {
            get { return sprint; }
            private set
            {
                if (value < minSkill || value > maxSkill)
                {
                    throw new ArgumentException(String.Format(OutOfRangeExceptionMessage, nameof(Sprint)));
                }
                sprint = value;
            }
        }


        public int Endurance
        {
            get { return endurance; }
            private set
            {
                if (value < minSkill || value > maxSkill)
                {
                    throw new ArgumentException(String.Format(OutOfRangeExceptionMessage, nameof(Endurance)));
                }
                endurance = value;
            }
        }




        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(EmptyNameExceptionMessage);
                }
                name = value;
            }
        }
        public double SkillLevel
        {
            get
            {
                double skilLevel = (Endurance + Sprint + Dribble + Passing + Shooting) * 0.2;
                return skilLevel;
            }

        }


    }
}

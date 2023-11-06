namespace FootballTeamGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Team> teams = new List<Team>();


            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] tokens = input.Split(";");
                    string command = tokens[0];
                    if (command == "Team")
                    {
                        string teamName = tokens[1];
                        teams.Add(new Team(teamName));

                    }
                    else if (command == "Add")
                    {
                        string teamName = tokens[1];
                        Team team = teams.FirstOrDefault(t => t.Name == teamName);

                        if (team == null)
                        {

                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;


                        }
                        string playerName = tokens[2];
                        int endurance = int.Parse(tokens[3]);
                        int sprint = int.Parse(tokens[4]);
                        int dribble = int.Parse(tokens[5]);
                        int passing = int.Parse(tokens[6]);
                        int shooting = int.Parse(tokens[7]);
                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        team.AddPlayer(player);



                    }
                    else if (command == "Remove")
                    {
                        string teamName = tokens[1];
                        Team team = teams.FirstOrDefault(t => t.Name == teamName);
                        string playerName = tokens[2];
                        if (team != null)
                        {

                            team.RemovePlayer(playerName);

                        }

                    }
                    else if ((command == "Rating"))
                    {
                        string teamName = tokens[1];
                        Team team = teams.FirstOrDefault(t => t.Name == teamName);
                        if (team != null)
                        {
                            Console.WriteLine($"{team.Name} - {team.SkillLevelOfTeam}");
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                            
                        }

                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            

        }
    }
}
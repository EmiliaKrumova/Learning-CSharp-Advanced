using FootballTeam.Models;
namespace FootballTeam
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team>teamCollection = new List<Team>();
            string inputArgs;

            while ((inputArgs = Console.ReadLine()) != "END") 
            {
                string[] cmdArgs = inputArgs.Split(";");

                if (cmdArgs[0] == "Team")
                {
                    var team = teamCollection.FirstOrDefault(t => t.Name == cmdArgs[1]);
                    if (team == null)
                    {
                        try
                        {
                            var newTeam = new Team(cmdArgs[1]);
                            teamCollection.Add(newTeam);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                else if (cmdArgs[0] == "Add")
                {
                    string teamName = cmdArgs[1];
                    string playerName = cmdArgs[2];
                    int endurance = int.Parse(cmdArgs[3]);
                    int sprint = int.Parse(cmdArgs[4]);
                    int dribble = int.Parse(cmdArgs[5]);
                    int passing = int.Parse((cmdArgs[6]));
                    int shooting = int.Parse((cmdArgs[7]));
                    try
                    {
                        var player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        var team = teamCollection.FirstOrDefault(t => t.Name == teamName);

                        if (team == null)
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                        else
                        {
                            team.AddPlayer(player);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                   
                }
                else if (cmdArgs[0] == "Remove")
                {
                    string teamName = cmdArgs[1];
                    string playerToRemove = cmdArgs[2];

                    var team = teamCollection.FirstOrDefault(t => t.Name == teamName);

                    if (team == null)
                    {
                        Console.WriteLine($"Player {playerToRemove} is not in {teamName} team.");
                        //!!!If you receive a command to remove a missing Player, print "Player [Player name] is not in                        [Team name] team."
                    }
                    else
                    {
                        team.RemovePlayer(playerToRemove);
                    }
                }
                else if (cmdArgs[0] == "Rating") 
                {
                    string teamName = cmdArgs[1];
                    var team = teamCollection.FirstOrDefault(t => t.Name == teamName);

                   
                    if (team == null)
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                        continue;
                    }
                    else 
                    {
                        if (team.Players.Count == 0)
                        {
                            Console.WriteLine($"{team.Name} - 0");
                        }
                        else 
                        {
                            Console.WriteLine($"{team.Name} - {team.Rating}");
                        }
                    }
                }
            }
        }
    }
}
namespace BorderControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;
            List<IIdentifiable> townOfCitizensAndRobots = new List<IIdentifiable>();// collection of different data types, with same interface IIdentifiable (we can get only ID)
            ;
            
            while((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];

                if (tokens.Length > 2) 
                { 
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    Citizen citizen = new Citizen(name, age, id);
                    townOfCitizensAndRobots.Add(citizen);

                }
                else
                {
                    string id = tokens[1];
                    Robot robot = new Robot(name,  id);
                    townOfCitizensAndRobots.Add(robot);

                }
            }
            string numberToCompare = Console.ReadLine();


            foreach(var member in townOfCitizensAndRobots)
            {
                if (member.ID.EndsWith(numberToCompare))
                {
                    Console.WriteLine(member.ID);
                }
            }
        }
    }
}
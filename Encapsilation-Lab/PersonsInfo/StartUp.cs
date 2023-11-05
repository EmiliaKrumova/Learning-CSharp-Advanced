namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int countOfPersons = int.Parse(Console.ReadLine());
            //List<Person> people = new List<Person>();
            Team team = new Team("Softuni");



            for (int i = 0; i < countOfPersons; i++)
            {
                string[] personData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string firstName = personData[0];
                string lastName = personData[1];
                int age = int.Parse(personData[2]);
                decimal salary = decimal.Parse(personData[3]);
                //try
                //{
                //    Person person = new Person(firstName, lastName, age, salary);
                //    team.AddPlayer(person);
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}
                Person person = new Person(firstName, lastName, age, salary);
                team.AddPlayer(person);


            }

            //decimal percentage = decimal.Parse(Console.ReadLine());

            // people.ForEach(person => { person.IncreaseSalary(percentage); });
            // people.ForEach(p => Console.WriteLine(p.ToString()));



            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");



            //people.OrderBy(p => p.FirstName)
            //        .ThenBy(p => p.Age)
            //        .ToList()
            //        .ForEach(p => Console.WriteLine(p.ToString()));// this solution is for Problem 1 from Lab
        }
    }
}
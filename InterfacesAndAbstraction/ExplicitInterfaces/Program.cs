namespace ExplicitInterfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            while((command = Console.ReadLine()) != "End")
            {
                string[] info = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                string country = info[1];
                int age = int.Parse(info[2]);
                Citizen citizen = new Citizen(name, country, age);
                IPerson person = citizen;
                IResident resident = citizen;
                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
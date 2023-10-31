namespace _9._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();

            
            string command;
            while((command = Console.ReadLine()) != "Party!")
            {
                string[] tokens = command.Split();
                string action = tokens[0];
                string filter = tokens[1];
                string value = tokens[2];

                if(action == "Remove")
                {
                    people.RemoveAll(GetPredicate(filter, value));

                }else if(action == "Double")
                {
                    List<string> duplicatedPeople = people.FindAll(GetPredicate(filter, value));
                    foreach(string person in duplicatedPeople)
                    {
                        int index = people.IndexOf(person);
                        people.Insert(index, person);
                    }
                }


            }
            if(people.Count > 0)
            {
                Console.WriteLine($"{String.Join(", ", people)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string filter, string value)
        {
            if(filter == "StartsWith")
            {
                return p=>p.StartsWith(value);
            }
            
            else if (filter == "EndsWith")
            {
                return p=>p.EndsWith(value);
            }

            else if(filter == "Length")
            {
                return p => p.Length == int.Parse(value);
            }
            else
            {
                return default;
            }
        }
    }
}
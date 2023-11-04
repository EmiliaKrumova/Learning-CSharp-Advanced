namespace _9._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();
            // входни данни (списък от хора)

            
            string command;
            while((command = Console.ReadLine()) != "Party!")
            {
                string[] tokens = command.Split();
                string action = tokens[0];// Remove/ Double
                string filter = tokens[1];
                string value = tokens[2];


                //Разписваме метод, който в различните случаи да ни връща различен предикат

                if(action == "Remove")// ако действието е премахни
                {
                    people.RemoveAll(GetPredicate(filter, value));// премахни всички в колекцията, които отговарят на този предикат

                }else if(action == "Double")// ако действието е "удвои"
                {
                    List<string> duplicatedPeople = people.FindAll(GetPredicate(filter, value)); 
                    //създаваме нов лист от хора, които трябва да бъдат с удвоени имена
                    // в този лист, слагаме всички хора, които отговарят на предиката, който ни е подаден
                    foreach(string person in duplicatedPeople)
                    {
                        int index = people.IndexOf(person);// вадим индекс от оригиналната колекция за съответния човек
                        people.Insert(index, person);// дублираме името, като го вмъкваме на същия идекс "Петър, Петър, Миша...."
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

        private static Predicate<string> GetPredicate(string filter, string value)// метод, който ще определя с кой предикат ще работим, спрямо подадения филтър и стойност(стринг)
        {
            if(filter == "StartsWith")//ако филтъра е "Започва със..""
            {
                return p=>p.StartsWith(value);// съответното име на човек, да започва с подадената стойност
            }
            
            else if (filter == "EndsWith")
            {
                return p=>p.EndsWith(value);
            }

            else if(filter == "Length")// ако филтъра е по дължината на стринга
            {
                return p => p.Length == int.Parse(value); // връщай предикат (там където името е със съответната подадена дължина)
            }
            else
            {
                return default;// върни дефолтна стойност, която за предиката е "null"
            }
        }
    }
}
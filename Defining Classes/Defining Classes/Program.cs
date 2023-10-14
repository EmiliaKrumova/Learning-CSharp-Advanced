using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            Family family = new Family();
            List<Person> persons = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                int age = int.Parse(info[1]);
                Person person = new Person(name,age);
                family.AddMember(person);
                if (age > 30)
                {
                    persons.Add(person);
                }
                
            }

            foreach (Person person in persons.OrderBy(p=>p.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
           // Person oldest = family.GetOldestMember();
           // Console.WriteLine($"{oldest.Name} {oldest.Age}");
           
            
            //Person person1 = new Person("Peter",20);
            //Person person2 = new Person("George", 18);
            //Person person3 = new Person("Jose", 43);
        }
    }
}
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                int age = int.Parse(info[1]);
                Person person = new Person(name,age);
                family.AddMember(person);
                
            }
            Person oldest = family.GetOldestMember();
            Console.WriteLine($"{oldest.Name} {oldest.Age}");
            
            //Person person1 = new Person("Peter",20);
            //Person person2 = new Person("George", 18);
            //Person person3 = new Person("Jose", 43);
        }
    }
}
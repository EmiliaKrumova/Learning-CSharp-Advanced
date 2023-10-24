using System.Xml.Linq;

namespace _5._Filter_by_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            for (int i = 0; i < count; i++)
            {
                string[] info = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToArray();
                string name = info[0];
                int age =int.Parse(info[1]);
                Person person = new Person(name,age);
                people.Add(person);
            }
            string condition = Console.ReadLine();
            int ageToCompare = int.Parse(Console.ReadLine());

            Func<Person, bool> filter = p => true;// това е дефолтна стойност на фънк -> тоест не сортира по нищо
            if (condition == "older")
            {
                filter = p=>p.Age>= ageToCompare;

            }else if (condition == "younger")
            {
                filter = p=> p.Age< ageToCompare;
            }
            List<Person> filteredPeople = people.Where(filter).ToList();

            string printFormat = Console.ReadLine();

            Func<Person, string> printPeople = p => p.Name + " " + p.Age;
            if(printFormat=="name age")
            {
               printPeople =  p => p.Name + " " + p.Age;
            }else if (printFormat == "age")
            {
                printPeople = p => p.Age.ToString();
            }else if(printFormat == "name")
            {
                printPeople= p => p.Name;
            }


            List<string> output = filteredPeople.Select(printPeople).ToList();


            foreach (string person in output)
            {
                Console.WriteLine(person);

            }
             
        }
        


    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;

        }
    }
}
using System.Xml.Linq;

namespace _5._Filter_by_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();// списък от обекти(хора)
            for (int i = 0; i < count; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim())
                    .ToArray();

                string name = info[0];
                int age =int.Parse(info[1]);
                Person person = new Person(name,age);
                people.Add(person);
            }
            string condition = Console.ReadLine();// условие от потребителя => може да е older/younger


            int ageToCompare = int.Parse(Console.ReadLine());// възраст за сравняване с условието

            Func<Person, bool> filter = p => true;// създаваме една функция, която приема обект(човек) и връща булева
            // това е дефолтна стойност на фънк -> тоест не сортира по нищо
            if (condition == "older")
            {
                filter = p=>p.Age>= ageToCompare;// функцията ще сравнява за по-стар

            }else if (condition == "younger")
            {
                filter = p=> p.Age< ageToCompare;// функцията ще сравнява за по-млад
            }
            List<Person> filteredPeople = people.Where(filter).ToList();// нов списък с вече филтрираните по възраст хора, според подадения филтър

            string printFormat = Console.ReadLine();// как трябва да бъде отпечатано (име; име + години; години)

            Func<Person, string> printPeople = p => p.Name + " " + p.Age;// нова функция за принтиране с дефолтна стойност


            if(printFormat=="name age")
            {
               printPeople =  p => p.Name + " - " + p.Age;
            }
            else if (printFormat == "age")
            {
                printPeople = p => p.Age.ToString();
            }
            else if(printFormat == "name")
            {
                printPeople= p => p.Name;
            }


            List<string> output = filteredPeople
                .Select(printPeople)
                .ToList();// нов списък, вече със подадена функцията за принтиране през него// заради естеството на фукцията printPeople - тя връща стринг


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
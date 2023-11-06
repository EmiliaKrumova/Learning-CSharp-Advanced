using BorderControl;
using System.Reflection.Metadata.Ecma335;

namespace BirthdayCelebrations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IBirthable> creatures = new List<IBirthable>();
            string input;
            while((input = Console.ReadLine()) != "End")
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = info[0];
                if(type == "Citizen")
                {
                    string name = info[1];
                    int age = int.Parse(info[2]);
                    string id = info[3];
                    string bday = info[4];
                    Citizen citizen = new Citizen(name,age,id,bday);
                    creatures.Add(citizen);

                }else if(type == "Pet")
                {
                    string name = info[1];
                    string bday = info[2];
                    Pet pet = new Pet(name,bday);
                    creatures.Add(pet);

                }else if(type == "Robot")
                {
                    string model = info[1];
                    string id = info[2];
                    Robot robot = new Robot(model, id);

                }
            }
            string yearToFind = Console.ReadLine();
            foreach(var creature in creatures)
            {
                if (creature.Birthdate.EndsWith(yearToFind))
                {
                    Console.WriteLine(creature.Birthdate);
                }
            }
        }
    }
}
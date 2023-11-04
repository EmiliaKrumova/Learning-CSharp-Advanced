using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string typeOfAnimal;
            while((typeOfAnimal = Console.ReadLine()) != "Beast!")
            {
                string[] animalData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = animalData[0];
                int age = int.Parse(animalData[1]);
                string gender = string.Empty;
                if(animalData.Length > 2)
                {
                    gender = animalData[2];
                }

                try
                {
                    if (typeOfAnimal == "Dog")
                    {
                        Dog dog = new Dog(name, age, gender);
                        PrintingAnimal(typeOfAnimal, dog);

                    }
                    else if (typeOfAnimal == "Cat")
                    {
                        Cat cat = new Cat(name, age, gender);
                        PrintingAnimal(typeOfAnimal, cat);

                    }
                    else if (typeOfAnimal == "Frog")
                    {
                        Frog frog = new Frog(name, age, gender);
                        PrintingAnimal(typeOfAnimal, frog);

                    }
                    else if (typeOfAnimal == "Kitten")
                    {
                        Kitten kitten = new Kitten(name, age);
                        PrintingAnimal(typeOfAnimal, kitten);


                    }
                    else if ((typeOfAnimal == "Tomcat"))
                    {
                        Tomcat tomcat = new Tomcat(name, age);
                        PrintingAnimal(typeOfAnimal, tomcat);

                    }
                }
                catch(Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }

                

            }
        }
        public static void PrintingAnimal<T>(string typeOfAnimal, T animal) where T : Animal // printing overriden string from Generic Class
        {
            Console.WriteLine(typeOfAnimal);
            Console.WriteLine(animal.ToString());
        }
    }
}

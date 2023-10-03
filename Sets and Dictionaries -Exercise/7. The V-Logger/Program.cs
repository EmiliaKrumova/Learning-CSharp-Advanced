using System.Runtime.CompilerServices;

namespace _7._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // ключ -> името на влогъра, с вложено дикт с два възможни ключа->последвани (с вложен хешсет(списък с имената) / и ключ последователи с отново вложен хешсет с имената

            //Ема
            //-> последователи -> Пешо, Гошо, Иван
            //-> последвани -> Ана, Мария, Величка, Гошо


            Dictionary<string, Dictionary<string, SortedSet<string>>> site = new Dictionary<string, Dictionary<string, SortedSet<string>>>();
            string input;
            string following = "following";// създавам си двата възможни ключа за вложения речник
            string followers = "followers";
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string vloggerName = tokens[0];
                string realCom = tokens[1];
                string popularUser = tokens[2];
                
                if (realCom== "joined")
                {
                    if(!site.ContainsKey(vloggerName))
                    {
                        site[vloggerName] = new Dictionary<string, SortedSet<string>>();
                        site[vloggerName][followers] = new SortedSet<string>();
                        site[vloggerName][following] = new SortedSet<string>();
                    }
                }else if (realCom== "followed"// ако командата е последвай
                    && vloggerName!=popularUser// не може да следва себе си
                    && site.ContainsKey(vloggerName)// и двамата се съдържат в речника
                    && site.ContainsKey(popularUser)
                    && !site[popularUser][followers].Contains(vloggerName))// вече не е последвал същия
                {
                    site[vloggerName][following].Add(popularUser);// с ключ следвани слагаме в хешсета на първия влогър името на известния потребител
                    site[popularUser][followers].Add(vloggerName);// с ключ последователи слагаме името на влогъра в хешсета на по-известния т.е Пешо следва Иван <=> Иван има последовател Пешо
                }

            }
            Console.WriteLine($"The V-Logger has a total of {site.Count} vloggers in its logs.");

            // НАМИРАНЕ НА НАЙ-ПОПУЛЯРНИЯ ПОТРЕБИТЕЛ

            var sortedVlogers  = 
                site.OrderByDescending(x => x.Value[followers].Count())// кой е с най-голям брой последователи
                .ThenBy(x => x.Value[following].Count()) // който следва по-малко други хора
                .ToDictionary(x=>x.Key, v=>v.Value);

            int counter = 1;
            
            foreach(var vlogger in sortedVlogers)
            {
                Console.WriteLine
                    ($"{counter}. {vlogger.Key} : {vlogger.Value[followers].Count()} followers, {vlogger.Value[following].Count()} following");
                 // брояч, името на първия влогър, във вложения речник с ключа "последователи" принтираме броя им, след това с ключ "последвани" принтираме броя на последваните



                if (counter == 1)// ако е най-популярния (т.е е с номер 1 във сортирания речник)
                {
                    //foreach(var people in vlogger.Value[followers].OrderBy(x=>x))// трябва да отпечатаме имената на последователите му по азбучен ред
                    //{
                    //    Console.WriteLine($"*  {people}");
                    //}
                    foreach (var people in vlogger.Value[followers])// трябва да отпечатаме имената на последователите му по азбучен ред
                    {
                        Console.WriteLine($"*  {people}");
                    }
                }
                counter++;
            }
            
            //Идея ако е със SortedSet,вместо с HashSet няма да има нужда да подреждам имената
        }
    }
}
using System.Drawing;

namespace _10._ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            SortedDictionary<string, SortedSet<string>> sides = new SortedDictionary<string, SortedSet<string>>();
           
            while ((command = Console.ReadLine()) != "Lumpawaroo")
            {
                if (command.Contains("|"))
                {
                    string[] tokens = command.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    string side = tokens[0];
                    string hero = tokens[1];
                    if (!sides.ContainsKey(side))
                    {
                        sides[side] = new SortedSet<string>();
                        
                    }
                    sides[side].Add(hero);
                }
                else if (command.Contains("->")) 
                {
                    string[] tokens = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string hero = tokens[0];
                    string sideToMoveAt = tokens[1];
                    foreach (var side in sides)
                    {
                        if (side.Value.Contains(hero))
                        {
                            side.Value.Remove(hero);
                            break;
                        }
                    }

                    if (!sides.ContainsKey(sideToMoveAt))
                    {
                        sides[sideToMoveAt] = new SortedSet<string>();

                    }

                    sides[sideToMoveAt].Add(hero);

                    Console.WriteLine($"{hero} joins the {sideToMoveAt} side!");
                }
            }
            foreach (var side in sides.OrderByDescending(x => x.Value.Count))
            {
                if (side.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                    foreach (var hero in side.Value)
                    {
                        Console.WriteLine($"! {hero}");
                    }
                }

            }
        }
    }
}
using System;

namespace Monster_Extermination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
           
            Queue<int> monsters = new Queue<int>(Console.ReadLine().Split(",").Select(int.Parse));
            Stack<int> soldiers = new Stack<int>(Console.ReadLine().Split(",").Select(int.Parse));
            int countOfKilledMonsters = 0;      
            


            while (monsters.Any() && soldiers.Any())
            {
                int monster = monsters.Peek();
                int soldier = soldiers.Peek();
                if (soldier >= monster)
                {
                    countOfKilledMonsters++;
                    soldier -= monster;
                   
                    if (soldier == 0)
                    {
                        soldiers.Pop();
                        monsters.Dequeue();
                    }
                    else
                    {
                        monsters.Dequeue();
                        if (soldiers.Count == 1)
                        {
                            soldiers.Pop();
                            soldiers.Push(soldier);
                            continue;
                        }
                        else
                        {
                            soldiers.Pop();
                            int temp = soldier;
                            soldiers.Push(temp+soldiers.Pop());
                        }
                    }
                }
                else
                {
                    monster -= soldier;
                    soldiers.Pop();
                    monsters.Dequeue();
                    monsters.Enqueue(monster);
                }

            }
            if (!monsters.Any())
            {
                Console.WriteLine("All monsters have been killed!");

            }
            if (!soldiers.Any())
            {
                Console.WriteLine("The soldier has been defeated.");
            }
            
            Console.WriteLine($"Total monsters killed: {countOfKilledMonsters}");
        }
    }
}
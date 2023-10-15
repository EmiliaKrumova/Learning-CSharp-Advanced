namespace Monsters_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] monstersArmor = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);
            string[] soldierInpact = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);
            Queue<int> monsters = new Queue<int>();
            Stack<int> soldier = new Stack<int>();
            int countOfKilledMonsters = 0;
            for (int i = 0; i < monstersArmor.Length; i++)
            {
                monsters.Enqueue(int.Parse(monstersArmor[i]));
            }
            for (int i = 0; i < soldierInpact.Length; i++)
            {
                soldier.Push(int.Parse(soldierInpact[i]));
            }
            int remainingSoldierPower = 0;


            while (monsters.Count > 0 && soldier.Count > 0)
            {
                int currMonsterPower = monsters.Dequeue();
                int currSoldierPower = soldier.Pop();
                if (remainingSoldierPower > 0)
                {
                    currSoldierPower += remainingSoldierPower;
                    remainingSoldierPower = 0;
                }

                if (currMonsterPower > currSoldierPower)
                {

                    currMonsterPower -= currSoldierPower;
                    monsters.Enqueue(currMonsterPower);
                    remainingSoldierPower = 0;

                }
                else if (currMonsterPower <= currSoldierPower)
                {

                    countOfKilledMonsters++;
                    remainingSoldierPower = currSoldierPower - currMonsterPower;
                }


                if (remainingSoldierPower > 0 && soldier.Count == 0)
                {
                    soldier.Push(remainingSoldierPower);
                }


            }
            
             if (!monsters.Any())
            {
                Console.WriteLine("All monsters have been killed!");

            }
            if (!soldier.Any())
            {
                Console.WriteLine("The soldier has been defeated.");
            }
            Console.WriteLine($"Total monsters killed: {countOfKilledMonsters}");
        }
    }
}
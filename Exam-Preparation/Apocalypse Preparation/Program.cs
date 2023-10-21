using System;

namespace Apocalypse_Preparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> textiles = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            Stack<int> medicaments = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            int patchCount = 0;
            int bandageCount = 0;
            int medKitCount = 0;
            while (textiles.Count > 0 && medicaments.Count>0)
            {
                int currTextile = textiles.Peek();
                int currMedik = medicaments.Pop();
                int sum = currTextile + currMedik;
                if (sum == 30)
                {
                    patchCount++;
                    textiles.Dequeue();
                    //medicaments.Pop();
                }else if (sum == 40)
                {
                    bandageCount++;
                    textiles.Dequeue();
                   // medicaments.Pop();
                }
                else if(sum == 100)
                {
                    medKitCount++;
                    textiles.Dequeue();
                   // medicaments.Pop();
                }
                else if (sum > 100)
                {
                    medKitCount++;
                    textiles.Dequeue() ;
                    int remainingresourses = sum - 100;
                    int next = medicaments.Pop();
                    medicaments.Push(remainingresourses+next);
                }
                else
                {
                    textiles.Dequeue();
                    currMedik += 10;
                    medicaments.Push(currMedik);
                }
            }
            if(textiles.Count == 0 && medicaments.Count==0)
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
            }else if (textiles.Count == 0 && medicaments.Count>0)
            {
                Console.WriteLine("Textiles are empty.");
            }else if(textiles.Count > 0 && medicaments.Count == 0)
            {
                Console.WriteLine("Medicaments are empty.");
            }

            Dictionary<string,int> map = new Dictionary<string,int>();
            map.Add("Patch", patchCount);
            map.Add("Bandage", bandageCount);
            map.Add("MedKit", medKitCount);

            foreach(var item in map.OrderByDescending(it=>it.Value).ThenBy(it=>it.Key))
            {
                if (item.Value != 0)
                {
                    Console.WriteLine($"{item.Key} - {item.Value}");
                }
               
            }
            if(medicaments.Count > 0)
            {
                //"Medicaments left: {medicament1}, {medicament2}…"
                Console.Write("Medicaments left: ");
                Console.WriteLine(String.Join (", ", medicaments));
            }
            if(textiles.Count>0)
            {
                Console.Write("Textiles left: ");
                Console.WriteLine(String.Join(", ", textiles));
            }
        }
    }
}
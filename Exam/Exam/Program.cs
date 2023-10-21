using System.Security.Cryptography;

namespace Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> fuel = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            Queue<int> additional = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            Queue<int> needed = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            int altitudeCounter = 0;
            List<string> list = new List<string>();
            bool isTopReached = true;

            while(fuel.Count>0 && additional.Count>0)
            {
                int currFuel = fuel.Peek();
                int currAdditional = additional.Peek();
                int result = currFuel - currAdditional;
                if (result>=needed.Peek())

                {
                    fuel.Pop();
                    additional.Dequeue();
                    needed.Dequeue();
                    altitudeCounter++;
                    list.Add($"Altitude {altitudeCounter}");
                    Console.WriteLine($"John has reached: Altitude {altitudeCounter}");
                }
                else
                {
                    Console.WriteLine($"John did not reach: Altitude {altitudeCounter + 1}");
                    isTopReached = false;
                    break;
                }
            }
            if( altitudeCounter > 0 && !isTopReached)
            {
                Console.WriteLine("John failed to reach the top.");
                Console.Write("Reached altitudes: ");
                
                    Console.WriteLine(String.Join(", ", list));
                
            }else if(altitudeCounter==0 && !isTopReached)
            {
                Console.WriteLine("John failed to reach the top.");
                Console.WriteLine("John didn't reach any altitude.");
            }else if(altitudeCounter>0 && isTopReached)
            {
                Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
            }
        }
    }
}
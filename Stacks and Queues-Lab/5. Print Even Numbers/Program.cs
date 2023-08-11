using System;

namespace _5._Print_Even_Numbers
{

//    Create a program that:
//•	Reads an array of integers and adds them to a queue
//•	Prints the even numbers separated by ", "

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(numbers);
            List<int> result = new List<int>();
             while(queue.Any())
            {
                int currNum = queue.Peek();
                if (currNum % 2 == 0)
                {
                    result.Add(currNum);
                }
                queue.Dequeue();
            }
           
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
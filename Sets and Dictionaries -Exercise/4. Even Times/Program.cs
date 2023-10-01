
using System.Collections.Generic;

namespace _4._Even_Times

//    Create a program that prints a number from a collection, which appears an even number of times in it.On the first
//line, you will be given n – the count of integers you will receive.On the next n lines, you will be receiving the numbers.
//It is guaranteed that only one of them appears an even number of times. Your task is to find that number and print
//it in the end. 

{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<int,int> numbers = new Dictionary<int,int>();
            for(int i = 0; i < count; i++)
            {
                int currNum = int.Parse(Console.ReadLine());
                if (!numbers.ContainsKey(currNum))
                {
                    numbers[currNum] = 0;
                }
                numbers[currNum]++;
            }
            foreach(var occurence in numbers)
            {
                if(occurence.Value %2 == 0)
                {
                    Console.WriteLine(occurence.Key);
                }
            }
        }
    }
}
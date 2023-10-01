using System.Collections.Generic;
using System.Xml.Linq;
namespace _2._Sets_of_Elements
{
//    Create a program that prints a set of elements.On the first line, you will receive two numbers - n and m, which
//represent the lengths of two separate sets.On the next n + m lines, you will receive n numbers, which are the numbers
//in the first set, and m numbers, which are in the second set.Find all the unique elements that appear in both of them
//and print them in the order in which they appear in the first set - n.
//For example:
//Set with length n = 4: { 1, 3, 5, 7}
//    Set with length m = 3: {3, 4, 5}
//Set that contains all the elements that repeat in both sets -> {3, 5}

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] counts = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int firstSetCount = counts[0];
            int secondSetCount = counts[1];
            HashSet<double> first = new HashSet<double>();
            HashSet<double> second = new HashSet<double>();
            HashSet<double> uniqueValuesInBothSets = new HashSet<double>();
            for (int i = 0; i < firstSetCount; i++)
            {
                first.Add(double.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < secondSetCount; i++)
            {
               
                second.Add(double.Parse(Console.ReadLine()));
                
            }
            foreach(int num in first)
            {
                if (second.Contains(num))
                {
                    uniqueValuesInBothSets.Add(num);
                }
            }

            //ВАЖНО!!! 
            // ТОВА Е МЕТОД, КОЙТО НАМИРА СЪВПАДЕНИЯТА МЕЖДУ ДВЕ МНОЖЕСТВА И ВРЪЩА INUMERABLE КОЛЕКЦИЯ

            // ПЪРВО МНОЖЕСТВО.INTERSECT(ВТОРО МНОЖЕСТВО)


            // List<double> values = first.Intersect(second).ToList();
            //Console.WriteLine(String.Join(" ", values));

            foreach (double num in uniqueValuesInBothSets)
            {
                Console.Write(num+" ");
            }
            Console.WriteLine();
        }
    }
}
﻿

namespace _3._Periodic_Table
{
//    Create a program that keeps all the unique chemical elements.On the first line, you will be given a number n - the
//count of input lines that you are going to receive.On the next n lines, you will be receiving chemical compounds,
//separated by a single space.Your task is to print all the unique ones in ascending order
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            SortedSet<string> periodicTable = new SortedSet<string>();
            for(int i = 0; i < rows; i++)
            {
                string[] currRow = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                for(int j = 0; j < currRow.Length; j++)
                {
                    string currElement = currRow[j];
                    periodicTable.Add(currElement);
                }
            }
            foreach(string element  in periodicTable)
            {
                Console.Write(element+" ");
            }
            Console.WriteLine();
        }
    }
}
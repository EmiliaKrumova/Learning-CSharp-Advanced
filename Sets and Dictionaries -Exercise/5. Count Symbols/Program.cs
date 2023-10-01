
using System;

namespace _5._Count_Symbols


//    Create a program that reads some text from the console and counts the occurrences of each character in it.Print the
//results in alphabetical(lexicographical) order

{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            SortedDictionary<char, int> chars = new SortedDictionary<char, int>();
            for(int i = 0;i<text.Length;i++)
            {
                char currChar = text[i];
                if (!chars.ContainsKey(currChar))
                {
                    chars[currChar] = 0;
                }
                chars[currChar]++;
            }
            foreach(var kvp in chars)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
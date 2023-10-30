using System;

namespace _4._FindEvens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int startNum = range[0];
            int endNum = range[1];
            List<int> numbers = new List<int>();
            for (int i = startNum; i <= endNum; i++)
            {
                numbers.Add(i);
            }
            Predicate<int> IsEven = number => number % 2 == 0;
            // Predicate  - функция само с един параметър, в случая приема инт и ВИНАГИ връща булева "True/False"


            Action<int[]> printNumbers = inputnumbers=> Console.WriteLine(String.Join(" ", inputnumbers));
            // принтираща функция за колекцията 
            //Използва Стринг.Джойн с разделител " " и колекцията с предиката, който определя дали числото е четно или нечетно


            string command = Console.ReadLine();
            if(command == "even")
            {
                printNumbers(numbers.Where(x=> IsEven(x)).ToArray());
                //Console.WriteLine(String.Join(" ", numbers.Where(x=>IsEven(x))));
                // тези редове код са взаимно - заменяеми


            }else if(command == "odd")
            {
               printNumbers(numbers.Where(x => !IsEven(x)).ToArray());
                // тези редове код са взаимно - заменяеми
                //Console.WriteLine(String.Join(" ", numbers.Where(x => !IsEven(x))));
            }
        }
    }
}
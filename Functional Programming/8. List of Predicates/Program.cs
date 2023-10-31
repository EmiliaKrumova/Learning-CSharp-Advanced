namespace _8._List_of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int endOfSequence = int.Parse(Console.ReadLine());

            int[] deviders = Console.ReadLine().Split().Select(int.Parse).ToArray();//колекция от делители
            int[] numbers = new int[endOfSequence];  // колекция числа
            for(int i = 0; i < endOfSequence; i++)
            {
                numbers[i] = i+1;// пълня масива от числа

            }
            List<Predicate<int>>predicates = new List<Predicate<int>>();// списък с предикати

            foreach(int devider in deviders)// за всеки делител в колекцията делители
            {
                predicates.Add(x=>x%devider==0);// добави го, само ако число се дели на него
            }

            foreach(int number in numbers)// за всяко число в колекцията
            {
                bool isDivisible = true;
                foreach(var predicate in predicates) // минавам през всички предикати
                {
                    if (!predicate(number))// ако числото не се дели на делителя прекратяваме цикъла и въртим следващото число в горния форийч
                    {
                        isDivisible = false;
                        break;
                    }
                   
                }
                if (isDivisible)// ако числото е минало през всички делители и все още е делимо(true), го пишем на конзолата
                {
                    Console.Write($"{number} ");
                }
            }
        }
    }
}
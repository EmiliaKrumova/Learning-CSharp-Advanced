namespace _8._List_of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int endOfSequence = int.Parse(Console.ReadLine());

            int[] deviders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbers = new int[endOfSequence];  
            for(int i = 0; i < endOfSequence; i++)
            {
                numbers[i] = i+1;

            }
            List<Predicate<int>>predicates = new List<Predicate<int>>();

            foreach(int devider in deviders)
            {
                predicates.Add(x=>x%devider==0);
            }

            foreach(int number in numbers)
            {
                bool isDivisible = true;
                foreach(var predicate in predicates)
                {
                    if (!predicate(number))
                    {
                        isDivisible = false;
                        break;
                    }
                   
                }
                if (isDivisible)
                {
                    Console.Write($"{number} ");
                }
            }
        }
    }
}
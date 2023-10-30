namespace _6._Reverse_and_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int divideNumber = int.Parse(Console.ReadLine());
            Predicate<int> isDivisible = n => n% divideNumber == 0;

            Func<int[], int[]> excludeAndReverseFunction = numbers => numbers.Where(x=> !isDivisible(x)).Reverse().ToArray();


           numbers =  excludeAndReverseFunction(numbers);
            Action<int[]> printAction = numbers => Console.WriteLine(String.Join(" ", numbers));
           printAction(numbers);
        }
    }
}
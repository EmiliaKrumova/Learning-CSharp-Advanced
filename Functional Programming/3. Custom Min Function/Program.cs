namespace _3._Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbersInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int[], int> minNumber = numbersInput =>
            {
                int minNum = int.MaxValue;
                foreach (int num in numbersInput)
                {
                    if (num < minNum)
                    {
                        minNum = num;
                    }
                }
                return minNum;
            };
            Console.WriteLine(minNumber(numbersInput));
        }
    }
}
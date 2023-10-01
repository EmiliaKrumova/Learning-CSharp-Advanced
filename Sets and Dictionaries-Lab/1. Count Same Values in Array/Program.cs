namespace _1._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            Dictionary<double, int> numbers = new Dictionary<double, int>();
            for(int i = 0; i < input.Length; i++)
            {
                double currNum = input[i];
                if(!numbers.ContainsKey(currNum))
                {
                    numbers[currNum] = 0;
                }
                numbers[currNum]++;
            }
            foreach(var number in numbers)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
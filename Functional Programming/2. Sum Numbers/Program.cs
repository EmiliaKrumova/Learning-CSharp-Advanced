namespace _2._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Func<string, int> parser = n => int.Parse(n); 
            List<int> numbers = new List<int>(Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(parser));
            Console.WriteLine(numbers.Count);
            Console.WriteLine(numbers.Sum());
        }
    }
}
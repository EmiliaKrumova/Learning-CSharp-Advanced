namespace _4._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double>taxes = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(x => x * 1.2)
                .ToList();

            foreach(var tax in taxes)
            {
                Console.WriteLine($"{tax:f2}");
            }
        }
    }
}
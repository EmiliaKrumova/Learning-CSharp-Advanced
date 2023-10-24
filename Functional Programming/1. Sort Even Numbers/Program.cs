namespace _1._Sort_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<int> numbers = new List<int>();
            numbers = input.Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> filtered = numbers.Where(x => x %2== 0).OrderBy(x=>x).ToList();
            Console.WriteLine(String.Join(", ", filtered));
        }
    }
}
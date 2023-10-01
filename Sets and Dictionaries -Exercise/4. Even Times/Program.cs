namespace _4._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<int,int> numbers = new Dictionary<int,int>();
            for(int i = 0; i < count; i++)
            {
                int currNum = int.Parse(Console.ReadLine());
                if (!numbers.ContainsKey(currNum))
                {
                    numbers[currNum] = 0;
                }
                numbers[currNum]++;
            }
            foreach(var occurence in numbers)
            {
                if(occurence.Value %2 == 0)
                {
                    Console.WriteLine(occurence.Key);
                }
            }
        }
    }
}
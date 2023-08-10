namespace _1._Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string input = Console.ReadLine();
            Stack<char> chars = new Stack<char>();
            for(int i = 0;i<input.Length;i++)
            {
                chars.Push(input[i]);
            }
            while (chars.Count > 0)
            {
                Console.Write(chars.Pop());
            }
            Console.WriteLine();
        }
    }
}
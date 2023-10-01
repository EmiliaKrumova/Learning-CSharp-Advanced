namespace _6._Record_Unique_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            HashSet<string> names = new HashSet<string>();
            for(int i = 0; i < count; i++)
            {
                names.Add(Console.ReadLine());  
            }
            foreach(string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
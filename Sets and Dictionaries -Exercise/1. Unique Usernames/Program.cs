namespace _1._Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            HashSet<string> names = new HashSet<string>();
            for(int i = 0; i < count; i++)
            {
                string name = Console.ReadLine();
                names.Add(name);
            }
            foreach(string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
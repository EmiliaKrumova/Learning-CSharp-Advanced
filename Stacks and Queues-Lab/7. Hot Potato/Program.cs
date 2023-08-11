namespace _7._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            int tosses = int.Parse(Console.ReadLine());
            Queue<string> kids = new Queue<string>(names);
            while(kids.Count > 1)
            { 
                for(int i = 1;i<=tosses;i++)
                {
                    string currentKid = kids.Dequeue();
                    if (i != tosses)
                    {
                        kids.Enqueue(currentKid);
                    }
                    else
                    {
                        Console.WriteLine($"Removed {currentKid}");
                    }
                }

            }
            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
namespace _7._Hot_Potato
{
    
    /*Hot potato is a game in which children form a circle and start passing a hot potato. The counting starts with the fist kid. Every nth toss the child left with the potato leaves the game. When a kid leaves the game, it passes the potato along. This continues until there is only one kid left.
Create a program that simulates the game of Hot Potato.  Print every kid that is removed from the circle. In the end, print the kid that is left last.  */
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
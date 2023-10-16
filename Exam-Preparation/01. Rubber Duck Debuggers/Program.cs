namespace _01._Rubber_Duck_Debuggers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> programmers = new Queue<int>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int dartVader = 0;
            int thor = 0;
            int blue = 0;
            int yellow = 0;
            while (programmers.Count > 0&& tasks.Count > 0)
            {
                int currProgTime = programmers.Dequeue();
                int currTask = tasks.Pop();
                int result = currProgTime * currTask;
                if(result >= 0 && result<=60)
                {
                    dartVader++;
                }else if(result > 60 && result <= 120)
                {
                    thor++;
                }else if(result>120 && result <= 180)
                {
                    blue++;
                }else if(result > 180 && result <= 240)
                {
                    yellow++;
                }
                else
                {
                    currTask -= 2;
                    tasks.Push(currTask);
                    programmers.Enqueue(currProgTime);
                    //to do
                }

            }
            Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
            Console.WriteLine($"Darth Vader Ducky: {dartVader}");
            Console.WriteLine($"Thor Ducky: {thor}");
            Console.WriteLine($"Big Blue Rubber Ducky: {blue}");
            Console.WriteLine($"Small Yellow Rubber Ducky: {yellow}");
        }
    }
}
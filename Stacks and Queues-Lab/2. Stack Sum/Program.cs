namespace _2._Stack_Sum
{
    

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(numbers);
            string command = Console.ReadLine().ToLower();
           
            while ((command != "end"))
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string realCmd = tokens[0];
                if(realCmd == "add")
                {
                    int firstNumber = int.Parse(tokens[1]);
                    int secondNumber = int.Parse(tokens[2]);
                    stack.Push(firstNumber);
                    stack.Push(secondNumber);

                }
                else if(realCmd == "remove")
                {
                    int elementsToRemove = int.Parse(tokens[1]);
                    if(stack.Count >= elementsToRemove)
                    {
                        for(int i = 0; i < elementsToRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                    else
                    {
                        command = Console.ReadLine().ToLower();
                        continue;
                    }
                }
                command = Console.ReadLine().ToLower();
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
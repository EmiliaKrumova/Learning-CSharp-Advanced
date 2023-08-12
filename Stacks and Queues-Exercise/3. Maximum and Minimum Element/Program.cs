namespace _3._Maximum_and_Minimum_Element
{

    /*You have an empty sequence and you will be given N queries. Each query is one of these three types:
1 x – Push the element x into the stack.
2 – Delete the element present at the top of the stack.
3 – Print the maximum element in the stack.
4 – Print the minimum element in the stack.
After you go through all of the queries, print the stack in the following format:
"{n}, {n1}, {n2} …, {nn}
     */


    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfCommands = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();
            for (int i = 0; i < countOfCommands; i++)
            {
                int[] command = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int realCommand = command[0];
                switch (realCommand)
                {
                    case 1:
                        {
                            int numberToPush = command[1];
                            numbers.Push(numberToPush);
                            break;
                        }
                        case 2:
                        {
                            if (numbers.Any())
                            {
                                numbers.Pop();
                            }
                            else
                            {
                                continue;
                            }

                            break;
                        }
                        case 3:
                        {
                            if (numbers.Any())
                            {
                                Console.WriteLine(numbers.Max());
                            }
                            break;
                        }
                        case 4:
                        {
                            if (numbers.Any())
                            {
                                Console.WriteLine(numbers.Min());
                            }
                            break;
                        }
                }
            }
            if(numbers.Any() )
            {
                Console.WriteLine(string.Join(", ", numbers));
            }
            
        }
    }
}
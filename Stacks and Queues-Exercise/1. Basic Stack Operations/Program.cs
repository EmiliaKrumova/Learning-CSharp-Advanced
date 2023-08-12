namespace _1._Basic_Stack_Operations

/*Play around with a stack. You will be given an integer N representing the number of elements to push into the stack, 
an integer S representing the number of elements to pop from the stack, and finally an integer X, an element that 
you should look for in the stack. If it's found, print "true" on the console. If it isn't, print the smallest element 
currently present in the stack. If there are no elements in the sequence, print 0 on the console.
 */
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();
            int numberToPush = parameters[0];
            int numberToPop = parameters[1];
            int numberToReturn = parameters[2];


            for (int j = 0; j < numberToPush; j++)
            {
                stack.Push(input[j]);
            }

            for (int k = 0; k < numberToPop; k++)
            {
                if (stack.Count > 0)
                {
                    stack.Pop();
                }
                if (stack.Count == 0)
                {

                    Console.WriteLine("0");
                    break;

                }
            }

            if (stack.Count > 0)
            {
                if (stack.Contains(numberToReturn))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(stack.Min());
                }
            }




        }
    }
}
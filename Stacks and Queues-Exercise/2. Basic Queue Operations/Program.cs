namespace _2._Basic_Queue_Operations
{
    /*Play around with a queue. You will be given an integer N representing the number of elements to enqueue (add), an 
integer S, representing the number of elements to dequeue (remove) from the queue, and finally an integer X, an 
element that you should look for in the queue. If it is, print true on the console. If it's not printed the smallest
element is currently present in the queue. If there are no elements in the sequence, print 0 on the console.     */


    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int numberToEnQ = numbers[0];
            int numberToDeQ = numbers[1];
            int numberToPeek = numbers[2];
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < numberToEnQ; i++)
            {
                queue.Enqueue(input[i]);
            }
            for(int i = 0;i < numberToDeQ; i++)
            {
                if (queue.Count > 0)
                {
                    queue.Dequeue();
                }
                else
                {
                    Console.WriteLine("0");
                    break;
                }
                
            }
            if (queue.Contains(numberToPeek))
            {
                Console.WriteLine("true");
            }else if(!queue.Contains(numberToPeek) && queue.Count > 0)
            {
                Console.WriteLine(queue.Min());
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
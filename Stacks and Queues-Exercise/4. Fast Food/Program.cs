namespace _4._Fast_Food
{
    /*First, you will be given the quantity of the food that you have for the day (an integer number). Next, you will be given 
a sequence of integers, each representing the quantity of order. Keep the orders in a queue. Find the biggest order
and print it. You will begin servicing your clients from the first one that came. Before each order, check if you have 
enough food left to complete it. If you have, remove the order from the queue and reduce the amount of food you 
have. If you succeeded in servicing all of your clients, print: 
"Orders complete".
If not – print:
"Orders left: {order1} {order2} .... {orderN}"
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> clients = new Queue<int>(orders);
            int maxOrder = clients.Max();
            while (clients.Count > 0&& quantity>=0)
            {
                
                int result = quantity - clients.Peek();
                if(result >= 0)
                {
                    quantity -= clients.Dequeue();
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(maxOrder);
            if(clients.Count > 0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ",clients)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
            
        }
    }
}
using System.Xml.Linq;

namespace _6._Supermarket
{

    //Reads an input consisting of a name and adds it to a queue until "End" is received.If you receive "Paid", print every customer name and empty the queue, otherwise we receive a client and we have to add him to the queue.When we receive "End" we have to print the count of the remaining people in the queue in the format: "{count} people remaining.".
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            Queue<string> names = new Queue<string>();  
            while((command = Console.ReadLine()) != "End")
            {
                if (command == "Paid")
                {
                   while (names.Count > 0)
                    {
                       Console.WriteLine(names.Dequeue());
                    }
                }
                else
                {
                    names.Enqueue(command);
                }

            }
            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}
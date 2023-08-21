namespace _12._Cups_and_Bottles
{
    /*You will be given a sequence of integers – each indicating a cup's capacity. After that, you will be given another 
sequence of integers – a bottle with water in it. Your job is to try to fill up all of the cups.
The filling is done by picking exactly one bottle at a time. You must start picking from the last received bottle and 
start filling from the first entered cup. If the current bottle has N water, you give the first entered cup N water and 
reduce its integer value by N.
When a cup's integer value reaches 0 or less, it gets removed. The current cup's value may be greater than the current 
bottle's value. In that case, you pick bottles until you reduce the cup's integer value to 0 or less. If a bottle's value is 
greater or equal to the cup's current value, you fill up the cup, and the remaining water becomes wasted. You should 
keep track of the wasted litter of water and print it at the end of the program. 
If you have managed to fill up all of the cups, print the remaining water bottles, from the last entered – to the first, 
otherwise you must print the remaining cups, by order of entrance – from the first entered – to the last. 
     */

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cupsArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> cups = new Queue<int>(cupsArray);
            int[] bottlesArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> bottles = new Stack<int>(bottlesArray);
            int wasted = 0;
            int currCup = cups.Peek(); // get the first cup
            while (bottles.Count > 0 && cups.Count > 0)
            {
                int currBottle = bottles.Pop();// get the last bottle
                
                if(currBottle >= currCup )// the cup is filled with water from bottle
                {
                    wasted += currBottle - currCup;// wasted water
                    cups.Dequeue();// remove this cup
                    if (cups.Count > 0)// if there is more cups to fill
                    {
                        currCup = cups.Peek(); //get the next one
                    }
                    else
                    {
                        break;
                    }
                    
                    
                }
                else
                {
                    currCup -= currBottle;
                    continue;
                  
                    
                }
            }
            if(bottles.Count == 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ",cups)}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(" ",bottles)}");
            }
            Console.WriteLine($"Wasted litters of water: {wasted}");
        }
    }
}
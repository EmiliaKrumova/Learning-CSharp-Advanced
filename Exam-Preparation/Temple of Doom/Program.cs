namespace Temple_of_Doom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> tools = new Queue<int>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> substances = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            List<int> chalenges = new List<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            while(chalenges.Count>0)
            {
                int currTool = tools.Dequeue();
                int currSubstance = substances.Pop();
                int result = currTool * currSubstance;
                if(chalenges.Contains(result))
                {
                    chalenges.Remove(result);
                   
                    if (chalenges.Count == 0)
                    {
                        Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
                        break;

                    }
                }
                else
                {
                    currTool++;
                   
                    tools.Enqueue(currTool);
                    currSubstance--;
                    if(currSubstance>0)
                    {
                       
                        substances.Push(currSubstance);
                    }
                    
                    
                }

                    if (tools.Count == 0 || substances.Count == 0)
                    {
                        Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
                        break;
                    }
                   
                
               
                
            }
            if(tools.Count>0)
            {
                Console.Write("Tools: ");
                Console.WriteLine(string.Join(", ", tools));
            }
            if (substances.Count > 0)
            {
                Console.Write("Substances: ");
                Console.WriteLine(string.Join(", ", substances));
            }
            if (chalenges.Count > 0)
            {
                Console.Write("Challenges: ");
                Console.WriteLine(string.Join(", ", chalenges));
            }
        }
    }
}
using System.Linq;
using System.Text;

namespace _9._Simple_Text_Editor
{
    /*You are given an empty text. Your task is to implement 4 commands related to manipulating the text

 1 someString - appends someString to the end of the text.
 2 count - erases the last count elements from the text.
 3 index - returns the element at position index from the text.
 4 - undoes the last not undone command of type 1 or 2 and returns the text to the state before that 
operation.
     */

    internal class Program
    {
        static void Main(string[] args)
        {
            int countOperations = int.Parse(Console.ReadLine());
            string stringToOperate = string.Empty;
            Stack<string> lastStateOfString = new Stack<string>();
            lastStateOfString.Push(stringToOperate);
            for (int i = 0; i < countOperations; i++)
            {
                string[] command = Console.ReadLine().Split();
                string realCmd = command[0];
                if(realCmd == "1")
                { 
                    
                    string substring = command[1];
                    stringToOperate = stringToOperate + substring;
                    
                    lastStateOfString.Push(stringToOperate);

                }else if(realCmd == "2")
                {
                    int elementsToDelete = int.Parse(command[1]);
                    if (stringToOperate.Length>= elementsToDelete)
                    {
                        stringToOperate = stringToOperate.Remove(stringToOperate.Length - elementsToDelete);
                        lastStateOfString.Push(stringToOperate);

                    }
                 

                }else if (realCmd == "3")
                {
                    int indexToReturn = int.Parse(command[1]);
                    if(stringToOperate.Length>= indexToReturn)
                    {
                        Console.WriteLine(stringToOperate.ElementAt(indexToReturn - 1));

                    }
                    
                    

                }else if (realCmd == "4")
                {
                    if(lastStateOfString.Count > 1)
                    {
                        lastStateOfString.Pop();
                        stringToOperate = lastStateOfString.Peek();
                    }
                    

                }

             
            }
        }
    }
}
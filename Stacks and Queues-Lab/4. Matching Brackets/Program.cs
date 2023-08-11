using System.Linq.Expressions;

namespace _4._Matching_Brackets

//    We are given an arithmetic expression with brackets.Scan through the string and extract each sub-expression.
//Print the result back at the terminal.

    //INPUT

//1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5

     //OUTPUT

  //(2 + 3)
  //(3 + 1)
  //(2 - (2 + 3) * 4 / (3 + 1))


{
    internal class Program
{
        static void Main(string[] args)
        {
            
            string input = Console.ReadLine();
            Stack<int> bracketsIndex = new Stack<int>();
            for(int i = 0; i <input.Length;i++)

            {
                if (input[i] == '(')
                {
                    bracketsIndex.Push(i);
                }
                if (input[i] == ')')
                {
                    int startIndex = bracketsIndex.Pop();
                    int endIndex = i;
                    string substring = input.Substring(startIndex, endIndex-startIndex+1);
                    Console.WriteLine(substring);
                }
            }
        }
    }
}
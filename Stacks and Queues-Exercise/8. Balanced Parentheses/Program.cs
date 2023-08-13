namespace _8._Balanced_Parentheses
{
    /*Given a sequence consisting of parentheses, determine whether the expression is balanced. A sequence of 
parentheses is balanced, if every open parenthesis can be paired uniquely with a closing parenthesis that occurs 
after the former. Also, the interval between them must be balanced. You will be given three types of 
parentheses: (, {, and [.
{[()]} - This is a balanced parenthesis.
{[(])} - This is not a balanced parenthesis.

Input
 Each input consists of a single line, the sequence of parentheses.

Output 
 For each test case, print on a new line "YES", if the parentheses are balanced. 
Otherwise, print "NO". Do not print the quotes
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            string parentheses = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            for(int i = 0;i<parentheses.Length;i++)
            {
                if (parentheses[i] == '('||parentheses[i]=='['||parentheses[i]=='{')
                {
                    stack.Push(parentheses[i]);
                }
                 if (parentheses[i] == ')'|| parentheses[i]==']' || parentheses[i]=='}')
                {
                    if(stack.Count > 0)
                    {
                        char matchingParentesis = stack.Peek();
                        char currParent = parentheses[i];
                        char charToCompare = default;
                        if (currParent == ')')
                        {
                            charToCompare = '(';
                        }
                        else if (currParent == ']')
                        {
                            charToCompare = '[';
                        }
                        else if (currParent == '}')
                        {
                            charToCompare = '{';
                        }
                        if (charToCompare == matchingParentesis)
                        {
                            stack.Pop();
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("NO");
                            return;
                        }

                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }


                }
            }
            if( stack.Count > 0 )
            {
                Console.WriteLine("NO");

            }
            else
            {
                Console.WriteLine("YES");
            }

        }
    }
}
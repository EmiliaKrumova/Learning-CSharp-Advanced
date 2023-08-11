namespace _3._Simple_Calculator
{
    //2+5+10-2-1
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            string[] elements = expression.Split(" ",StringSplitOptions.RemoveEmptyEntries);
            Stack<string> operation = new Stack<string>();
            Stack<int> numbers = new Stack<int>();
            for(int i = 0;i<elements.Length;i++)
            {
                string element = elements[i];
                if (element == "+"|| element== "-")
                {
                    operation.Push(element);
                }
               
                else 
                { 
                    int currNum = int.Parse(element);
                   
                                      
                    
                    if(numbers.Count == 0)
                    {
                        numbers.Push(currNum);
                    }
                    else
                    {
                        string operate =operation.Pop();
                        int firstOperand = numbers.Pop();
                        if(operate == "+")
                        {
                            int result = firstOperand + currNum;
                            numbers.Push(result);
                        }
                        if (operate == "-")
                        {
                            int result = firstOperand - currNum;
                            numbers.Push(result);
                        }
                    }
                }
               

            } Console.WriteLine(numbers.Pop());
        }
    }
}
namespace _5._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string operation;


           



            while((operation = Console.ReadLine()) != "end")
            {
                if(operation == "add")
                {
                    Func<int, int > addAction = number => number+=1;// два различни подхода => тук е само за едно число

                    Func<List<int>, List<int>> addFunction = numbers =>// тук е за колекция от числа
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            numbers[i] += 1;
                        }
                        return numbers;
                    };



                    addFunction(numbers);
                   
                  //for(int i = 0; i < numbers.Count; i++)
                  //  {
                  //      numbers[i] = addAction(numbers[i]);
                  //  }

                }else if(operation == "multiply")
                {
                    Func<int, int> multiAction = number => number *=2;
                    for (int i = 0; i < numbers.Count; i++)
                    {
                       numbers[i] =  multiAction(numbers[i]);
                    }

                }
                else if(operation == "subtract")
                {
                    Func<int, int> substractAction = number => number -=1;
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers[i] = substractAction(numbers[i]);
                    }

                }
                else if(operation == "print")
                {
                    Action < List<int>> action = numbers => Console.WriteLine(String.Join(" ", numbers));
                    action(numbers);

                }

            }
        }
    }
}
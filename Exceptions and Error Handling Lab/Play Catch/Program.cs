namespace Play_Catch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int cathed = 0;
            while(cathed<3)
            {
                string[] tokens = Console.ReadLine().Split();
                string command = tokens[0];
                string indexStr = tokens[1];

                if (command== "Replace")
                {                   
                    string elementStr = tokens[2];
                    try
                    {
                        int index = FormatValidator(indexStr);
                        int element = FormatValidator(elementStr);
                        IsValidIndex(numbers, index);
                        numbers.RemoveAt(index);
                        numbers.Insert(index, element);
                        
                    }
                    catch (Exception ex)
                    {
                        cathed++;
                        Console.WriteLine(ex.Message);
                    }

                   
                }else if (command== "Print")
                {
                    try
                    {
                        int startIndex = FormatValidator(indexStr);
                        int endIndex = FormatValidator(tokens[2]);
                        IsValidIndex(numbers, startIndex);
                        IsValidIndex(numbers, endIndex);
                        List<int>numbersToPrint = numbers.GetRange(startIndex, endIndex);
                        Console.WriteLine(String.Join(", ", numbersToPrint));
                        
                    }
                    catch (Exception ex)
                    {
                        cathed++;

                        Console.WriteLine(ex.Message);
                    }
                    
                }else if(command== "Show")
                {

                    try
                    {
                        int index = FormatValidator(indexStr);
                        IsValidIndex(numbers, index);
                        Console.WriteLine(numbers[index]);
                    }
                    catch (Exception ex)
                    {
                        cathed++;
                        Console.WriteLine(ex.Message);
                    }
                    
                }
            }

            Console.WriteLine(String.Join(", ", numbers));
        }
        public static int FormatValidator(string item)
        {
            bool isInteger = int.TryParse(item, out int value);
            if(!isInteger)
            {
                throw new FormatException("The variable is not in the correct format!");
            }
            return value;
        }
        public static void IsValidIndex(List<int> numbers,int index)
        {
            if(index<0||index>=numbers.Count)
            {
                throw new IndexOutOfRangeException("The index does not exist!");
            }
        }
    }
}
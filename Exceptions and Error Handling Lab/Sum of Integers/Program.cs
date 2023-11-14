namespace Sum_of_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                string numAsString = input[i];
                try
                {
                    TryToParse(numAsString);
                    int num = Overflow(numAsString);
                    sum += num;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine($"Element '{numAsString}' processed - current sum: {sum}");
                }
            }
            Console.WriteLine($"The total sum of all integers is: {sum}");                  
                       
        }
        public  static long TryToParse(string numberAsString)
        {
            bool isParsed = long.TryParse(numberAsString, out long result);
            if (!isParsed) 
            {
                throw new FormatException($"The element '{numberAsString}' is in wrong format!");
            }
            return result;
            
        }
        public static int Overflow(string numberAsString)
        {
            
            if(long.Parse(numberAsString)>int.MaxValue || long.Parse(numberAsString) < int.MinValue)
            {
                
                throw new OverflowException($"The element '{numberAsString}' is out of range!");
            }
           
            return int.Parse(numberAsString);

        }
    }
}
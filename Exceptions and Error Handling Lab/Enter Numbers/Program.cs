namespace Enter_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int startNum = 1;
            int endNum = 100;
            while (numbers.Count < 10)
            {
                try
                {
                    int currNumber = int.Parse(Console.ReadLine());
                    int numberToAdd = ReadNumber(currNumber,startNum,endNum);
                    startNum = numberToAdd;
                    numbers.Add(numberToAdd);
                }
                catch (FormatException)
                {

                    Console.WriteLine("Invalid Number!");
                }catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }                
                
            }
            Console.WriteLine(String.Join(", ", numbers));
        }
        public static int ReadNumber(int currnumber, int startNum, int endNum)
        {           

            if (currnumber <= startNum || currnumber >= endNum)
            {
                throw new ArgumentException($"Your number is not in range {startNum} - 100!");
            }          
            return currnumber;
        }
    }
}
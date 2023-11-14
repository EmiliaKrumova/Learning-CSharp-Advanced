

namespace Square_Root
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double number = double.Parse(Console.ReadLine());

            try
			{
               
                double valid = NumerValidator(number);
                double sqrt = Math.Sqrt(valid);
                Console.WriteLine(sqrt);

			}
			catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
			
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
        public static double NumerValidator(double number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Invalid number.");
            }
            else
            {
                return number;
            }

        }
    }
}
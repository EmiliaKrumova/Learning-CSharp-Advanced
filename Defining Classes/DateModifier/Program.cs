namespace DateModifier
   
{
    using static DateModifier;
    internal class Program
    {
        
        static void Main(string[] args)
        {
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();

            int difference = DifferenceBetweenDates(startDate, endDate);
            Console.WriteLine(difference);

        }
    }
}
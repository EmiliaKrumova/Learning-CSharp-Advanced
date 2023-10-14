namespace Enumerators
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            DaysOfWeek day = DaysOfWeek.Monday;
            Console.WriteLine(day);
            day = DaysOfWeek.Sunday;
            Console.WriteLine(day);

            CoffeeSize coffee = CoffeeSize.Small;
            Console.WriteLine((int)coffee);
        }
            enum DaysOfWeek// трябва да са извън Мейн метода!!!
        {
            Monday, Tuesday, Wednesday, Friday, Saturday, Sunday
        } 

        enum CoffeeSize
        {
            Small = 75,
            Medium =100,
            Large =150,
        }

    
    }

}
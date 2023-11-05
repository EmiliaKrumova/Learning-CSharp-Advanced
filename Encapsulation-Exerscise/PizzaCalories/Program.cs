namespace PizzaCalories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dough dough = new Dough("White", "Chewy", 100);
            Console.WriteLine(dough.CaloriesPerGram);
            Topping topping = new Topping("Meat", 500);
            Console.WriteLine(topping.ToppingCalories);
        }
    }
}
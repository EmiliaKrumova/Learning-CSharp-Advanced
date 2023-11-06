namespace PizzaCalories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] pizzaInfo = Console.ReadLine().Split();
            string[] doughInfo = Console.ReadLine().Split();
            string pizzaName = pizzaInfo[1];
            try
            {
                Dough dough = new Dough(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));

                Pizza pizza = new Pizza(pizzaName, dough);
                string command = String.Empty;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] topingInfo = command.Split();
                    Topping topping = new Topping(topingInfo[1], double.Parse(topingInfo[2]));
                    pizza.AddToppingToToppingsColection(topping);
                }
                Console.WriteLine(pizza.ToString());
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
    }
}
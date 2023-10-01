namespace _3._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            SortedDictionary<string,Dictionary<string,double>> shops = new SortedDictionary<string,Dictionary<string,double>>();
            while((command = Console.ReadLine()) != "Revision")
            {
                string[] input = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = input[0];
                string product = input[1];
                double price = double.Parse(input[2]);
                if(!shops.ContainsKey(shop))
                {
                    shops[shop] = new Dictionary<string, double>();
                    if (!shops[shop].ContainsKey(product))
                    {
                        shops[shop][product] = 0;
                    }
                }
                shops[shop][product] = price;
            }
            foreach(var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach(var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
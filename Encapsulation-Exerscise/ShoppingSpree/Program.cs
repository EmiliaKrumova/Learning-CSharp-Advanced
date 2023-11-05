namespace ShoppingSpree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();   
            string[] peopleInfo = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries);

            for(int i = 0; i < peopleInfo.Length; i++)
            {
                string[] personTokens = peopleInfo[i].Split("=",StringSplitOptions.RemoveEmptyEntries);
                string personName = personTokens[0];
                decimal personMoney = decimal.Parse(personTokens[1]);
                
                try
                {
                    Person person = new Person(personName, personMoney);
                    persons.Add( person );
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
               
            }
            string[] productsInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            for( int i = 0;i < productsInfo.Length;i++)
            {
                string[] productInfo = productsInfo[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                string productName = productInfo[0];
                decimal costOfProduct = decimal.Parse(productInfo[1]);
                try
                {
                    Product product = new Product(productName, costOfProduct);
                    products.Add( product );
                    

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
                
            }

            string shopping;
            while(( shopping = Console.ReadLine()) != "END")
            {
                string[] personProductPair = shopping.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string buyer = personProductPair[0];
                string productToBuy = personProductPair[1];
                Person person = persons.FirstOrDefault( p => p.Name == buyer );
                Product product = products.FirstOrDefault(p => p.Name == productToBuy);

                if( product != null  && person!=null) 
                {
                    Console.WriteLine(person.BuyingProducts(product));
                }

            }
            foreach(var person in  persons)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
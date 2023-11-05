using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    public class Person
    {
		private string name;
		private decimal money;
		private List<Product> bagOfProducts;

        public Person(string name,decimal money )
        {
            bagOfProducts = new List<Product>();
            Money = money;
            Name = name;
        }

  //      public List<Product> BagOfProducts
		//{
		//	get { return bagOfProducts; }
		//	private set { bagOfProducts = value; }
		//}


		public decimal Money
		{
			get { return money; }
			private set 
			{
				if(value< 0)
				{
					throw new ArgumentException("Money cannot be negative");
				}
				money = value; 
			}
		}


		public string Name
		{
			get { return name; }
			private set 
			{
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");

                }
                name = value; 
			}
		}

		public string BuyingProducts(Product product)
		{
			if(Money>=product.Cost)
			{
				bagOfProducts.Add(product);
				Money-= product.Cost;
				return $"{Name} bought {product.Name}";
			}
			else
			{
				return $"{Name} can't afford {product.Name}";

            }
		}
        public override string ToString()
		{
			string productstring = String.Empty;

			if (bagOfProducts.Any())
			{
				productstring =  $"{String.Join(", ", bagOfProducts.Select(pr => pr.Name))}";
			}
			else
			{
				productstring =  "Nothing bought";
			}

			return $"{Name} - {productstring}";
		}


    }
}

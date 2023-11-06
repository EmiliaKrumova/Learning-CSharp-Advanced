using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Pizza
    {
		private string name;
		private List<Topping> topings;
        private Dough dough;

        public Pizza(string name, Dough dough)
        {
			topings = new List<Topping>();
			Name = name;
			Dough = dough;
            
        }

        public List<Topping> Toppings
		{
			get { return topings; }
			set { topings = value; }
		}


		public string Name
		{
			get { return name; }
			private set 
			{ if(value.Length<1 || value.Length > 15)
				{
					throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
				}
				name = value; 
			}
		}
		

		public Dough Dough
		{
			get { return dough; }
			set { dough = value; }
		}

        public double Callories 
		{ get
			{
				return Dough.CaloriesPerGram + topings.Sum(t => t.ToppingCalories);

				// взимаме от другите 2 класа публичните пропъртите за калории
				// от клас Тесто -> директно пропъртито
				// от клас Добавки -> сумата  от различните добавки
			}
		}
		public void AddToppingToToppingsColection(Topping topping)
		{
			int maxToppings = 10;
			if(topings.Count < maxToppings)
			{
                topings.Add(topping);
			}
			else
			{
				throw new ArgumentException("Number of toppings should be in range [0..10].");
			}
			
		}

        public override string ToString()
        {
			return $"{Name} - {Callories:f2} Calories.";
        }





    }
}

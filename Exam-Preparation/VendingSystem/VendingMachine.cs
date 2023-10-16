using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingSystem
{
    public class VendingMachine
    {
        //        •	ButtonCapacity - int
        //•	Drinks – List<Drink>
        //•	GetCount  - int - returns the number of drinks, available in the Vending machine.
        //The class constructor should receive buttonCapacity, also it should initialize the Drinks with a new instance of the collection.

        public int ButtonCapacity { get; set; }
        public List<Drink> Drinks { get; set; }
        

        public int GetCount=>this.Drinks.Count;
        



        public VendingMachine(int buttonCapacity)
        {
            ButtonCapacity = buttonCapacity;
            Drinks = new List<Drink>();//??????
            
        }

        
        public void AddDrink(Drink drink)
        {
            if (ButtonCapacity > Drinks.Count)
            {
                Drinks.Add(drink);
            }
            
        }
        public bool RemoveDrink(string name )
        {

            Drink drinkToRemove = Drinks.FirstOrDefault(x => x.Name == name);
                if (drinkToRemove!=null)
                {
                    Drinks.Remove(drinkToRemove);
                    return true;
                }
                else
                {
                    return false;
                }

                      
            
        }
        //•	Method GetLongest() – returns the Drink with the biggest value of Volume property
        public Drink GetLongest()
        {
            
                Drink longest = Drinks.OrderByDescending(drink => drink.Volume).FirstOrDefault();
                return longest;
            
            
        }
        //•	Method GetCheapest() – returns the Drink with the lowest value of Price property
        public Drink GetCheapest()
        {
            Drink cheapest = Drinks.OrderBy(dr=>dr.Price).FirstOrDefault();
            return cheapest;
        }

        //•	Method BuyDrink(string name) - returns a string in the format of the overriden ToString() method
        public string BuyDrink(string name)
        {
           Drink buyedDrink= Drinks.FirstOrDefault(dr=>dr.Name==name);
            return buyedDrink.ToString().TrimEnd();
        }

        //•	Method Report() – returns a string in the following format:
        //        o	"Drinks available:
        //{Drink1                //    }//{Drink2//}/

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Drinks available:");
            foreach(Drink drink in Drinks)
            {
                sb.AppendLine(drink.ToString());
            }
            return sb.ToString().TrimEnd();
        }


    }
}

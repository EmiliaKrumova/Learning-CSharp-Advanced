using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private double price;
        protected Cocktail(string cocktailName, string size, double price)
        {
            this.Name = cocktailName;
            this.Size = size;
            this.Price = price;
        }
        public string Name
        {
            get => name;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }

        public string Size { get; private set; }

        public double Price 
        {
            get => price;
            private set  // мейби протектед мейби нот
            {
                if (this.Size == "Large")
                {
                    price = value;
                }
                else if (this.Size == "Middle")
                {
                    double partPrice = value / 3;
                    price = partPrice * 2;
                }
                else if (this.Size == "Small") 
                {
                    price = value / 3;
                }
            }
        }

        public override string ToString()
            => $"{this.Name} ({this.Size}) - {this.Price:f2} lv";
    }
}

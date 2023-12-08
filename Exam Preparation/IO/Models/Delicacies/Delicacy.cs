using ChristmasPastryShop.Models.Delicacies.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Models.Delicacies
{
    public abstract class Delicacy : IDelicacy
    {
        private string name;

        protected Delicacy(string delicacyName, double price)
        {
            this.Name = delicacyName;
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

        public double Price { get; }

        public override string ToString()
            => $"{this.Name} - {this.Price:f2} lv";
    }
}

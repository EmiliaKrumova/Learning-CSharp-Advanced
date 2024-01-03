using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Delicacies
{
    public abstract class Delicacy : IDelicacy
    {
       
        private string name;
        private double price;
        //ctor
        protected Delicacy(string delicacyName, double price)
        {
            this.Name = delicacyName;
            this.price = price;
        }

        public  string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value; }
        }

        public double Price
        {
            get { return price; }
            
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.Price:f2} lv";
        }

    }
}

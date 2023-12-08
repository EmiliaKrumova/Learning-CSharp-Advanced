using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int id;
        private int capacity;
        private IRepository<IDelicacy> delicacies;
        private IRepository<ICocktail> cocktails;
        private double currentBill;
        private double turnover;
    
        //ctor
        public Booth(int boothId, int capacity)
        {
            this.Capacity = capacity;
            this.BoothId = boothId;
            this.delicacies = new DelicacyRepository();
            this.cocktails = new CocktailRepository();
            this.currentBill = 0;
            this.turnover = 0;
          
        }
        public int BoothId { get; private set; }

        public int Capacity 
        {
            get { return capacity; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                capacity = value;
            }

        }

        public IRepository<IDelicacy> DelicacyMenu => this.delicacies;

        public IRepository<ICocktail> CocktailMenu => this.cocktails;

        
       

        public double CurrentBill
        {
            get { return currentBill; }
            private set { currentBill = value; }
        }


        public double Turnover
        {
            get { return turnover; }
            
        }

        public bool IsReserved {get; private set;}

        public void ChangeStatus()
        {
            if(IsReserved)
            {
                this.IsReserved = false;

            }
            else
            {
                this.IsReserved = true;
            }

        }

        public void Charge()
        {
            this.turnover += this.CurrentBill;
            this.CurrentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            this.CurrentBill += amount;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booth: {this.BoothId}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Turnover: {this.Turnover:f2} lv");
            sb.AppendLine("-Cocktail menu:");
            foreach(var coctail in this.CocktailMenu.Models) 
            { sb.AppendLine($"--{ coctail.ToString()}");
            }
            sb.AppendLine("-Delicacy menu:");
            foreach( var item in this.DelicacyMenu.Models ) 
            { 
                sb.AppendLine($"--{item.ToString()}");
            }

            return sb.ToString().Trim();
        }
    }
}

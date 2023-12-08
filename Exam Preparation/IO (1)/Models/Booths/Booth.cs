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
        private int capacity;
        private readonly DelicacyRepository delicacies;
        private readonly CocktailRepository cocktails;
        public Booth(int boothId, int capacity)
        {
            this.BoothId = boothId;
            this.Capacity = capacity;
            this.CurrentBill = 0;
            this.Turnover = 0;
            this.delicacies = new DelicacyRepository();
            this.cocktails = new CocktailRepository();

        }
        public int BoothId { get; }

        public int Capacity 
        {
            get => capacity;
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0!");
                }
                capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu 
            => this.delicacies;

        public IRepository<ICocktail> CocktailMenu 
            => this.cocktails;

        public double CurrentBill { get; private set; }
        

        public double Turnover { get; private set; }
        

        public bool IsReserved { get; private set; }

        public void UpdateCurrentBill(double amount)
            => this.CurrentBill += amount;
        public void Charge()
        {
            this.Turnover += this.CurrentBill;
            this.CurrentBill = 0;
        }

        public void ChangeStatus()
            => this.IsReserved  = !IsReserved;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booth: {this.BoothId}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Turnover: {this.Turnover:f2} lv");
            sb.AppendLine($"-Cocktail menu:");
            foreach (var coctail in this.cocktails.Models)
            {
                sb.AppendLine($"--{coctail}");
            }

            sb.AppendLine($"-Delicacy menu:");
            foreach (var delicacy in this.delicacies.Models)
            {
                sb.AppendLine($"--{delicacies}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}

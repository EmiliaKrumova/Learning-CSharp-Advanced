using BankLoan.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public abstract class Loan : ILoan
    {
        
        private int interestRate; 
        private double amount;
        //ctor
        protected Loan(int interestRate, double amount)
        {
            this.InterestRate = interestRate;
            this.Amount = amount;
        }

        public int InterestRate
        {
            get { return interestRate; }
             private set { interestRate = value; }
        }


        public double Amount
        {
            get { return amount; }
           private set { amount = value; }
        }

    }
}

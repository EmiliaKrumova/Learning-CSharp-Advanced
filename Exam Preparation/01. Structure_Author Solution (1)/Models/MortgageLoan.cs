using System;
using System.Collections.Generic;
using System.Text;

namespace BankLoan.Models
{
    public class MortgageLoan : Loan
    {
        private const int interestRate = 3;
        private const double amount = 50000;

        public MortgageLoan()
            : base(interestRate, amount)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BankLoan.Models
{
    public class StudentLoan : Loan
    {
        private const int interestRate = 1;
        private const double amount = 10000;

        public StudentLoan()
            : base(interestRate, amount)
        {

        }
    }
}

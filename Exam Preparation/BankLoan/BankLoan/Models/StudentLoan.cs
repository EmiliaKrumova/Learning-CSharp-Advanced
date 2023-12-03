using BankLoan.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public class StudentLoan : Loan,ILoan
    {
        private const int defaultInterestRate = 1;
        private const double  defaultAmount = 10000;
        public StudentLoan()
            : base(defaultInterestRate, defaultAmount)
        {
        }
    }
}

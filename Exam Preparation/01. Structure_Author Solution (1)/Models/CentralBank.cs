using System;
using System.Collections.Generic;
using System.Text;

namespace BankLoan.Models
{
    public class CentralBank : Bank
    {
        private const int capacity = 50;

        public CentralBank(string name)
            : base(name, capacity)
        {
        }
    }
}

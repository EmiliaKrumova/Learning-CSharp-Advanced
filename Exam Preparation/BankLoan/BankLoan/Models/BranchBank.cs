﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public class BranchBank : Bank
    {
        private const int defaultCapacity = 25;
        public BranchBank(string name) 
            : base(name, defaultCapacity)
        {
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes
{
    
    public class MyRangeAttribute:MyValidationAttribute
    {
		private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

       
		

		

        public override bool IsValid(object obj)
        {
            if ((int)obj >= minValue && (int)obj <= maxValue)
            {
                return true;
            }
            return false;
        }
    }
}

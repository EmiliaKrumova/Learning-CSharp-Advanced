using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public class StationaryPhone : ICanCall
    {
        public string Calling(string number)
        {
            string stringToReturn = String.Empty;
            if (number.All(char.IsDigit))
            {
                stringToReturn = $"Dialing... {number}";
            }
            else
            {
                stringToReturn = "Invalid number!";
            }
            return stringToReturn;
        }
    }
}

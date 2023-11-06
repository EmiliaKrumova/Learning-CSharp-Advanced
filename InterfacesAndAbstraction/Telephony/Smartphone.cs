using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public class Smartphone : ICanCall, ICanBrowse
    {
        public string Browse(string path)
        {
            bool containsInt = path.Any(char.IsDigit);
            string stringToReturn = String.Empty;
            if (!containsInt)
            {
                stringToReturn = $"Browsing: {path}!";
            }
            else
            {
                stringToReturn = "Invalid URL!";
            }
            return stringToReturn;
        }

        public string Calling(string number)
        {
            // bool isIntString = "your string".All(char.IsDigit)
            string stringToReturn = String.Empty;
            if (number.All(char.IsDigit))
            {
                stringToReturn = $"Calling... {number}";
            }
            else
            {
                stringToReturn = "Invalid number!";
            }
            return stringToReturn;
        }
    }
}

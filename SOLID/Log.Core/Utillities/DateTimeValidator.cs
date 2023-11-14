using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Core.Utillities
{
    public static class DateTimeValidator
    {
        public static bool ValidateDateTimeFormat(string dateTime)
        {
            if(DateTime.TryParseExact(dateTime,"M/dd/yyyy h:mm:ss tt",CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            
            { return true; }
            return false;
        }
    }
}

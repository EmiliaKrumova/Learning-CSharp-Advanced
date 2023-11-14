using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Core.Exceptions
{
    public class InvalidDateTimeFormatException:Exception
    {
        private const string DefaultMessage = "Invalid DateTime format";
        public InvalidDateTimeFormatException()
            : base(DefaultMessage)
        {

        }
        public InvalidDateTimeFormatException(string message)
            : base(message)
        {

        }
    }
}

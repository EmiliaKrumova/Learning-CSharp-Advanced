using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Core.Exceptions
{
    public class EmptyCreatedTimeException:Exception
    {
        private const string DefaultMessage = "Time of message cannot be null or empty";
        public EmptyCreatedTimeException()
            :base(DefaultMessage)
        {
            
        }
        public EmptyCreatedTimeException(string message)
            :base(message)
        {
            
        }
    }
}

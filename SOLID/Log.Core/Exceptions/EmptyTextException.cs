using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Core.Exceptions
{
    public class EmptyTextException:Exception
    {
        private const string DefaultMessage = "Text of message cannot be null or empty";
        public EmptyTextException()
            : base(DefaultMessage)
        {

        }
        public EmptyTextException(string message)
            : base(message)
        {

        }
    }
}

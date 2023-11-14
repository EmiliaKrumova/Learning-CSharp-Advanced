using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Core.Enums
{
    // създавам предварителни стойности за нивото на съобщението - по условие нивата са 5
    public enum ReportLevel
    {
        Info = 0,
        Warning = 1,
        Error = 2,
        Critical = 3,
        Fatal = 4
    }
}

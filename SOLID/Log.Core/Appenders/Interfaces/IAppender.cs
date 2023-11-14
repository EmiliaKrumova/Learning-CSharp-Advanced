using Log.Core.Enums;
using Log.Core.Layots.Interfaces;
using Log.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Core.Appenders.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }
        ReportLevel ReportLevel { get; set; }
        public void Append(Message message);
        public int MessagesAppended { get;}
    }
}

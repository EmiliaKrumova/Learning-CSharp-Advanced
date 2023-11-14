using Log.Core.Appenders.Interfaces;
using Log.Core.Enums;
using Log.Core.Layots.Interfaces;
using Log.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Core.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout,ReportLevel reportLevel = ReportLevel.Info)// задаване в конструктора на дефолтна стойност на репортЛевел(в случая е най-ниската - ИНФО
        {
            ReportLevel = reportLevel;
            Layout = layout;
            
        }
        public ILayout Layout { get; private set; }
        public ReportLevel ReportLevel { get ; set; }

        public int MessagesAppended {get; private set; }

        

        public void Append(Message message)
        {
            Console.WriteLine(string.Format(Layout.Format,message.CreatedTime,message.ReportLevel,message.Text));
            // метод за форматиране по предварително зададен формат string.Format()
            // 1. Задава се външен метод за форматиране (в случая Layout.Format -> идва от интерфейса ILayout и неговите наследници
            // 2.на празните места се подпъхват подадените параметри: дата на съобщението, ниво на съобщението, текст на съобщението
            

            MessagesAppended++;
        }
    }
}

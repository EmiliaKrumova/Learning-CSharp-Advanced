using Log.Core.Appenders.Interfaces;
using Log.Core.Enums;
using Log.Core.Loggers.Interfaces;
using Log.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Core.Loggers
{
    public class Logger : ILogger
    {
        // правя колекция от абстрактен тип IColection,
        // с обекти от тип IAppender и я подавам на конструктора с "params"
        private readonly ICollection<IAppender>appenders;

        // този конструктор ще приема един или няколко обекта от тип IAppender,
        // в зависимост от това колко елемента има в горната колекция
        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }
        public void Info(string dateTime, string message)// този метод ще добавя съобщения от енумерация INFO
        {
            AppendAll(dateTime, message,ReportLevel.Info);
        }

        public void Warning(string dateTime, string message)
        {
            AppendAll(dateTime,message,ReportLevel.Warning);
        }
        public void Error(string dateTime, string message)
        {
            AppendAll(dateTime,message, ReportLevel.Error);
        }
        public void Critical(string dateTime, string message)
        {
            AppendAll(dateTime, message, ReportLevel.Critical);
        }       

        public void Fatal(string dateTime, string message)
        {
            AppendAll(dateTime, message, ReportLevel.Fatal);
        }

        //създавам метод, който ще добавя съобщение за лога,
        //от дата и час,
        //самото съобщение
        //и нивото на съобщението
        //от предварително зададената Енумерация enum ReportLevel
        private void AppendAll(string dateTime, string text,ReportLevel reportLevel)
        {

            Message message = new Message(dateTime, text,reportLevel);
            foreach (var appender in appenders)
            {
                if (message.ReportLevel >= appender.ReportLevel)
                {
                    appender.Append(message);
                }
            }
        }

       
    }
}

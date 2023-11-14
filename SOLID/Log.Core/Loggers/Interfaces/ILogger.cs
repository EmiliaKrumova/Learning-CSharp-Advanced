using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Core.Loggers.Interfaces
{
    public interface ILogger
    {
        // в този интерфейс правим абстрактно функциите на Логъра (Логни нещо...)
        void Info(string dateTime, string message);
        void Warning(string dateTime, string message);
        void Error(string dateTime, string message);
        void Critical(string dateTime, string message);
        void Fatal(string dateTime, string message);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Core.Layots.Interfaces
{
    public interface ILayout// това ще е модел за формата на съобщението, което ще извежда Логъра на Конзолата, Файл и т.н
    {
        string Format {  get; }
    }
}

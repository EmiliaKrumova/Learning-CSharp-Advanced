using Raiding.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();// какво ще прави метода ReadLine()

        //--> възможно е да чете от файл, а не от конзолата например...

        //public string ReadLine() => File.ReadLine();
        

    }
}

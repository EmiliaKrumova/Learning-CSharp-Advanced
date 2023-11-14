using Log.Core.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Core.IO
{
    internal class LogFile : ILogFile
    {
        private string name;
        private string path;
        private string extension;

        public LogFile(string name, string path, string extension)
        {
            this.Name = name;
            this.Path = path;
            this.Extension = extension;
        }

        public string Name { get; private set; }

        public string Extension { get; private set; }

        public string Path { get; private set; }

        public string FullPath => System.IO.Path.GetFullPath($"{Path}/{Name}.{Extension}");

        public int Size => File.ReadAllText(FullPath).Length;
    }
}

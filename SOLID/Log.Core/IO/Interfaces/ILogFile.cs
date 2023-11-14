﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Core.IO.Interfaces
{
    public interface ILogFile
    {
        //   C:/path/nameOfFile.extension
        string Name { get; }
        string Extension { get; }
        string Path { get; }
        string FullPath { get; }
        int Size {  get; }
    }
}

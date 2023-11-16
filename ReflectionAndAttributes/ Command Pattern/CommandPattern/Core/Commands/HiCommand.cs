using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Core.Commands
{
    public class HiCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"You are sexy, {args[0]}";
        }
    }
}

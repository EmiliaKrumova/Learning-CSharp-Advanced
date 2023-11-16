using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] inputInfo = args.Split();
            string commandName = inputInfo[0] +"Command";
            string[] parameters = inputInfo.Skip(1).ToArray();
            //string result = string.Empty;

            Type type = 
                Assembly// от текущия проект
                .GetCallingAssembly()// това се слага заради Джъдж
                .GetTypes()// претърси всички типове на класове
                .Where(t=>t.Name==commandName)// в които името съвпада с името на командата
                .FirstOrDefault();// дай ми първия или null


            if (type == null)
            {
                throw new InvalidOperationException("Invalid command");
            }

            ICommand command = Activator.CreateInstance(type) as ICommand;



           string result = command.Execute(parameters);
            return result;
        }
    }
}

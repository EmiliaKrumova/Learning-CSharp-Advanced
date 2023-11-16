using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            try
            {
                while (true)
                {
                    string input = Console.ReadLine();
                    string result = this.commandInterpreter.Read(input);
                    Console.WriteLine(result);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                
            }
            
            
            
        }
    }
}

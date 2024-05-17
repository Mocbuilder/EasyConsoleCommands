using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleCommands.Commands
{
    internal class CommandFont : ICommand
    {
        public string Name => "font";

        public string HelpText => "font-[name of the font] -> sets the font for the console enviroment";

        public List<Type> ParameterTypes => new List<Type> { typeof(StringInfo) };

        public void Execute(List<VariableInfo> inputParams)
        {
            StringInfo name = inputParams[0] as StringInfo;
            try
            {
                ConsoleHelper.SetCurrentFont(name.Value, 30);
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

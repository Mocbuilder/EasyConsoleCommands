using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleCommands.Commands
{
    internal class CommandClear : ICommand
    {
        public string Name => "clear";

        public string HelpText => "clear -> Clears the console";

        public List<Type> ParameterTypes => new List<Type> ();

        public void Execute(List<VariableInfo> inputParams)
        {
            Console.Clear();
        }
    }
}

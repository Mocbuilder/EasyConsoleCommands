using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleCommands.Commands
{
    internal class CommandExit : ICommand
    {
        public string Name => "exit";

        public string HelpText => "exit -> Quit the application";

        public List<Type> ParameterTypes => new List<Type> ();

        public void Execute(List<VariableInfo> inputParams)
        {
            Environment.Exit(0);
        }
    }
}

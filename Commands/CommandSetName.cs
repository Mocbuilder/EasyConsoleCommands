using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleCommands.Commands
{
    internal class CommandSetName : ICommand
    {
        public string Name => "setname";

        public string HelpText => "setname-[Name of a existing variable]-[New name of that variable] -> Set the name of any existing variable to a new name";

        public List<Type> ParameterTypes => new List<Type> { typeof(StringInfo), typeof(StringInfo) };

        private Framework framework;

        public CommandSetName(Framework inputFramework)
        {
            framework = inputFramework;
        }
        public void Execute(List<VariableInfo> inputParams)
        {
            StringInfo param = inputParams[0] as StringInfo;
            StringInfo param2 = inputParams[1] as StringInfo;

            framework.SetVariableName(param.Value, param2.Value);
            Console.WriteLine($"Variable {param.Value} changed to {param2.Value}");
        }
    }
}

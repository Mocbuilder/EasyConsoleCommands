using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleCommands.Commands
{
    internal class CommandSetValue : ICommand
    {
        public string Name => "setvalue";

        public string HelpText => "setvalue-[Name of existing variable]-[New value] -> Set a new value to an already existing variable. New value must be of the same type as the old value";

        public List<Type> ParameterTypes => new List<Type> { typeof(StringInfo), typeof(StringInfo) };

        private Framework framework;

        public CommandSetValue(Framework inputFramework)
        {
            framework = inputFramework;
        }
        public void Execute(List<VariableInfo> inputParams)
        {
            StringInfo param = inputParams[0] as StringInfo;
            StringInfo param2 = inputParams[1] as StringInfo;

            var oldValue = framework.GetVariable(param.Value).GetValueAsString();
            framework.SetVariableValue(param.Value, param2.Value);
            Console.WriteLine($"Changed {param.Value} = {oldValue} to {param.Value} = {param2.Value}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleCommands.Commands
{
    internal class CommandAdd : ICommand
    {
        public string Name => "add";

        public string HelpText => "add-[First Number]-[Second Number] -> Add the first number to the second number";

        public List<Type> ParameterTypes => new List<Type> {typeof(IntInfo), typeof(IntInfo) };

        public void Execute(List<VariableInfo> inputParams)
        {
            IntInfo param = inputParams[0] as IntInfo;
            IntInfo param2 = inputParams[1] as IntInfo;

            int sumReturn = param.Value + param2.Value;
            Console.WriteLine($"{param.Value} + {param2.Value} = " + sumReturn);

        }
    }
}

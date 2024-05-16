using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleCommands.Commands
{
    internal class CommandSleep : ICommand
    {
        public string Name => "sleep";

        public string HelpText => "sleep-[any valid number] -> wait for specified time in seconds. Mainly used in scripting";

        public List<Type> ParameterTypes => new List<Type> { typeof(IntInfo)};

        public void Execute(List<VariableInfo> inputParams)
        {
            StringInfo param = inputParams[0] as StringInfo;

            if (int.TryParse(param.Value, out int inputTime))
            {
                Thread.Sleep(inputTime * 1000);
            }
            else
            {
                throw new Exception("Invalid number given as parameter");
            }
        }
    }
}

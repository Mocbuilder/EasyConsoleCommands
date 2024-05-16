using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleCommands.Commands
{
    internal class CommandKill : ICommand
    {
        public string Name => "kill";

        public string HelpText => "kill-[Name of any running process] -> Terminates the specified process. Could need Admin priviliges to execute properly";

        public List<Type> ParameterTypes => new List<Type> { typeof(StringInfo)};

        public void Execute(List<VariableInfo> inputParams)
        {
            StringInfo param = inputParams[0] as StringInfo;

            Process[] processCollection = Process.GetProcesses();

            Process foundProcess = Array.Find(processCollection, p => p.ProcessName == param.Value);

            if (foundProcess != null)
            {
                foundProcess.Kill();
                Console.WriteLine("Terminated process: " + foundProcess.ProcessName);
            }
            else
            {
                throw new Exception("Process not found");
            }

        }
    }
}

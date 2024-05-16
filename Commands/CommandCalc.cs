using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleCommands.Commands
{
    internal class CommandCalc : ICommand
    {
        public string Name => "calc";

        public string HelpText => "calc-[type of calculation: add, sub, div, mul]-[first number]-[second number] -> Do some simple calculations with two numbers";

        public List<Type> ParameterTypes => new List<Type> { typeof(StringInfo), typeof(IntInfo), typeof(IntInfo) };

        public void Execute(List<VariableInfo> inputParams)
        {
            StringInfo param = inputParams[0] as StringInfo;
            IntInfo param2 = inputParams[1] as IntInfo;
            IntInfo param3 = inputParams[2] as IntInfo;

            if (param2 == null || param3 == null)
                throw new Exception("Not enough numbers given.");

            switch (param.Value)
            {
                case "add":
                    int sumReturn = param2.Value + param3.Value;
                    Console.WriteLine($"{param2.Value} + {param3.Value} = " + sumReturn);
                    break;
                case "sub":
                    sumReturn = param2.Value - param3.Value;
                    Console.WriteLine($"{param2.Value} - {param3.Value} = " + sumReturn);
                    break;
                case "div":
                    sumReturn = param2.Value / param3.Value;
                    Console.WriteLine($"{param2.Value}/{param3.Value} = " + sumReturn);
                    break;
                case "mul":
                    sumReturn = param2.Value * param3.Value;
                    Console.WriteLine($"{param2.Value}*{param3.Value} = " + sumReturn);
                    break;
                default:
                    throw new Exception("Couldnt calculate");
            }
        }
    }
}

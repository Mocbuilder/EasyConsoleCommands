using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleCommands.Commands
{
    internal class CommandRead : ICommand
    {
        public string Name => "read";

        public string HelpText => "read-[Type of new variable]-[Name of new variable]-[Message to be printed before the input] -> Creates a new variable and puts the next userinput as value, while printing a message to the user";

        public List<Type> ParameterTypes => new List<Type> { typeof(StringInfo), typeof(StringInfo), typeof(StringInfo) };

        private Framework framework;

        public CommandRead(Framework inputFramework)
        {
            framework = inputFramework;
        }
        public void Execute(List<VariableInfo> inputParams)
        {
            StringInfo param = inputParams[0] as StringInfo;
            StringInfo param2 = inputParams[1] as StringInfo;
            StringInfo param3 = inputParams[2] as StringInfo;

            Console.WriteLine(param3.Value);
            string userInput = Console.ReadLine();
            switch (param.Value)
            {
                case "string":
                    framework.AddVariable(new StringInfo(param2.Value, userInput));
                    break;
                case "int":
                    int intValue = Convert.ToInt32(userInput);
                    framework.AddVariable(new IntInfo(param2.Value, intValue));
                    break;
                case "bool":
                    bool boolValue = Convert.ToBoolean(userInput);
                    framework.AddVariable(new BoolInfo(param.Value, boolValue));
                    break;
                default:
                    throw new Exception("Couldnt add new variable");
            }
        }
    }
}

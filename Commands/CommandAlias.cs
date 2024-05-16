using System;
using System.Linq;

namespace EasyConsoleCommands.Commands
{
    internal class CommandAlias : ICommand
    {
        public string Name => "alias";

        public string HelpText => "alias-[Command you want to alias]-[New command] -> Set the keyword for any command";
        public List<Type> ParameterTypes => new List<Type> { typeof(StringInfo), typeof(StringInfo) };

        private Framework framework;

        public CommandAlias(Framework inputFramework)
        {
            framework = inputFramework;
        }

        public void Execute(List<VariableInfo> inputParams)
        {
            StringInfo param = inputParams[0] as StringInfo;
            StringInfo param2 = inputParams[1] as StringInfo;

            var commandToAlias = framework.Commands.FirstOrDefault(x => x.Name == param.Value);
            if (commandToAlias != null)
            {
                framework.CommandAliases[param2.Value] = commandToAlias;
                Console.WriteLine($"Alias '{param2.Value}' for command '{param.Value}' set successfully.");
            }
            else
            {
                throw new Exception($"Unknown command to be aliased: {param.Value}. Type 'help' for a list of commands.");

            }
        }
    }
}

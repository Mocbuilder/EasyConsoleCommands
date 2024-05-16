using System;

namespace EasyConsoleCommands.Commands
{
    internal class CommandGet : ICommand
    {
        public string Name => "get";

        public string HelpText => "get-[variable name] -> print any variable";
        public List<Type> ParameterTypes => new List<Type> { typeof(StringInfo) };

        private Framework framework;

        public CommandGet(Framework framework)
        {
            this.framework = framework;
        }

        public void Execute(List<VariableInfo> inputParams)
        {
            StringInfo param = inputParams[0] as StringInfo;

            VariableInfo variable = framework.GetVariable(param.Value);

            if (variable != null)
            {
                Console.WriteLine($"{variable.Type} {variable.Name} = {variable.GetValueAsString()}");
                return;
            }

            if (variable == null)
            {
                throw new Exception("Variable doesn't exist");
            }

            throw new Exception("Can't get variable. It probably doesnt exist");
        }
    }
}

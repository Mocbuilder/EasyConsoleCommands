using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleCommands.Commands
{
    internal class CommandPrint : ICommand
    {
        public string Name => "print";

        public string HelpText => "print-[Text to be printed or 'var']-[variable name] -> Prints specified text or, if that is var-[any existing variable], prints the value of the variable";

        public List<Type> ParameterTypes => new List<Type> { typeof(StringInfo) };

        private Framework framework;

        public CommandPrint(Framework framework)
        {
            this.framework = framework;
        }
        public void Execute(List<VariableInfo> inputParams)
        {
            StringInfo param = inputParams[0] as StringInfo;
            Console.WriteLine(param.Value);
        } 
    }
}

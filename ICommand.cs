using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleCommands
{
    public interface ICommand
    {
        string Name { get; }
        string HelpText { get; }

        List<Type> ParameterTypes { get; }

        void Execute(List<VariableInfo> inputParams);
    }
}

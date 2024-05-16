using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleCommands
{
    public class CommandInfo
    {
        public string Name { get; set; }
        public Action Action { get; set; }
        public bool HasParameter { get; set; }

        public CommandInfo(string name, Action action, bool hasParameter)
        {
            Name = name;
            Action = action;
            HasParameter = hasParameter;
        }
    }
}

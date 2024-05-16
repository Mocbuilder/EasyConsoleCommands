using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleCommands
{
    public enum VariableType
    {
        String,
        Int,
        Bool,
    }

    public abstract class VariableInfo
    {
        public string Name { get; set; }
        public VariableType Type { get; set; }

        public VariableInfo(VariableType type)
        {
            Type = type;
        }

        public VariableInfo(VariableType type, string name)
        {
            Name = name;
            Type = type;
        }

        public abstract string GetValueAsString();
    }
}

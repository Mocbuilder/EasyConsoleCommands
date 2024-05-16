using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleCommands
{
    public class BoolInfo : VariableInfo
    {
        public bool Value { get; set; }

        public BoolInfo() : base(VariableType.Bool)
        {
        }

        public BoolInfo(string variableName, bool value) : base(VariableType.Bool, variableName)
        {
            Value = value;
        }

        public override string GetValueAsString()
        {
            return Value.ToString();
        }
    }
}

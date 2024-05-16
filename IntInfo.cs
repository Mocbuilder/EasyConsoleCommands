using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleCommands
{
    public class IntInfo : VariableInfo
    {
        public int Value { get; set; }

        public IntInfo() : base(VariableType.Int)
        {
        }

        public IntInfo(string variableName, int value) : base(VariableType.Int, variableName)
        {
            Value = value;
        }

        public override string GetValueAsString()
        {
            return Value.ToString();
        }
    }
}

using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleCommands
{
    public class StringInfo : VariableInfo
    {
        public string Value { get; set; }

        public StringInfo() : base(VariableType.String)
        {
        }

        public StringInfo(string variableName, string value) : base(VariableType.String, variableName)
        {
            Value = value;
        }

        public override string GetValueAsString()
        {
            return Value;
        }
    }
}

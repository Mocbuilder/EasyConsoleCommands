using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleCommands.Commands
{
    internal class CommandVar : ICommand
    {
        public string Name => "var";

        public string HelpText => "var-[type]-[name]-[value] -> Declare a variable as 'string' or 'int'";

        public List<Type> ParameterTypes => new List<Type> { typeof(StringInfo), typeof(StringInfo), typeof(StringInfo) };

        private Framework framework;
        public CommandVar(Framework frm)
        {
            this.framework = frm;
        }
        public void Execute(List<VariableInfo> inputParams)
        {
            StringInfo paramType = inputParams[0] as StringInfo;
            StringInfo paramName = inputParams[1] as StringInfo;

            bool variableExists = false;
            VariableInfo variable = framework.GetVariableOrDefault(paramName.Value);
            if (variable != null)
                throw new Exception("Variable already exists");

            try
            {
                switch (paramType.Value)
                {
                    case "string":
                        StringInfo param3String = inputParams[2] as StringInfo;
                        framework.AddVariable(new StringInfo(paramName.Value, param3String.Value));
                        break;
                    case "int":
                        IntInfo param3Int = inputParams[2] as IntInfo;
                        int newInt = Convert.ToInt32(param3Int.Value);
                        framework.AddVariable(new IntInfo(paramName.Value, newInt));
                        break;
                    case "bool":
                        BoolInfo param3Bool = inputParams[2] as BoolInfo;
                        bool newBool = Convert.ToBoolean(param3Bool.Value);
                        framework.AddVariable(new BoolInfo(paramName.Value, newBool));
                        break;
                    default:
                        throw new Exception("Invalid type");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid type of variable");
            }
        }

    }
}

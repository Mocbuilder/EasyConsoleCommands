using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleCommands.Commands
{
    internal class CommandRm : ICommand
    {
        public string Name => "rm";

        public string HelpText => "rm-[Name of a existing variable] -> Remove any existing variable by name";

        public List<Type> ParameterTypes => new List<Type> { typeof(StringInfo)};

        private Framework framework;
        public CommandRm(Framework inputFramework) 
        {
            framework = inputFramework;
        }

        public void Execute(List<VariableInfo> inputParams)
        {
            StringInfo param = inputParams[0] as StringInfo;

            if (param.Value == "all") 
            {
                ConsoleColor currentColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Do you want to delete all variables ? Enter (y)es or (n)o");
                string askDeletion = Console.ReadLine();

                if(askDeletion != "y" && askDeletion != "n")
                    Console.WriteLine("No valid answer given, therefore defaulting to no");

                if (askDeletion == "y")
                {
                    Console.WriteLine("Deleted all variables: ");
                    foreach (var variable in framework.Variables)
                    {
                        Console.WriteLine("Deleted " + variable.Name);
                    }

                    framework.Variables.Clear();
                }

                if (askDeletion == "n")
                {
                    Console.WriteLine("Stopped command 'rm-all' from executing");
                }

                Console.ForegroundColor = currentColor;
                return;
            }

            try
            {
                framework.DeleteVariable(param.Value);

                ConsoleColor currentColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Deleted {param.Value}");
                Console.ForegroundColor = currentColor;
            }
            catch (Exception ex)
            {
                throw new Exception("Couldnt delete variable: " + ex.Message);
            }
        }
    }
}

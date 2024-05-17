using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleCommands
{
    //just a class to test the program as a consol application
    internal class TestStart
    {
        public static string userInput;
        static void TestMain(string[] args)
        {
            Framework framework = new Framework();
            while (true)
            {
                userInput = Console.ReadLine();
                if (userInput == null)
                {
                    throw new Exception("Input cant be empty");
                }

                framework.Execute(userInput);
            }
        }
    }
}

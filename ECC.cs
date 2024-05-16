using EasyConsoleCommands;

namespace EasyConsoleCommands
{
    public class ECC
    {
        public static string userInput;

        public static void Start()
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleCommands.Commands
{
    internal class CommandHacker : ICommand
    {
        public string Name => "hacker";

        public string HelpText => "hacker-[Any valid 8-bit color] -> Makes you a Master haxxor, in any color you want";

        static int Counter;
        static Random randomPosition = new Random();

        static int flowSpeed = 100;
        static int fastFlow = flowSpeed + 30;
        static int textFlow = flowSpeed + 500;

        static ConsoleColor basecolor = ConsoleColor.Green;
        static ConsoleColor fadedcolor = ConsoleColor.White;

        static string endText = "";

        static char Asciicharacters
        {
            get
            {
                int t = randomPosition.Next(10);

                if (t <= 2) return (char)('0' + randomPosition.Next(10));
                else if (t <= 4) return (char)('a' + randomPosition.Next(26));
                else if (t <= 6) return (char)('A' + randomPosition.Next(26));
                else return (char)randomPosition.Next(32, 127);
            }
        }

        public List<Type> ParameterTypes => new List<Type> { typeof(StringInfo)};

        public void Execute(List<VariableInfo> inputParams)
        {
            StringInfo param = inputParams[0] as StringInfo;

            try
            {
                Dictionary<string, ConsoleColor> colorMap = new Dictionary<string, ConsoleColor>
                {
                { "black", ConsoleColor.Black },
                { "darkblue", ConsoleColor.DarkBlue },
                { "darkgreen", ConsoleColor.DarkGreen },
                { "darkcyan", ConsoleColor.DarkCyan },
                { "darkred", ConsoleColor.DarkRed },
                { "darkmagenta", ConsoleColor.DarkMagenta },
                { "darkyellow", ConsoleColor.DarkYellow },
                { "gray", ConsoleColor.Gray },
                { "darkgray", ConsoleColor.DarkGray },
                { "blue", ConsoleColor.Blue },
                { "green", ConsoleColor.Green },
                { "cyan", ConsoleColor.Cyan },
                { "red", ConsoleColor.Red },
                { "magenta", ConsoleColor.Magenta },
                { "yellow", ConsoleColor.Yellow },
                { "white", ConsoleColor.White }
                };

                if (colorMap.TryGetValue(param.Value.ToLower(), out ConsoleColor color))
                {
                    Console.ForegroundColor = color;
                    basecolor = color;
                }
                else
                {
                    throw new Exception("Invalid color entered");
                    return;
                }
            }
            catch
            {
                throw new Exception("Couldnt hack the Mainframe trough the Firewall-Kernel's Code");
                return;
            }
            Console.WindowLeft = Console.WindowTop = 0;
            Console.WindowHeight = Console.BufferHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.BufferWidth = Console.LargestWindowWidth;
            Console.SetWindowPosition(0, 0);
            Console.CursorVisible = false;

            int width, height;
            int[] y;
            Initialize(out width, out height, out y);

            while (true)
            {
                Counter++;
                ColumnUpdate(width, height, y);
                if (Counter > 3 * flowSpeed)
                    Counter = 0;
            }
        }

        public static int YPositionFields(int yPosition, int height)
        {
            if (yPosition < 0) return yPosition + height;
            else if (yPosition < height) return yPosition;
            else return 0;
        }

        private static void Initialize(out int width, out int height, out int[] y)
        {
            height = Console.WindowHeight;
            width = Console.WindowWidth - 1;
            y = new int[width];
            Console.Clear();

            for (int x = 0; x < width; ++x) { y[x] = randomPosition.Next(height); }
        }

        private static void ColumnUpdate(int width, int height, int[] y)
        {
            int x;
            if (Counter < flowSpeed)
            {
                for (x = 0; x < width; ++x)
                {
                    if (x % 10 == 1) Console.ForegroundColor = fadedcolor;
                    else Console.ForegroundColor = basecolor;

                    Console.SetCursorPosition(x, y[x]);
                    Console.Write(Asciicharacters);

                    if (x % 10 == 9) Console.ForegroundColor = fadedcolor;
                    else Console.ForegroundColor = basecolor;

                    int temp = y[x] - 2;
                    Console.SetCursorPosition(x, YPositionFields(temp, height));
                    Console.Write(Asciicharacters);

                    int temp1 = y[x] - 20;
                    Console.SetCursorPosition(x, YPositionFields(temp1, height));
                    Console.Write(' ');
                    y[x] = YPositionFields(y[x] + 1, height);
                }
            }
            else if (Counter > flowSpeed && Counter < textFlow)
            {
                for (x = 0; x < width; ++x)
                {
                    Console.SetCursorPosition(x, y[x]);
                    if (x % 10 == 9) Console.ForegroundColor = fadedcolor;
                    else Console.ForegroundColor = basecolor;

                    Console.Write(Asciicharacters);

                    y[x] = YPositionFields(y[x] + 1, height);
                }
            }
            else if (Counter > fastFlow)
            {
                for (x = 0; x < width; ++x)
                {
                    Console.SetCursorPosition(x, y[x]);
                    Console.Write(' ');

                    int temp = y[x] - 20;
                    Console.SetCursorPosition(x, YPositionFields(temp, height));
                    Console.Write(' ');

                    if (Counter > fastFlow && Counter < textFlow)
                    {
                        if (x % 10 == 9) Console.ForegroundColor = fadedcolor;
                        else Console.ForegroundColor = basecolor;

                        int temp2 = y[x] - 2;
                        Console.SetCursorPosition(x, YPositionFields(temp2, height));
                        Console.Write(Asciicharacters);
                    }

                    Console.SetCursorPosition(width / 2 - endText.Length / 2, height / 2);
                    Console.Write(endText);
                    y[x] = YPositionFields(y[x] + 1, height);
                }
            }
        }
    }
}

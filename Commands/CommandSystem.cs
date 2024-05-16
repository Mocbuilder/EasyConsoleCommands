using System;
using System.Management;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Win32;

namespace EasyConsoleCommands.Commands
{
    internal class CommandSystem : ICommand
    {
        public string Name => "sys";

        public string HelpText => "sys- [hw -> Get hardware information] " +
        "[os -> Get Operating System information] " +
        "[net -> Get .Net Framework information] " +
        "[programs -> Get all installed programs (from HKEY_LOCAL_MACHINE)]";

        public List<Type> ParameterTypes => new List<Type> { typeof(StringInfo)};

        public void Execute(List<VariableInfo> inputParams)
        {
            StringInfo param = inputParams[0] as StringInfo;

            switch (param.Value)
            {
                case "hw":
                    PrintHW();
                    break;
                case "os":
                    PrintOS();
                    break;
                case "net":
                    PrintNET();
                    break;
                case "programs":
                    RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
                    foreach (string subKeyName in key.GetSubKeyNames())
                    {
                        RegistryKey subKey = key.OpenSubKey(subKeyName);
                        Console.WriteLine($"Installed Program: {subKey.GetValue("DisplayName")}");
                    }
                    break;
                default:
                    throw new Exception("Invalid parameter. Use 'help' command for a list of all commands and parameters");
                    break;
            }
        }

        public void PrintNET()
        {
            Console.WriteLine($"CLR Version: {Environment.Version}");
            Console.WriteLine($"Runtime Directory: {RuntimeEnvironment.GetRuntimeDirectory()}");
        }

        public void PrintOS()
        {
            Console.WriteLine($"OS Version: {Environment.OSVersion}");
            Console.WriteLine($"System Directory: {Environment.SystemDirectory}");
            Console.WriteLine($"User Name: {Environment.UserName}");
            Console.WriteLine($"Machine Name: {Environment.MachineName}");

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            foreach (ManagementObject obj in searcher.Get())
            {
                Console.WriteLine($"Operating System: {obj["Caption"]} {obj["Version"]}");
            }

            searcher = new ManagementObjectSearcher("SELECT LastBootUpTime FROM Win32_OperatingSystem");
            foreach (ManagementObject obj in searcher.Get())
            {
                DateTime lastBootUpTime = ManagementDateTimeConverter.ToDateTime(obj["LastBootUpTime"].ToString());
                Console.WriteLine($"Last Bootup Time: {lastBootUpTime}");
            }

            searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PerfFormattedData_PerfOS_System");
            foreach (ManagementObject obj in searcher.Get())
            {
                ulong systemUpTime = Convert.ToUInt64(obj["SystemUpTime"]);
                TimeSpan uptime = TimeSpan.FromSeconds(systemUpTime);
                Console.WriteLine($"System Up Time: {uptime}");
            }
        }

        public void PrintHW()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            foreach (ManagementObject obj in searcher.Get())
            {
                Console.WriteLine($"Processor: {obj["Name"]}");
            }

            searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
            foreach (ManagementObject obj in searcher.Get())
            {
                Console.WriteLine($"Total RAM: {Convert.ToDouble(obj["TotalPhysicalMemory"]) / (1024 * 1024):F2} MB");
            }

            searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            foreach (ManagementObject obj in searcher.Get())
            {
                Console.WriteLine($"Disk: {obj["Caption"]}, Size: {Convert.ToDouble(obj["Size"]) / (1024 * 1024 * 1024):F2} GB");
            }
        }
    }
}

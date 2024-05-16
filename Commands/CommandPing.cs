using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleCommands.Commands
{
    internal class CommandPing : ICommand
    {
        public string Name => "ping";

        public string HelpText => "ping-[Any valid IPv4 address] -> Pings the specified IP address";

        public List<Type> ParameterTypes => new List<Type> { typeof(StringInfo)};

        public CommandPing() { }
        public void Execute(List<VariableInfo> inputParams)
        {
            StringInfo param = inputParams[0] as StringInfo;

            if (IPAddress.TryParse(param.Value, out IPAddress ipAddress) && ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                Console.WriteLine($"Valid IPv4 address: {ipAddress}");
            }
            else
            {
                throw new Exception("Invalid IPv4 address format");
            }

            try
            {
                Ping pingSender = new Ping();
                PingReply reply = pingSender.Send(ipAddress);

                if (reply.Status == IPStatus.Success)
                {
                    Console.WriteLine($"Ping to {ipAddress} successful. Roundtrip time: {reply.RoundtripTime}ms");
                }
                else
                {
                    Console.WriteLine($"Ping to {ipAddress} failed. Error message: {reply.Status}");
                }
            }
            catch (PingException ex)
            {
                throw new Exception($"Error during ping: {ex.Message}");
            }
        }
    }
}

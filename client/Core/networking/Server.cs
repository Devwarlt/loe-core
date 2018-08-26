using System.Collections.Generic;
using System.Net;

namespace LoESoft.Client.Core.Networking
{
    public class Server
    {
        public static readonly Dictionary<string, Server> GetServers = new Dictionary<string, Server>()
        {
            { "Local Server", new Server("127.0.0.1", 7171) }
        };

        public string Address { get; set; }
        public int Port { get; set; }

        public IPEndPoint RemoteEndPoint { get; set; }

        public Server(string address, int port)
        {
            Address = address;
            Port = port;
            RemoteEndPoint = new IPEndPoint(IPAddress.Parse(address), port);
        }

        public override string ToString() => $"{RemoteEndPoint.Address}:{RemoteEndPoint.Port}";
    }
}

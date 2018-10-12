using System.Collections.Generic;
using System.Net;

namespace LoESoft.Client.Core.Networking
{
    public class Server
    {
        public enum ServerName
        {
            LOCAL
        }

        public static readonly Dictionary<ServerName, Server> GetServers = new Dictionary<ServerName, Server>()
        {
            { ServerName.LOCAL, new Server(Address: "127.0.0.1", Port: 7171) }
        };

        public string Address { get; set; }
        public int Port { get; set; }

        public IPEndPoint RemoteEndPoint { get; set; }

        public Server(string Address, int Port)
        {
            this.Address = Address;
            this.Port = Port;
            RemoteEndPoint = new IPEndPoint(IPAddress.Parse(Address), Port);
        }

        public override string ToString() => $"{RemoteEndPoint.Address}:{RemoteEndPoint.Port}";
    }
}

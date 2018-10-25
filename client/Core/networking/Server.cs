using System.Collections.Generic;
using System.Net;

namespace LoESoft.Client.Core.Networking
{
    public partial class Server
    {
        public static readonly Dictionary<ServerName, Server> GetServers = new Dictionary<ServerName, Server>()
        {
            { ServerName.LOCAL, new Server(Address: "127.0.0.1") }
        };

        public string Address { get; set; }
        public IPEndPoint TcpEndPoint { get; set; }
        public IPEndPoint UdpEndPoint { get; set; }

        public Server(string Address)
        {
            this.Address = Address;

            TcpEndPoint = new IPEndPoint(IPAddress.Parse(Address), 7171);
            UdpEndPoint = new IPEndPoint(IPAddress.Parse(Address), 7271);
        }

        public override string ToString() => Address;
    }
}
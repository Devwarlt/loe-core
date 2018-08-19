using System.Collections.Generic;

namespace LoESoft.Client.Core.networking
{
    public class Server
    {
        public static readonly Dictionary<string, Server> GetServers = new Dictionary<string, Server>()
        {
            { "Test Server", new Server("testing.loesoftgames.ignorelist.com", 7171) },
            { "Local Server", new Server("127.0.0.1", 7171) }
        };

        public string _dns { get; private set; }
        public int _port { get; private set; }

        public Server(string dns, int port)
        {
            _dns = dns;
            _port = port;
        }
    }
}

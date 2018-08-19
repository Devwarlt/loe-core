using System.Collections.Generic;
using System.Net;

namespace LoESoft.Client.Core.networking
{
    public class Server
    {
        public static readonly Dictionary<string, IPEndPoint> GetServers = new Dictionary<string, IPEndPoint>()
        {
            { "Test Server", new IPEndPoint(IPAddress.Parse("testing.loesoftgames.ignorelist.com"), 7171) }
        };
    }
}

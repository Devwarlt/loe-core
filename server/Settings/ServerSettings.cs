using System.Net;

namespace LoESoft.Server.Settings
{
    public static class ServerSettings
    {
        public static IPEndPoint ServerEndPoint = new IPEndPoint(IPAddress.Any, 6969);
    }
}
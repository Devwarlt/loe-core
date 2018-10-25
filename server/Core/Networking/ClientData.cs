using System.Net;
using System.Net.Sockets;

namespace LoESoft.Server.Core.Networking
{
    public class ClientData
    {
        public Socket TcpSocket { get; set; }
        public UdpClient UdpClient { get; set; }

        public bool ContainsTcpEp(EndPoint endPoint) => TcpSocket.RemoteEndPoint == endPoint;

        public bool ContainsUdpEp(EndPoint endPoint) => UdpClient.Client.RemoteEndPoint == endPoint;
    }
}
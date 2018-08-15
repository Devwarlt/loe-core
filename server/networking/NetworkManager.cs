using System.Net.Sockets;

namespace LoESoft.Server.networking
{
    public class NetworkManager
    {
        private Socket _socket { get; set; }

        public NetworkManager()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
    }
}

using LoESoft.Server.networking;
using System.Net.Sockets;

namespace LoESoft.Server.client
{
    public class Client
    {
        public Socket _socket { get; private set; }

        private NetworkHandler _networkHandler { get; set; }

        public Client(Socket socket)
        {
            _socket = socket;
            _networkHandler = new NetworkHandler(this);
            _networkHandler.Start();
        }
    }
}

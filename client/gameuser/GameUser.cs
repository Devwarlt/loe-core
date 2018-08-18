using System.Net.Sockets;

namespace LoESoft.Client.gameuser
{
    public class GameUser
    {
        public Socket _socket { get; private set; }

        public GameUser()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
    }
}

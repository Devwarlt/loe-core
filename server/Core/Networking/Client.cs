using LoESoft.Server.Core.Networking.Packets.Incoming;
using System.Net.Sockets;

namespace LoESoft.Server.Core.Networking
{
    public class Client
    {
        public Socket Socket { get; set; }
        public NetworkControl NetworkControl { get; set; }
        public string IpAddress { get; set; }

        public Client(Socket socket)
        {
            Socket = socket;

            IpAddress = socket.RemoteEndPoint.ToString();

            NetworkControl = new NetworkControl(this, Socket);
            NetworkControl.ReceivePacket();

            NetworkControl.SendPacket(new PingPacket(1500));
        }

        public void Disconnect()
        {
            //remove from connected instance
            Socket.Close();
        }
    }
}

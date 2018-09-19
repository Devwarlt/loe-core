using LoESoft.Server.Core.Networking.Packets.Incoming;
using LoESoft.Server.Core.Networking.Packets.Outgoing;
using LoESoft.Server.Core.World.Entities.Player;
using System.Net.Sockets;

namespace LoESoft.Server.Core.Networking
{
    public class Client
    {
        public Socket Socket { get; set; }
        public NetworkControl NetworkControl { get; set; }

        public Player Player { get; private set; }

        public string IpAddress { get; set; }

        public Client(Socket socket)
        {
            Socket = socket;

            IpAddress = socket.RemoteEndPoint.ToString();

            NetworkControl = new NetworkControl(this, Socket);
            NetworkControl.ReceivePacket();

            Player = new Player(this);

            NetworkControl.SendPacket(new PingPacket(1500));
        }

        public void SendPacket(OutgoingPacket pkt) => NetworkControl.SendPacket(pkt);

        public void Disconnect()
        {
            //remove from connected instance
            Player.Dispose();
            Socket.Close();
        }
    }
}

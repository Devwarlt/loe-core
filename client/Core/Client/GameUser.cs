using LoESoft.Client.Core.Networking;
using LoESoft.Client.Core.Networking.Packets.Outgoing;

namespace LoESoft.Client.Core.Client
{
    public class GameUser
    {
        public Server Server { get; set; }
        public NetworkControl NetworkControl { get; set; }

        public GameUser(Server server)
        {
            Server = server;
            NetworkControl = new NetworkControl(this);
        }

        public bool IsConnected => NetworkControl.IsConnected;

        public void SendPacket(OutgoingPacket outgoingPacket) => NetworkControl.SendPacket(outgoingPacket);

        public void SendPackets(OutgoingPacket[] outgoingPackets) => NetworkControl.SendPackets(outgoingPackets);

        public void Connect() => NetworkControl.Connect(Server);

        public void Disconnect() => NetworkControl.Disconnect();
    }
}

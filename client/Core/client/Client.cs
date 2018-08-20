using LoESoft.Client.Core.networking;
using LoESoft.Client.Core.networking.packets;
using LoESoft.Client.Core.utils;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace LoESoft.Client.Core.client
{
    public class GameUser
    {
        public Socket _socket { get; private set; }

        private NetworkHandler _networkHandler { get; set; }

        public GameUser(Socket socket, Server server)
        {
            _socket = socket;
            _networkHandler = new NetworkHandler(this, server);
        }

        public void SendPacket(Packet packet)
        {
            _socket.Send(Encoding.UTF8.GetBytes(IO.ExportPacket(new PacketData()
            {
                PacketID = packet.ID,
                Content = Regex.Replace(packet.ToString(), @"\r\n?|\n", string.Empty)
            })));
            _networkHandler.HandlePacket();
        }
    }
}

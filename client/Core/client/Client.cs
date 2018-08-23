using LoESoft.Client.Core.networking;
using LoESoft.Client.Core.networking.packet;
using LoESoft.Client.Core.networking.packet.server;
using LoESoft.Client.Core.utils;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace LoESoft.Client.Core.client
{
    internal class GameUser
    {
        public Socket _socket { get; private set; }
        public ConcurrentQueue<ServerPacket> _pendingPacket { get; private set; }

        private NetworkHandler _networkHandler { get; set; }

        public GameUser(Socket socket, Server server)
        {
            _socket = socket;
            _pendingPacket = new ConcurrentQueue<ServerPacket>();
            _networkHandler = new NetworkHandler(this, server);
            _networkHandler.Start();
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

        public void SendPackets(IEnumerable<Packet> packets)
        {
            foreach (var packet in packets)
                SendPacket(packet);
        }
    }
}

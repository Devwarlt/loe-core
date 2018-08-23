﻿using LoESoft.Client.Core.Networking;
using LoESoft.Client.Core.Networking.Packets;
using LoESoft.Client.Core.Networking.Packets.Server;
using LoESoft.Client.Core.Utils;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace LoESoft.Client.Core.Client
{
    public class GameUser
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

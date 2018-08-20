﻿using LoESoft.Server.Core.networking;
using LoESoft.Server.Core.networking.packet;
using LoESoft.Server.Core.networking.packet.client;
using LoESoft.Server.utils;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace LoESoft.Server.Core.client
{
    internal class Client : IDisposable
    {
        public Socket _socket { get; private set; }
        public string _ip { get; private set; }
        public ConcurrentQueue<ClientPacket> _pendingPacket { get; private set; }
        public NetworkHandler _networkHandler { get; internal set; }

        public Client(Socket socket)
        {
            _socket = socket;
            _socket.NoDelay = true;
            _socket.UseOnlyOverlappedIO = true;
            _socket.SendTimeout = 1000;
            _socket.ReceiveTimeout = 1000;
            _socket.Ttl = 112;
            _ip = socket.RemoteEndPoint.ToString().Split(':')[0];

            GameServer._log.Warn($"New client with IP '{_ip}' has been connected!");

            _pendingPacket = new ConcurrentQueue<ClientPacket>();
            _networkHandler = new NetworkHandler(this);
            _networkHandler.Start();
        }

        public void SendPacket(Packet packet)
        {
            byte[] dataBuff = Encoding.UTF8.GetBytes(IO.ExportPacket(new PacketData()
            {
                PacketID = packet.ID,
                Content = Regex.Replace(packet.ToString(), @"\r\n?|\n", string.Empty)
            }));
            _socket.BeginSend(dataBuff, 0, dataBuff.Length, SocketFlags.None, new AsyncCallback(_networkHandler.SendCallback), _socket);
            _socket.BeginReceive(NetworkHandler._buffer, 0, NetworkHandler._buffer.Length, SocketFlags.None, new AsyncCallback(_networkHandler.ReceiveCallback), _socket);
        }

        public void SendPackets(IEnumerable<Packet> packets)
        {
            foreach (var packet in packets)
                SendPacket(packet);
        }

        public void Dispose()
        {
            _socket.Close();
            _socket.Dispose();
        }
    }
}

﻿using LoESoft.Server.Core.Networking.Packets.Incoming;
using LoESoft.Server.Core.Networking.Packets.Outgoing;
using LoESoft.Server.Core.World.Entities.Player;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;

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

            IpAddress = socket.RemoteEndPoint.ToString().Split(':')[0];

            GameServer.Warn($"Client with IP '{IpAddress}' has connected!");

            NetworkControl = new NetworkControl(this, Socket);
            NetworkControl.ReceivePacket();

            Player = new Player(this);

            var value = new Random().Next();

            GameServer.Info($"Server is sending value '{value}' via Ping packet.");

            SendPacket(new Ping() { Value = value });
        }

        public bool IsConnected => NetworkControl.IsConnected;

        /// <summary>
        /// This method block current thread work until action is completed synchronously or when timeout in milliseconds is declared.
        /// </summary>
        /// <param name="outgoingPacket"></param>
        public void SendSyncPacket(OutgoingPacket outgoingPacket) => ((IAsyncResult)Task.Run(() => SendPacket(outgoingPacket))).AsyncWaitHandle.WaitOne();

        public void SendSyncPacket(OutgoingPacket outgoingPacket, int timeout) => ((IAsyncResult)Task.Run(() => SendPacket(outgoingPacket))).AsyncWaitHandle.WaitOne(timeout, true);

        public void SendSyncPackets(OutgoingPacket[] outgoingPackets) => ((IAsyncResult)Task.Run(() => SendPackets(outgoingPackets))).AsyncWaitHandle.WaitOne();

        public void SendSyncPackets(OutgoingPacket[] outgoingPackets, int timeout) => ((IAsyncResult)Task.Run(() => SendPackets(outgoingPackets))).AsyncWaitHandle.WaitOne(timeout, true);

        /// <summary>
        /// Regular send packet method.
        /// </summary>
        /// <param name="outgoingPacket"></param>
        public void SendPacket(OutgoingPacket outgoingPacket) => NetworkControl.SendPacket(outgoingPacket);

        public void SendPackets(OutgoingPacket[] outgoingPackets) => NetworkControl.SendPackets(outgoingPackets);

        public void Disconnect()
        {
            Player.Dispose();
            Socket.Close();
        }
    }
}

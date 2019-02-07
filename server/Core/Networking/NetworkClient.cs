using LoESoft.Server.Core.Database.Models;
using LoESoft.Server.Core.Networking.Packets.Incoming;
using LoESoft.Server.Core.Networking.Packets.Outgoing;
using LoESoft.Server.Core.World;
using LoESoft.Server.Core.World.Entities.Player;
using System;
using System.IO;
using System.Net.Sockets;

namespace LoESoft.Server.Core.Networking
{
    public class NetworkClient
    {
        public static int MaxBufferSize = 10000;

        public int ClientId { get; set; }
        public string IpAdress { get; set; }

        protected byte[] MessageBuffer;

        protected Socket ClientSocket { get; set; }

        protected bool Disposed { get; set; }

        public Player Player { get; set; }
        public Account Account { get; set; }
        public WorldManager Manager { get; set; }

        public NetworkClient(Socket skt, WorldManager manager)
        {
            ClientSocket = skt;
            Manager = manager;

            Disposed = false;
        }

        #region send/recieve

        public void Start()
        {
            beginRecieve();
        }

        private void onPacketProcessed(byte[] buffer)
        {
            if (Disposed)
                return;

            if (!ClientSocket.Connected)
            {
                Disconnect();
                return;
            }

            try { ClientSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, onPacketSend, ClientSocket); }
            catch { Disconnect(); }
        }

        private void onPacketSend(IAsyncResult result)
        {
            //To something
        }

        private void beginRecieve()
        {
            if (Disposed)
                return;

            if (!ClientSocket.Connected)
            {
                Disconnect();
                return;
            }

            MessageBuffer = new byte[MaxBufferSize];

            ClientSocket.BeginReceive(MessageBuffer, 0, MessageBuffer.Length, SocketFlags.None, onRecieve, ClientSocket);
        }

        private void onRecieve(IAsyncResult result)
        {
            try
            {
                var length = ClientSocket.EndReceive(result) - 1;
                var buffer = new byte[length];
                var packetID = MessageBuffer[0];

                Buffer.BlockCopy(MessageBuffer, 1, buffer, 0, buffer.Length);

                var packet = IncomingPacket.IncomingPackets[packetID];

                using (var nr = new NetworkReader(new MemoryStream(buffer)))
                    packet.Read(nr);

                packet.Handle(this);
                beginRecieve();
            }
            catch
            {
                if (!ClientSocket.Connected)
                    Disconnect();
            }
        }

        public void SendPacket(OutgoingPacket packet)
        {
            if (!Disposed)
                NetworkProccessor.ProcessPacket(new NPacket()
                {
                    Packet = packet,
                    OnPacketProcessed = onPacketProcessed
                });
        }

        #endregion send/recieve

        public void Disconnect()
        {
            Disposed = true;
            ClientSocket.Disconnect(false);
            ClientSocket.Dispose();
            Player?.Dispose();
        }
    }
}
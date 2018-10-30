using LoESoft.Server.Core.Database.Models;
using LoESoft.Server.Core.Networking.Packets.Outgoing;
using LoESoft.Server.Core.World;
using LoESoft.Server.Core.World.Entities.Player;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace LoESoft.Server.Core.Networking
{
    public class Client
    {
        public static int LatestId = 0;

        public int Id { get; set; }
        public Account Account { get; set; }
        public Socket TcpSocket { get; set; }
        public NetworkControl NetworkControl { get; set; }
        public string IpAddress { get; set; }
        public WorldManager Manager { get; private set; }
        public Player Player { get; set; }

        public Client(WorldManager manager) => Manager = manager;

        public void Handle()
        {
            IpAddress = TcpSocket.RemoteEndPoint.ToString().Split(':')[0];

            App.Info($"Client with IP '{IpAddress}' has connected!");

            NetworkControl = new NetworkControl(this, TcpSocket);
            NetworkControl.ReceivePacket();
        }

        public void Disconnect() => NetworkControl.Disconnect();

        public bool IsConnected => NetworkControl.IsConnected;

        public void SendSyncPacket(OutgoingPacket outgoingPacket) => ((IAsyncResult) Task.Run(() => SendPacket(outgoingPacket))).AsyncWaitHandle.WaitOne();

        public void SendSyncPacket(OutgoingPacket outgoingPacket, int timeout) => ((IAsyncResult) Task.Run(() => SendPacket(outgoingPacket))).AsyncWaitHandle.WaitOne(timeout, true);

        public void SendSyncPackets(OutgoingPacket[] outgoingPackets) => ((IAsyncResult) Task.Run(() => SendPackets(outgoingPackets))).AsyncWaitHandle.WaitOne();

        public void SendSyncPackets(OutgoingPacket[] outgoingPackets, int timeout) => ((IAsyncResult) Task.Run(() => SendPackets(outgoingPackets))).AsyncWaitHandle.WaitOne(timeout, true);

        public void SendPacket(OutgoingPacket outgoingPacket) => NetworkControl.SendPacket(outgoingPacket);

        public void SendPackets(OutgoingPacket[] outgoingPackets) => NetworkControl.SendPackets(outgoingPackets);
    }
}
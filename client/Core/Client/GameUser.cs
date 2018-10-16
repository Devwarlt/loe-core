using LoESoft.Client.Core.Networking;
using LoESoft.Client.Core.Networking.Packets.Outgoing;
using System;
using System.Threading.Tasks;

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

        public void Connect() => NetworkControl.Connect(Server);

        public void Disconnect() => NetworkControl.Disconnect();
    }
}
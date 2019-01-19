using LoESoft.Client.Core.Networking.Packets.Incoming;
using LoESoft.Client.Core.Networking.Packets.Outgoing;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace LoESoft.Client.Core.Networking
{
    public static class NetworkClient
    {
        public static int MaxBufferSize = 10000;

        public static byte[] MessageBuffer;

        private static bool Disposed { get; set; }

        private static Socket ClientSocket { get; set; }
        private static NetworkProcessor PacketProcessor { get; set; }

        static NetworkClient()
        {
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            {
                NoDelay = true
            };
            PacketProcessor = new NetworkProcessor();

            Disposed = false;
        }

        public static void Listen()
        {
            ClientSocket.BeginConnect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6969), onConnect, ClientSocket);
        }

        private static void onConnect(IAsyncResult result)
        {
            if (result == null)
            {
                App.Warn("Failed to connect! retrying in 3 seconds!");
                Thread.Sleep(3000);
                Listen();
            }

            ClientSocket.EndConnect(result);

            App.Info("Connection to the server has been established!");
            
            PacketProcessor.OnPacketProcessed = onPacketProcessed;
            beginRecieve();
        }

        private static void onPacketProcessed(byte[] buffer)
        {
            if (Disposed)
                return;

            if (!ClientSocket.Connected)
            {
                App.Warn("Client suddenly lost connection to the server! Retrying!");
                Listen();
            }
            
            ClientSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, onSend, ClientSocket);
        }

        private static void onSend(IAsyncResult result)
        {
        }
        
        private static void beginRecieve()
        {
            if (Disposed)
                return;

            if (!ClientSocket.Connected)
            {
                App.Warn("Client suddenly lost connection to the server! Retrying!");
                Listen();
            }

            MessageBuffer = new byte[MaxBufferSize];

            ClientSocket.BeginReceive(MessageBuffer, 0, MessageBuffer.Length, SocketFlags.None, onRecieve, ClientSocket);
        }

        private static void onRecieve(IAsyncResult result)
        {
            try
            {
                var length = ClientSocket.EndReceive(result);
                var buffer = new byte[length - 1];
                var packetID = MessageBuffer[0];

                Buffer.BlockCopy(MessageBuffer, 1, buffer, 0, buffer.Length);

                var packet = IncomingPacket.IncomingPackets[packetID];

                using (var nr = new NetworkReader(new MemoryStream(buffer)))
                    packet.Read(nr);

                packet.Handle();
                beginRecieve();
            } catch
            {
                if (!ClientSocket.Connected)
                    Dispose();
            }
        }

        public static void SendPacket(OutgoingPacket packet) => PacketProcessor.ProcessPacket(packet);

        public static void Dispose()
        {
            Disposed = true;
            if (ClientSocket.Connected)
                ClientSocket.Disconnect(false);
            ClientSocket.Dispose();
        }
    }
}

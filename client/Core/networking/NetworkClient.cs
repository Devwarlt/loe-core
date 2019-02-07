using LoESoft.Client.Core.Networking.Packets.Incoming;
using LoESoft.Client.Core.Networking.Packets.Outgoing;
using System;
using System.Collections.Concurrent;
using System.IO;
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

        private static ConcurrentQueue<byte[]> MissingOutgoingPackets
            = new ConcurrentQueue<byte[]>();

        private static ManualResetEvent AwaitPendingPackets = new ManualResetEvent(true);

        static NetworkClient()
        {
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            {
                NoDelay = true
            };
            PacketProcessor = new NetworkProcessor();

            Disposed = false;
        }

        public static void Connect(bool pendingPackets = false)
        {
            try
            {
                ClientSocket.BeginConnect("127.0.0.1", 6969, (result) =>
                {
                    if (result != null && ClientSocket.Connected)
                    {
                        ClientSocket.EndConnect(result);

                        App.Info("Connection to the server has been established!");

                        PacketProcessor.OnPacketProcessed = onPacketProcessed;

                        if (pendingPackets)
                            ProcessPengingPackets();

                        AwaitPendingPackets.WaitOne();

                        beginReceive();

                        return;
                    }
                }, null);
            }
            catch
            {
                App.Warn("Failed to connect! retrying in 3 seconds...");

                Thread.Sleep(3000);

                Connect();
            }
        }

        private static void onPacketProcessed(byte[] buffer)
        {
            if (Disposed)
                return;

            if (!ClientSocket.Connected)
            {
                App.Warn("Connection lost! Retrying...");

                AwaitPendingPackets.Reset();

                Connect(true);

                return;
            }

            AwaitPendingPackets.WaitOne();

            ClientSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, null, null);
        }

        private static void ProcessPengingPackets()
        {
            do
            {
                MissingOutgoingPackets.TryDequeue(out byte[] packet);
                ClientSocket.BeginSend(packet, 0, packet.Length, SocketFlags.None, null, null);
            } while (MissingOutgoingPackets.Count > 0);

            AwaitPendingPackets.Set();
        }

        private static void beginReceive()
        {
            if (Disposed)
                return;

            if (!ClientSocket.Connected)
            {
                App.Warn("Connection lost! Retrying...");

                Connect();

                return;
            }

            MessageBuffer = new byte[MaxBufferSize];

            ClientSocket.BeginReceive(MessageBuffer, 0, MessageBuffer.Length, SocketFlags.None, (result) =>
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
                    beginReceive();
                }
                catch
                {
                    if (!ClientSocket.Connected)
                        Dispose();
                }
            }, null);
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
using LoESoft.Server.Core.Networking.Packets.Outgoing;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;

namespace LoESoft.Server.Core.Networking
{
    public class NPacket
    {
        public delegate void packetProcessed(byte[] buffer);
        public packetProcessed OnPacketProcessed { get; set; }

        public OutgoingPacket Packet { get; set; }
    }
    public static class NetworkProccessor
    {
        public static Thread ProcesserThread;

        public static ConcurrentQueue<NPacket> PendingPackets { get; private set; }

        public static bool Stopped { get; private set; }
        
        static NetworkProccessor()
        {
            PendingPackets = new ConcurrentQueue<NPacket>();
            Stopped = false;

            ProcesserThread = new Thread(() =>
            {
                while(!Stopped)
                {
                    if (PendingPackets.TryDequeue(out var npacket))
                    {
                        var ms = new MemoryStream();
                        using (var wtr = new NetworkWriter(ms))
                        {
                            npacket.Packet.Write(wtr);

                            var length = (int)ms.Position;
                            var rawBuffer = new byte[length + 1];
                            
                            rawBuffer[0] = (byte)npacket.Packet.PacketID;
                            
                            var msBuffer = ms.GetBuffer();

                            Array.Resize(ref msBuffer, length);
                            Buffer.BlockCopy(msBuffer, 0, rawBuffer, 1, msBuffer.Length);

                            npacket.OnPacketProcessed.Invoke(rawBuffer);

                            npacket = null;
                        }
                    }
                }
            });

            ProcesserThread.IsBackground = true;
        }

        public static void Start() => ProcesserThread.Start();

        public static void Stop() => Stopped = true;
        public static void Resume() => Stopped = false;

        public static void ProcessPacket(NPacket packet)
        {
            PendingPackets.Enqueue(packet);
        }
    }
}

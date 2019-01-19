using LoESoft.Client.Core.Networking.Packets.Outgoing;
using System;
using System.IO;

namespace LoESoft.Client.Core.Networking
{
    public class NetworkProcessor
    {
        public delegate void packetProcessed(byte[] buffer);
        public packetProcessed OnPacketProcessed { get; set; }

        public void ProcessPacket(OutgoingPacket packet)
        {
            var ms = new MemoryStream();
            using (var wtr = new NetworkWriter(ms))
            {
                packet.Write(wtr);

                var length = (int)ms.Position;
                var rawBuffer = new byte[length + 1];

                rawBuffer[0] = (byte)packet.PacketID;

                var msBuffer = ms.GetBuffer();

                Array.Resize(ref msBuffer, length);
                Buffer.BlockCopy(msBuffer, 0, rawBuffer, 1, msBuffer.Length);

                OnPacketProcessed.Invoke(rawBuffer);
            }
        }
    }
}

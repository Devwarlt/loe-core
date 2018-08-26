using LoESoft.Client.Core.Networking.Packets.Client.Packets;
using System;

namespace LoESoft.Client.Core.Networking.Packets.Server.Packets
{
    internal class Pong : ServerPacket
    {
        public int Value { get; set; }

        public override PacketID ID => PacketID.PONG;

        public override Packet CreateInstance() => new Pong();
    }

    internal class PongHandler : PacketHandler<Pong>
    {
        public override PacketID ID => PacketID.PONG;

        protected override void HandlePacket(Core.Client.GameUser gameUser, Pong packet)
        {
            gameUser.SendPacket(new Ping()
            {
                Value = new Random().Next(0, 100)
            });
        }
    }
}

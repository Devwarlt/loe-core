using LoESoft.Client.Core.client;
using LoESoft.Client.Core.networking.packet.client.packets;
using System;

namespace LoESoft.Client.Core.networking.packet.server.packets
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

        protected override void HandlePacket(GameUser gameUser, Pong packet)
        {
            gameUser.SendPacket(new Ping()
            {
                Value = new Random().Next(0, 100)
            });
        }
    }
}

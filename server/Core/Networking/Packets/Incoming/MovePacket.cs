﻿namespace LoESoft.Server.Core.Networking.Packets.Incoming
{
    public class MovePacket : IncomingPacket
    {
        public override PacketID PacketID => PacketID.MOVE;

        public int Value { get; set; }

        public override void Handle(Client client)
        {
            GameServer.Info($"{Value}");
        }
    }
}

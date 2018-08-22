﻿using LoESoft.Server.Core.client;
using LoESoft.Server.Core.networking.packet.server.packets;
using System;

namespace LoESoft.Server.Core.networking.packet.client.packets
{
    internal class Ping : ClientPacket
    {
        public int Value { get; set; }

        public override PacketID ID => PacketID.PING;

        public override Packet CreateInstance() => new Ping();
    }

    internal class PingHandler : PacketHandler<Ping>
    {
        public override PacketID ID => PacketID.PING;

        protected override void HandlePacket(Client client, Ping packet)
        {
            client.SendPacket(new Pong()
            {
                Value = new Random().Next(0, 100)
            });
        }
    }
}
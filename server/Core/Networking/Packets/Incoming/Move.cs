﻿namespace LoESoft.Server.Core.Networking.Packets.Incoming
{
    public class Move : IncomingPacket
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override PacketID PacketID => PacketID.MOVE;

        public override void Handle(Client client)
        {
            if (client.Player == null)
                return;

            client.Player.X = X;
            client.Player.Y = Y;

            client.Manager.Map.RepositionPlayer(client.Player, X, Y);
        }
    }
}

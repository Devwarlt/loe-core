using LoESoft.Server.Core.World;

namespace LoESoft.Server.Core.Networking.Packets.Incoming
{
    public class Move : IncomingPacket
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override PacketID PacketID => PacketID.MOVE;

        public override void Handle(Client client)
        {
            client.Player.X = X;
            client.Player.Y = Y;

            WorldManager.Map.RepositionPlayer(client.Player, X, Y);
        }
    }
}

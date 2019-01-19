using LoESoft.Server.Core.Networking.Packets.Outgoing;
using LoESoft.Server.Core.World;
using LoESoft.Server.Utils;

namespace LoESoft.Server.Core.Networking.Packets.Incoming
{
    public class ClientMove : IncomingPacket
    {
        public int Direction { get; set; }

        public override PacketID PacketID => PacketID.CLIENTMOVE;

        public override void Read(NetworkReader reader)
        {
            Direction = reader.ReadInt32();
        }

        public override void Handle(NetworkClient client)
        {
            switch (Direction)
            {
                case 0: RepositionPlayer(client, client.Player.X, client.Player.Y - 1); return;
                case 1: RepositionPlayer(client, client.Player.X, client.Player.Y + 1); return;
                case 2: RepositionPlayer(client, client.Player.X - 1, client.Player.Y); return;
                case 3: RepositionPlayer(client, client.Player.X + 1, client.Player.Y); return;
            }
        }

        private void RepositionPlayer(NetworkClient client, int newX, int newY)
        {
            if (client.Player == null)
                return;

            if (newX >= 0 && newX <= WorldMap.WIDTH && newY >= 0 && newY <= WorldMap.HEIGHT)
            {
                client.Player.Move(newX, newY);
                client.Player.Direction = (Direction)Direction;
            }

            client.SendPacket(new ServerMove()
            {
                X = client.Player.X,
                Y = client.Player.Y
            });
        }
    }
}
using LoESoft.Server.Core.Networking.Packets.Outgoing;
using LoESoft.Server.Core.World;
using System;

namespace LoESoft.Server.Core.Networking.Packets.Incoming
{
    public class ClientMove : IncomingPacket
    {
        public int Direction { get; set; }

        public override PacketID PacketID => PacketID.CLIENTMOVE;

        public override void Handle(Client client)
        {
            switch (Direction)
            {
                case 1:
                    RepositionPlayer(client, client.Player.X, client.Player.Y - 1);
                    return;

                case 2:
                    RepositionPlayer(client, client.Player.X, client.Player.Y + 1);
                    return;

                case 3:
                    RepositionPlayer(client, client.Player.X - 1, client.Player.Y);
                    return;

                case 4:
                    RepositionPlayer(client, client.Player.X + 1, client.Player.Y);
                    return;

                default:
                    return;
            }
        }
        
        private void RepositionPlayer(Client client, int newX, int newY)
        {
            if (client.Player == null)
                return;

            if (newX < 0 || newX >= WorldMap.WIDTH || newY < 0 || newY >= WorldMap.HEIGHT)
                client.Player.Move(newX, newY);
            
            client.SendPacket(new ServerMove()
            {
                X = client.Player.X,
                Y = client.Player.Y
            });
        }
    }
}
using LoESoft.Server.Core.Networking.Packets.Outgoing;
using LoESoft.Server.Core.World.Map;

namespace LoESoft.Server.Core.Networking.Packets.Incoming
{
    public class ClientMove : IncomingPacket
    {
        /*
            None = 0, //This value will never be recieved
            Up = 1,
            Down = 2,
            Left = 3,
            Right = 4
         * */
        public int Direction { get; set; }

        public override PacketID PacketID => PacketID.CLIENTMOVE;

        public override void Handle(Client client)
        {
            switch (Direction)
            {
                case 1: RepositionPlayer(client, client.Player.X, client.Player.Y - 1); return;
                case 2: RepositionPlayer(client, client.Player.X, client.Player.Y + 1); return;
                case 3: RepositionPlayer(client, client.Player.X - 1, client.Player.Y); return;
                case 4: RepositionPlayer(client, client.Player.X + 1 , client.Player.Y); return;
                default: return;
            }
        }

        //Repositions player and sends back a server move packet once it's done
        private void RepositionPlayer(Client client, int newX, int newY)
        {
            if (client == null)
                return;

            if (client.Player == null)
                return;
            
            if (client.Manager.Map.IsValidChunk(newX, newY))
            {
                client.Player.X = newX;
                client.Player.Y = newY;
            }

            client.SendPacket(new ServerMove()
            {
                X = client.Player.X,
                Y = client.Player.Y
            });
        }
    }
}
using LoESoft.Server.Core.Networking.Packets.Outgoing;

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
                case 1: RepositionPlayer(client, 0, -1); break;
                case 2: RepositionPlayer(client, 0, 1); break;
                case 3: RepositionPlayer(client, -1, 0); break;
                case 4: RepositionPlayer(client, 1, 0); break;
                default: break;
            }
        }

        //Repositions player and sends back a server move packet once it's done
        private void RepositionPlayer(Client client, int x, int y)
        {
            int X = client.Player.X + x;
            int Y = client.Player.Y + y;

            client.Manager.Map.RepositionPlayer(client.Player, X, Y);

            client.SendPacket(new ServerMove()
            {
                X = X,
                Y = Y
            });
        }
    }
}
using LoESoft.Server.Core.Networking;

namespace LoESoft.Server.Core.World.Entities.Player
{
    public class Player : Entity
    {
        public Client Client { get; private set; }

        public Player(Client client)
        {
            Client = client;
        }
    }
}

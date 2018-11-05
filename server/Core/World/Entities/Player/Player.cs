using LoESoft.Server.Core.Networking;

namespace LoESoft.Server.Core.World.Entities.Player
{
    public partial class Player : Entity
    {
        public Client Client { get; private set; }

        public Player(WorldManager manager, Client client, int id) : base(manager, id)
        {
            Client = client;
        }

        public void Save() { }

        public override void Dispose()
        {
            Manager.TryRemovePlayer(Client);
        }
    }
}
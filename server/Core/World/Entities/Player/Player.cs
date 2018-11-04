using LoESoft.Server.Core.Networking;
using LoESoft.Server.Core.Networking.Packets.Outgoing;
using LoESoft.Server.Core.World.Map.Data;

namespace LoESoft.Server.Core.World.Entities.Player
{
    public partial class Player : Entity
    {
        public Client Client { get; private set; }

        public Player(WorldManager manager, Client client, int id) : base(manager, id)
        {
            Client = client;
        }

        public PlayerData GetPlayerData =>
            new PlayerData()
            {
                X = X,
                Y = Y,
                Id = 0,
                UniqueId = UniqueId
            };

        public void Save() => App.Database.SavePlayer(Client.Account, GetPlayerData);

        public override void Dispose()
        {
            Manager.TryRemovePlayer(Client);
        }
    }
}
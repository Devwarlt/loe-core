using LoESoft.Server.Core.Networking;
using LoESoft.Server.Core.Networking.Packets.Outgoing;
using LoESoft.Server.Core.World.Map.Data;

namespace LoESoft.Server.Core.World.Entities.Player
{
    public class Player : Entity
    {
        public Client Client { get; private set; }

        public Player(WorldManager manager, Client client)
            : base(manager)
        {
            Client = client;
        }

        protected override void RepositionToChunk(int cx, int cy)
        {
            Manager.Map.RemovePlayer(this);

            ChunkX = cx;
            ChunkY = cy;

            Manager.Map.AddPlayer(this);
        }

        public override void Update()
        {
            base.Update();

            Client.SendPacket(new Update()
            {
                WorldData = Manager.Map.GetTileData(this),
                EntityData = Manager.Map.GetEntityData(this),
                PlayerData = Manager.Map.GetPlayerData(this)
            });
        }

        public PlayerData GetPlayerData =>
            new PlayerData()
            {
                X = X,
                Y = Y,
                Type = 0
            };

        public void Save() => GameServer._database.SavePlayer(Client.Account, GetPlayerData);

        public override void Dispose() => Manager.Map.RemovePlayer(this);
    }
}
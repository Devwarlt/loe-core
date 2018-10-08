using LoESoft.Server.Core.Networking;
using LoESoft.Server.Core.Networking.Packets.Outgoing;
using LoESoft.Server.Core.World.Map.Data;

namespace LoESoft.Server.Core.World.Entities.Player
{
    public class Player : Entity
    {
        public Client Client { get; private set; }

        public Player(Client client)
            : base(0, 0)
        {
            Client = client;
        }

        protected override void RepositionToChunk()
        {
            WorldManager.Map.RemovePlayer(this);
            WorldManager.Map.AddPlayer(this);
        }

        public override void Move(int x, int y)
        {
            base.Move(x, y);

            GameServer.Info("Sending Update!");

            Client.SendPacket(new Update()
            {
                WorldData = WorldManager.Map.GetTileData(this),
                EntityData = WorldManager.Map.GetEntityData(this),
                PlayerData = WorldManager.Map.GetPlayerData(this)
            });
        }

        public PlayerData GetPlayerData()
        {
            return new PlayerData()
            {
                X = X,
                Y = Y,
                Type = 0
            };
        }
    }
}

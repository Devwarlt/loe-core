using LoESoft.Server.Core.Networking;
using LoESoft.Server.Core.Networking.Packets.Outgoing;

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

        public override void Init()
        {
            WorldManager.Map.AddPlayer(this);
        }

        protected override void RepositionToChunk(int cx, int cy)
        {
            WorldManager.Map.RemovePlayer(this, cx, cy);
            WorldManager.Map.AddPlayer(this);
        }

        public override void Move(int x, int y)
        {
            base.Move(x, y);

            GameServer.Info("Sending Update!");

            Client.SendPacket(new Update()
            {
                WorldData = WorldManager.Map.GetData(this)
            });
        }
    }
}

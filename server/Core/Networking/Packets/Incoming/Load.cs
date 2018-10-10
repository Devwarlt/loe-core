using LoESoft.Server.Core.World;
using LoESoft.Server.Core.World.Entities.Player;

namespace LoESoft.Server.Core.Networking.Packets.Incoming
{
    public class Load : IncomingPacket
    {
        public override PacketID PacketID => PacketID.LOAD;

        public override void Handle(Client client)
        {
            client.Player = new Player(client);

            WorldManager.TryAddPlayer(client);
        }
    }
}

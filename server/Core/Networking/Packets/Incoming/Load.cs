using LoESoft.Server.Core.Networking.Packets.Outgoing;
using LoESoft.Server.Core.World;

namespace LoESoft.Server.Core.Networking.Packets.Incoming
{
    public class Load : IncomingPacket
    {
        public override PacketID PacketID => PacketID.LOAD;

        public override void Handle(Client client)
        {
            var world = client.Manager.Core.Map;

            client.SendPacket(new LoadMap()
            {
                MapWidth = WorldMap.WIDTH,
                MapHeight = WorldMap.HEIGHT
            });

            world.Add(client.Player);
        }
    }
}
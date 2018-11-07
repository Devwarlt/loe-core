using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Game.Map;

namespace LoESoft.Client.Core.Networking.Packets.Incoming
{
    public class LoadMap : IncomingPacket
    {
        public override PacketID PacketID => PacketID.LOAD_MAP;

        public int MapWidth { get; set; }
        public int MapHeight { get; set; }

        public override void Handle(GameUser gameUser)
        {
            Map.Initialize(MapWidth, MapHeight);
        }
    }
}
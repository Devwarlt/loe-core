using LoESoft.Client.Core.Game.Map;

namespace LoESoft.Client.Core.Networking.Packets.Incoming
{
    public class LoadMap : IncomingPacket
    {
        public override PacketID PacketID => PacketID.LOAD_MAP;

        public int MapWidth { get; set; }
        public int MapHeight { get; set; }

        public override void Read(NetworkReader reader)
        {
            MapWidth = reader.ReadInt32();
            MapHeight = reader.ReadInt32();
        }

        public override void Handle() => WorldMap.Initialize(MapWidth, MapHeight);
    }
}
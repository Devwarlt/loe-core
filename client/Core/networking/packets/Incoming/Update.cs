using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Screens;

namespace LoESoft.Client.Core.Networking.Packets.Incoming
{
    public class Update : IncomingPacket
    {
        public string TileData { get; set; }

        public override PacketID PacketID => PacketID.UPDATE;

        public override void Handle(GameUser gameUser)
        {
            GameScreen.PlayerMap.UpdateTiles(TileData);
        }
    }
}

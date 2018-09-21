using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            GameClient.Info(TileData);
            GameScreen.PlayerMap.UpdateTiles(TileData);
        }
    }
}

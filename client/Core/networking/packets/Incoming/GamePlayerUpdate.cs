using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Screens;

namespace LoESoft.Client.Core.Networking.Packets.Incoming
{
    public class GamePlayerUpdate : IncomingPacket
    {
        public string Stats { get; set; }
        public int ObjectId { get; set; }
        public int Id { get; set; }
        
        public override PacketID PacketID => PacketID.PLAYER_UPDATE;

        public override void Handle(GameUser gameUser) => Import(Stats, ObjectId, Id);

        public void Import(string stats, int objId, int id)
        {
            if (ScreenManager.ActiveScreen == GameApplication.GameScreen && GameApplication.GameScreen.Controller != null)
            {
                GameApplication.GameScreen.Controller.Override(objId, id);
                GameApplication.GameScreen.Controller.ImportStat(stats);
            }
        }
    }
}

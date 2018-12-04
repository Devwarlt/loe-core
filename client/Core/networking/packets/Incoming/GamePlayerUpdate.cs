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

        public override void Handle(GameUser gameUser)
        {
            if (ScreenManager.ActiveScreen == GameApplication.GameScreen)
            {
                if (GameApplication.GameScreen.Controller != null)
                {
                    GameApplication.GameScreen.Controller.Override(ObjectId, Id);
                    GameApplication.GameScreen.Controller.ImportStat(Stats);
                }
            }
        }
    }
}

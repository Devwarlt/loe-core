using LoESoft.Client.Core.Game.Objects.Stats;
using LoESoft.Client.Core.Screens;

namespace LoESoft.Client.Core.Networking.Packets.Incoming
{
    public class GamePlayerUpdate : IncomingPacket
    {
        public int ObjectId { get; set; }
        public int Id { get; set; }

        public Stat[] Stats { get; set; }
        
        public override PacketID PacketID => PacketID.PLAYER_UPDATE;

        public override void Read(NetworkReader reader)
        {
            ObjectId = reader.ReadInt32();
            Id = reader.ReadInt32();

            var length = reader.ReadInt32();
            Stats = new Stat[length];
            for(var i = 0; i < length; i++)
            {
                Stats[i] = new Stat();
                Stats[i].Read(reader);
            }
        }

        public override void Handle()
        {
            if (ScreenManager.ActiveScreen == GameApplication.GameScreen && GameApplication.GameScreen.Controller != null)
            {
                GameApplication.GameScreen.Controller.Override(ObjectId, Id);
                GameApplication.GameScreen.Controller.ImportStat(Stats);
            }
        }
    }
}

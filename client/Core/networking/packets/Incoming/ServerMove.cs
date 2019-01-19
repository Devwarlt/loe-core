using LoESoft.Client.Core.Screens;

namespace LoESoft.Client.Core.Networking.Packets.Incoming
{
    public class ServerMove : IncomingPacket
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override PacketID PacketID => PacketID.SERVERMOVE;

        public override void Read(NetworkReader reader)
        {
            X = reader.ReadInt32();
            Y = reader.ReadInt32();
        }

        public override void Handle()
        {
            if (ScreenManager.ActiveScreen == GameApplication.GameScreen)
                GameApplication.GameScreen.Controller?.SetDistination(X, Y);
        }
    }
}
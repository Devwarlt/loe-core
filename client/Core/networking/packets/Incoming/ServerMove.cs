using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Screens;

namespace LoESoft.Client.Core.Networking.Packets.Incoming
{
    public class ServerMove : IncomingPacket
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override PacketID PacketID => PacketID.SERVERMOVE;

        public override void Handle(GameUser gameUser)
        {
            var game = (ScreenManager.ActiveScreen as GameScreen);

            game.Controller?.SetDistination(X, Y);
        }
    }
}
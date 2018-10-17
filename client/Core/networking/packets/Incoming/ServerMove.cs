using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Screens;

namespace LoESoft.Client.Core.Networking.Packets.Incoming
{
    public class ServerMove : IncomingPacket, IUdpPacket
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override PacketID PacketID => PacketID.SERVERMOVE;

        public override void Handle(GameUser gameUser)
        {
            if (ScreenManager.ActiveScreen is GameScreen)
            {
                GameScreen screen = ScreenManager.ActiveScreen as GameScreen;

                if (screen.TempPlayer != null)
                {
                    screen.TempPlayer.DistinationX = X;
                    screen.TempPlayer.DistinationY = Y;
                }
            }

            NetworkControl._recievedServerMove = true;
        }
    }
}
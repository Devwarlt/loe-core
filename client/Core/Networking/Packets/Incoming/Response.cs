using LoESoft.Client.Core.Client;

namespace LoESoft.Client.Core.Networking.Packets.Incoming
{
    public class Response : IncomingPacket
    {
        public int Result { get; set; }
        public string Content { get; set; }

        public override PacketID PacketID => PacketID.RESPONSE;

        // TODO: result '-1' display a popup with content / result '0' display a popup and let player login.
        public override void Handle(GameUser gameUser) { }
    }
}

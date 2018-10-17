using LoESoft.Client.Core.Client;

namespace LoESoft.Client.Core.Networking.Packets.Incoming
{
    public abstract class IncomingPacket : PacketBase
    {
        public abstract void Handle(GameUser gameUser);
    }
}
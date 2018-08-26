namespace LoESoft.Server.Core.Networking.Packets.Incoming
{
    public abstract class IncomingPacket : PacketBase {
        public abstract void Handle(Client client);
    }
}

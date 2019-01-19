namespace LoESoft.Client.Core.Networking.Packets.Outgoing
{
    public abstract class OutgoingPacket : PacketBase
    {
        public abstract void Write(NetworkWriter writer);
    }
}
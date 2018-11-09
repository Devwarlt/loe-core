namespace LoESoft.Server.Core.Networking.Packets.Incoming
{
    public class Load : IncomingPacket
    {
        public override PacketID PacketID => PacketID.LOAD;

        public override void Handle(Client client) => client.Manager.TryAddPlayer(client);
    }
}
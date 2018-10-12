using LoESoft.Server.Core.World.Entities.Player;

namespace LoESoft.Server.Core.Networking.Packets.Incoming
{
    public enum LoadError : int
    {
        Success = 0,
        ServerFull = 1,
        Error = 2
    }
    public class Load : IncomingPacket
    {
        public override PacketID PacketID => PacketID.LOAD;

        public override void Handle(Client client)
        {
            client.Player = new Player(client.Manager, client);

            client.Manager.TryAddPlayer(client);
        }
    }
}

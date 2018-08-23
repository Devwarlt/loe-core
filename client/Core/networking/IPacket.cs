using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Networking.Packets;
using LoESoft.Client.Core.Networking.Packets.Server;

namespace LoESoft.Client.Core.Networking
{
    public interface IPacket
    {
        PacketID ID { get; }
        void Handle(GameUser gameUser, ServerPacket serverPacket);
    }
}

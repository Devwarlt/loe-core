using LoESoft.Client.Core.client;
using LoESoft.Client.Core.networking.packet;
using LoESoft.Client.Core.networking.packet.server;

namespace LoESoft.Client.Core.networking
{
    public interface IPacket
    {
        PacketID ID { get; }
        void Handle(GameUser gameUser, ServerPacket serverPacket);
    }
}

using LoESoft.Server.Core.client;
using LoESoft.Server.Core.networking.packet;
using LoESoft.Server.Core.networking.packet.client;

namespace LoESoft.Server.Core.networking
{
    interface IPacket
    {
        PacketID ID { get; }
        void Handle(Client client, ClientPacket clientPacket);
    }
}

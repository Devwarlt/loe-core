using LoESoft.Server.client;
using LoESoft.Server.networking.packet;
using LoESoft.Server.networking.packet.client;

namespace LoESoft.Server.networking
{
    interface IPacket
    {
        PacketID ID { get; }
        void Handle(Client client, ClientPacket clientPacket);
    }
}

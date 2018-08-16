using LoESoft.Server.client;
using LoESoft.Server.networking.packet.client;
using System;

namespace LoESoft.Server.networking.packet
{
    internal abstract class PacketHandler<T> : IPacket where T : ClientPacket
    {
        public abstract PacketID ID { get; }

        protected abstract void HandlePacket(Client client, T packet);

        static PacketHandler()
        {
            foreach (var i in typeof(Packet).Assembly.GetTypes())
                if (typeof(IPacket).IsAssignableFrom(i) && !i.IsAbstract && !i.IsInterface)
                {
                    IPacket packet = (IPacket)Activator.CreateInstance(i);
                    Packet.ClientPacketHandlers.Add(packet.ID, packet);
                }
        }

        public void Handle(Client client, ClientPacket clientPacket)
            => HandlePacket(client, (T)clientPacket);
    }
}

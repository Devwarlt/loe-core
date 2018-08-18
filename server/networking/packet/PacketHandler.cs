using LoESoft.Log;
using LoESoft.Server.client;
using LoESoft.Server.networking.packet.client;
using System;
using System.Reflection;
using System.Text;

namespace LoESoft.Server.networking.packet
{
    internal abstract class PacketHandler<T> : IPacket where T : ClientPacket
    {
        public static Info _info => new Info(nameof(PacketHandler<T>));

        public abstract PacketID ID { get; }

        protected abstract void HandlePacket(Client client, T packet);

        static PacketHandler()
        {
            foreach (var i in typeof(Packet).Assembly.GetTypes())
                if (typeof(IPacket).IsAssignableFrom(i) && !i.IsAbstract)
                {
                    IPacket packet = (IPacket)Activator.CreateInstance(i);
                    Packet.ClientPacketHandlers.Add(packet.ID, packet);
                }
        }

        public void Handle(Client client, ClientPacket clientPacket)
            => HandlePacket(client, (T)clientPacket);

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder("{\n");
            PropertyInfo[] arr = GetType().GetProperties();
            for (int i = 0; i < arr.Length; i++)
            {
                if (i != 0) ret.Append(",\n");
                ret.AppendFormat("\t{0}: {1}", arr[i].Name, arr[i].GetValue(this, null));
            }
            ret.Append("\n}");
            return ret.ToString();
        }
    }
}

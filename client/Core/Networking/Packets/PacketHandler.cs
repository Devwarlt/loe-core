using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Networking.Packets.Server;
using System;
using System.Reflection;
using System.Text;

namespace LoESoft.Client.Core.Networking.Packets
{
    internal abstract class PacketHandler<T> : IPacket where T : ServerPacket
    {
        public abstract PacketID ID { get; }

        protected abstract void HandlePacket(GameUser gameUser, T packet);

        static PacketHandler()
        {
            foreach (var i in typeof(Packet).Assembly.GetTypes())
                if (typeof(IPacket).IsAssignableFrom(i) && !i.IsAbstract)
                {
                    IPacket packet = (IPacket)Activator.CreateInstance(i);
                    Packet.ServerPacketHandlers.Add(packet.ID, packet);
                }
        }

        public void Handle(GameUser gameUser, ServerPacket serverPacket)
            => HandlePacket(gameUser, (T)serverPacket);

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

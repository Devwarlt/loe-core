using LoESoft.Server.networking.packet.client;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LoESoft.Server.networking.packet
{
    internal abstract class Packet
    {
        public static Dictionary<PacketID, Packet> ClientMessages = new Dictionary<PacketID, Packet>();
        public static Dictionary<PacketID, IPacket> ClientPacketHandlers = new Dictionary<PacketID, IPacket>();

        public abstract PacketID ID { get; }

        public abstract Packet CreateInstance();

        static Packet()
        {
            foreach (var i in typeof(Packet).Assembly.GetTypes())
                if (typeof(Packet).IsAssignableFrom(i) && !i.IsAbstract && typeof(IClientPacket).IsAssignableFrom(i))
                {
                    Packet packet = (Packet)Activator.CreateInstance(i);
                    ClientMessages.Add(packet.ID, packet);
                }
        }

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

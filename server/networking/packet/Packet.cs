using LoESoft.Server.networking.packet.server;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LoESoft.Server.networking.packet
{
    public abstract class Packet
    {
        public static Dictionary<PacketID, Packet> ClientMessages = new Dictionary<PacketID, Packet>();
        public static Dictionary<PacketID, IPacket> ClientPacketHandlers = new Dictionary<PacketID, IPacket>();

        public abstract PacketID ID { get; }

        public abstract Packet CreateInstance();

        static Packet()
        {
            foreach (var i in typeof(Packet).Assembly.GetTypes())
                if (typeof(Packet).IsAssignableFrom(i) && !i.IsAbstract)
                {
                    Packet packet = (Packet)Activator.CreateInstance(i);

                    if (!(packet is ServerPacket))
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

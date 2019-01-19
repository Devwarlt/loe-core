using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LoESoft.Server.Core.Networking.Packets.Incoming
{
    public abstract class IncomingPacket : PacketBase
    {
        public static readonly Dictionary<int, IncomingPacket> IncomingPackets = new Dictionary<int, IncomingPacket>();

        static IncomingPacket()
        {
            foreach (var i in Assembly.GetAssembly(typeof(IncomingPacket)).GetTypes().Where(_ => _.IsClass && !_.IsAbstract && _.IsSubclassOf(typeof(IncomingPacket))))
            {
                var incomingMessage = (IncomingPacket)Activator.CreateInstance(i);
                IncomingPackets.Add((int)incomingMessage.PacketID, incomingMessage);
            }
        }

        public abstract void Read(NetworkReader reader);

        public abstract void Handle(NetworkClient client);
    }
}
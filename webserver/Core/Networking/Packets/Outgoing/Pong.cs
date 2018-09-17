using System;

namespace LoESoft.WebServer.Core.Networking.Packets.Outgoing
{
    public class Pong : PacketBase
    {
        public override void Handle()
            => Write($"Server says: {new Random().Next()}.");
    }
}

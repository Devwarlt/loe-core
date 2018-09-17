using LoESoft.WebServer.Core.Networking.Packets.Outgoing;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;

namespace LoESoft.WebServer.Core.Networking.Packets
{
    public enum PacketID : int
    {
        PING = 1
    }

    public abstract class PacketBase
    {
        public HttpListenerContext Context { get; set; }
        public NameValueCollection Query { get; set; }

        public static readonly Dictionary<PacketID, PacketBase> RequestLibrary = new Dictionary<PacketID, PacketBase>()
        {
            { PacketID.PING, new Pong() }
        };

        public abstract void Handle();

        public virtual void Write(string data)
        {
            using (var writer = new StreamWriter(Context.Response.OutputStream))
                writer.Write(data);
        }
    }
}

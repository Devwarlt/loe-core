using LoESoft.WebServer.Core.Networking.Packets.Outgoing;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;

namespace LoESoft.WebServer.Core.Networking.Packets
{
    public enum PacketID : int
    {
        PING = 1,
        LOGIN = 2,
        LOGIN_TOKEN = 3
    }

    public abstract class PacketBase
    {
        public HttpListenerContext Context { get; set; }
        public NameValueCollection Query { get; set; }

        public static readonly Dictionary<PacketID, PacketBase> RequestLibrary = new Dictionary<PacketID, PacketBase>()
        {
            { PacketID.PING, new Pong() }
            // TODO: Implement 'LOGIN' packet handler.
            // Params: account number "accNumber" (int) and account password "accPass" (string).

            // TODO: Implement 'LOGIN_TOKEN' packet handler.
            // Params: account token "accToken" (string).
        };

        public abstract void Handle();

        public virtual void Write(string data)
        {
            using (var writer = new StreamWriter(Context.Response.OutputStream))
                writer.Write(data);
        }
    }
}

using LoESoft.WebServer.Core.Networking.Packets.Outgoing;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace LoESoft.WebServer.Core.Networking.Packets
{
    public enum PacketID : int
    {
        LOGIN = 1,
        LOGIN_TOKEN = 2,
        REGISTER = 3,
        CHECK_VERSION = 4
    }

    public abstract class PacketBase
    {
        public HttpListenerContext Context { get; set; }
        public NameValueCollection Query { get; set; }

        public static readonly Dictionary<PacketID, PacketBase> RequestLibrary = new Dictionary<PacketID, PacketBase>()
        {
            { PacketID.LOGIN, new Login() },
            { PacketID.LOGIN_TOKEN, new LoginToken() },
            { PacketID.REGISTER, new Register() },
            { PacketID.CHECK_VERSION, new CheckVersion() }
        };

        public abstract void Handle();

        public virtual void OnInfo(string data)
        {
            using (var writer = new StreamWriter(Context.Response.OutputStream))
                writer.Write(data);
        }

        public virtual void OnSend(string data = null) => Write("Success", data ?? string.Empty);

        public virtual void OnError(string data) => Write("Error", data);

        public string SerializeToXml(object data)
        {
            var strWriter = new StringWriter();
            var serializer = new XmlSerializer(data.GetType());
            serializer.Serialize(strWriter, data);
            return strWriter.ToString();
        }

        private void Write(string type, string data)
        {
            using (var writer = new StreamWriter(Context.Response.OutputStream))
                writer.Write(new XElement(type, data));
        }
    }
}
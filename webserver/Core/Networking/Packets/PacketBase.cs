using LoESoft.WebServer.Core.Networking.Packets.Outgoing;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

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
            { PacketID.PING, new Ping() }
            // TODO: Implement 'LOGIN' packet handler.
            // Params: account number "accNumber" (int) and account password "accPass" (string).

            // TODO: Implement 'LOGIN_TOKEN' packet handler.
            // Params: account token "accToken" (string).
        };

        public abstract void Handle();

        public virtual void OnSend<T>(T data, bool isXML = false) => Write("Success", data, isXML);

        public virtual void OnError<T>(T data, bool isXML = false) => Write("Error", data, isXML);

        public XmlDocument SerializeToXml(object data)
        {
            XmlDocument xml = new XmlDocument();

            using (var writer = xml.CreateNavigator().AppendChild())
                new XmlSerializer(data.GetType()).Serialize(writer, data);

            return xml;
        }

        private void Write<T>(string type, T data, bool isXML)
        {
            using (var writer = new StreamWriter(Context.Response.OutputStream))
                if (isXML)
                    writer.Write(new XElement(type, data as XElement));
                else
                    writer.Write(new XElement(type, data as string));
        }
    }
}

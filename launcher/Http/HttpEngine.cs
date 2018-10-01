using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace LoESoft.Launcher.Http
{
    public enum PacketID : int
    {
        PING = 1,
        LOGIN = 2,
        LOGIN_TOKEN = 3,
        REGISTER = 4
    }

    public struct HttpEngineQuery
    {
        public int Length => Objects?.Count ?? 0;

        public Dictionary<string, object> Objects { get; set; }

        public object this[string query] => Objects[query];

        public void AddQuery(string key, object value)
        {
            if (Objects == null)
                Objects = new Dictionary<string, object>();

            Objects.Add(key, value);
        }
    }

    public class HttpEngine
    {
        private WebClient WebClient { get; set; }
        private string Request { get; set; }

        private bool Downloaded { get; set; }

        public static void Handle(PacketID packet, HttpEngineQuery query, Action<string> success, Action<string> error)
        {
            if (!Enum.IsDefined(typeof(PacketID), packet))
            {
                GameLauncher.Warn($"Packet ID '({(int)packet}){packet}' doesn't exist.");
                return;
            }

            try { CreateRequest(packet).SendRequest(success, error, query); }
            catch (Exception e) { GameLauncher.Error(e); }
        }

        public static HttpEngine CreateRequest(PacketID packetID)
        {
            var engine = new HttpEngine
            {
                WebClient = new WebClient(),
                Request = $"/?PID={(int)packetID}"
            };
            return engine;
        }

        public void SendRequest(Action<string> success, Action<string> error, HttpEngineQuery query)
        {
            var sb = new StringBuilder();
            var i = 0;

            foreach (var q in query.Objects)
            {
                sb.Append($"{q.Key}={q.Value}{(i != query.Length - 1 ? "&" : "")}");
                i++;
            }

            string requestURI = $"{GameLauncherParameters.SERVER}{Request}&{sb.ToString()}";

            GameLauncher.Info($"Sending Request {requestURI}");

            try
            {
                var data = WebClient.DownloadString(requestURI);

                if (data.Substring(0, 7) == "<Error>")
                {
                    error?.Invoke(XElement.Parse(data).Value);
                    return;
                }

                success?.Invoke(data);
            }
            catch { error?.Invoke("Unable to connect to server"); }
        }
    }
}

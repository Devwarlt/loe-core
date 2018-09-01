using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace LoESoft.Launcher.Http
{
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

        public static HttpEngine CreateRequest(string request)
        {
            var engine = new HttpEngine();
            engine.WebClient = new WebClient();
            engine.Request = request;
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

            Console.WriteLine($"Sending Request https://{LauncherParameters.SERVER}{Request}?{sb.ToString()}");
            try
            {
                var data = WebClient.DownloadString($"https://{LauncherParameters.SERVER}{Request}?{sb.ToString()}");
                if (data.Substring(0, 7) == "<Error>")
                {
                    error?.Invoke(XElement.Parse(data).Value);
                    return;
                }
                success?.Invoke(data);
            }
            catch
            {
                error?.Invoke("Unable to connect to server");
            }
        }
    }
}

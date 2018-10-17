using LoESoft.WebServer.Core.Networking.Packets;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Web;

namespace LoESoft.WebServer.Core.Networking
{
    public class ConnectionListener
    {
        private int _port => 7172;
        private HttpListener _listener;
        private Queue<HttpListenerContext> _listenerContext = new Queue<HttpListenerContext>();
        private ManualResetEvent _listenerEvent = new ManualResetEvent(false);
        private Thread[] _listenerThreads = new Thread[5];
        private readonly object _listenerLock = new object();
        private bool _shutdown = false;

        public void StartAccept()
        {
            if (!HttpListener.IsSupported)
            {
                GameWebServer.Warn("Windows XP SP2 or Server 2003 is required to use the HttpListener feature.");
                return;
            }

            var url = $"http://*:{_port}/";

            Process.Start(
                new ProcessStartInfo("netsh", string.Format(@"http add urlacl url={0}", url) +
                " user=\"" + Environment.UserDomainName +
                "\\" + Environment.UserName + "\"")
                {
                    Verb = "runas",
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = true
                }).WaitForExit();

            _listener = new HttpListener();
            _listener.Prefixes.Add(url);
            _listener.Start();

            try { _listener.BeginGetContext(BeginCallback, null); }
            catch (Exception e) { GameWebServer.Error(e); }

            for (int i = 0; i < _listenerThreads.Length; i++)
            {
                _listenerThreads[i] = new Thread(HandleContext)
                {
                    Name = $"Listener Thread #{i}",
                    IsBackground = true
                };
                _listenerThreads[i].Start();
            }
        }

        public void EndAccept()
        {
            _shutdown = true;

            _listenerContext.Clear();

            try
            {
                _listenerEvent.Set();
                _listener.Stop();
            }
            catch (ObjectDisposedException) { }
        }

        private void BeginCallback(IAsyncResult asyncResult)
        {
            if (!_listener.IsListening)
                return;

            var getContext = _listener.EndGetContext(asyncResult);

            _listener.BeginGetContext(BeginCallback, null);

            lock (_listenerLock)
            {
                _listenerContext.Enqueue(getContext);
                _listenerEvent.Set();
            }
        }

        private void HandleContext()
        {
            do
            {
                if (_shutdown)
                    break;

                HttpListenerContext queuedContext = null;

                lock (_listenerLock)
                {
                    if (_listenerContext.Count > 0)
                        queuedContext = _listenerContext.Dequeue();
                    else
                    {
                        _listenerEvent.Reset();
                        continue;
                    }
                }

                if (queuedContext == null)
                    continue;

                HandleRequest(queuedContext);
            } while (_listenerEvent.WaitOne());
        }

        private void HandleRequest(HttpListenerContext context)
        {
            var query = new NameValueCollection();

            using (var reader = new StreamReader(context.Request.InputStream))
                query = HttpUtility.ParseQueryString(reader.ReadToEnd());

            if (query.AllKeys.Length == 0)
            {
                string url = context.Request.RawUrl;
                int urlParams = url.IndexOf('?');

                if (urlParams >= 0)
                    query = HttpUtility.ParseQueryString((urlParams < url.Length - 1) ? url.Substring(urlParams + 1) : string.Empty);
            }

            if (string.IsNullOrEmpty(query["PID"]))
                BadRequest(context);
            else
            {
                int pid = int.Parse(query["PID"]);

                if (Enum.IsDefined(typeof(PacketID), pid))
                {
                    var packetID = (PacketID)pid;

                    string message = $"[PID: {(int)packetID}] Request\t->\t";

                    if (!PacketBase.RequestLibrary.TryGetValue(packetID, out PacketBase packet))
                        InvalidRequest(context, message + packetID);
                    else
                        GoodRequest(context, message + packetID, packet, query);
                }
                else
                    InvalidRequest(context, $"PID '{pid}' isn't implemented yet.");
            }
        }

        private void InvalidRequest(HttpListenerContext context, string message)
        {
            GameWebServer.Warn(message);

            context.Response.StatusCode = 400;
            context.Response.StatusDescription = "Invalid request to the web server.";

            using (var writer = new StreamWriter(context.Response.OutputStream))
                writer.Write("<h1>Error 400</h1><br>" +
                    "An invalid request has been suspended due missing data." +
                    "<br><br>" +
                    "Kind regards,<br>" +
                    "<b>LoESoft Games</b>");
        }

        private void GoodRequest(HttpListenerContext context, string message, PacketBase packet, NameValueCollection query)
        {
            GameWebServer.Info(message);

            packet.Context = context;
            packet.Query = query;
            packet.Handle();
        }

        private void BadRequest(HttpListenerContext context)
        {
            context.Response.StatusCode = 404;
            context.Response.StatusDescription = "Invalid PID request to the web server.";

            using (var writer = new StreamWriter(context.Response.OutputStream))
                writer.Write("<h1>Error 404</h1><br>" +
                "Unknown request has been suspended due missing data." +
                "<br><br>" +
                "Kind regards,<br>" +
                "<b>LoESoft Games</b>");
        }
    }
}
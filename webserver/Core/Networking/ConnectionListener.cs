using LoESoft.WebServer.Core.Networking.Packets;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;

namespace LoESoft.WebServer.Core.Networking
{
    public class ConnectionListener
    {
        private int _port => 7172;
        private HttpListener _listener { get; set; }
        private Queue<HttpListenerContext> _listenerContext { get; set; }
        private ManualResetEvent _listenerEvent { get; set; }
        private Thread[] _listenerThreads { get; set; }
        private object _listenerLock { get; set; }
        private bool _shutdown { get; set; }

        public void StartAccept()
        {
            if (!HttpListener.IsSupported)
            {
                GameWebServer.Warn("Windows XP SP2 or Server 2003 is required to use the HttpListener feature.");
                return;
            }

            string url = $"http://*:{_port}/";

            Process.Start(new ProcessStartInfo("netsh",
                string.Format(@"http add urlacl url={0}", url) +
                " user=\"" + Environment.UserDomainName + "\\" +
                Environment.UserName + "\"")
            {
                Verb = "runas",
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = true
            }).WaitForExit();

            _listener = new HttpListener();
            _listener.Prefixes.Add(url);
            _listener.Start();

            _shutdown = false;
            _listenerThreads = new Thread[5];
            _listenerContext = new Queue<HttpListenerContext>();
            _listenerEvent = new ManualResetEvent(false);
            _listenerLock = new object();

            var listenerThread = new Thread(() =>
            {
                try
                {
                    do
                    {
                        _listener.BeginGetContext((IAsyncResult asyncResult) =>
                        {
                            if (!_listener.IsListening)
                                return;

                            lock (_listenerLock)
                            {
                                _listenerContext.Enqueue(_listener.EndGetContext(asyncResult));
                                _listenerEvent.Set();
                            }
                        }, null);
                    } while (!_shutdown);
                }
                catch (Exception e) { GameWebServer.Error(e); }
            })
            {
                Name = $"Listener Main Thread",
                IsBackground = true
            };
            listenerThread.Start();

            for (int i = 0; i < _listenerThreads.Length; i++)
            {
                _listenerThreads[i] = new Thread(() =>
                {
                    while (_listenerEvent.WaitOne())
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

                        string path = queuedContext.Request.Url.LocalPath;

                        if (path.IndexOf(".") == -1)
                            continue;
                        else
                        {
                            NameValueCollection query;

                            using (var reader = new StreamReader(queuedContext.Request.InputStream))
                                query = HttpUtility.ParseQueryString(reader.ReadToEnd());

                            Match match = Regex.Match(query["PID"], @"\d+");

                            if (match.Success)
                            {
                                PacketID packetID = Enum.IsDefined(typeof(PacketID), int.Parse(match.Value)) ? (PacketID)int.Parse(match.Value) : PacketID.UNKNOWN;

                                if (!PacketBase.RequestLibrary.TryGetValue(packetID, out PacketBase packet))
                                {
                                    queuedContext.Response.StatusCode = 400;
                                    queuedContext.Response.StatusDescription = "Invalid request to the web server.";

                                    using (var writer = new StreamWriter(queuedContext.Response.OutputStream))
                                        writer.Write("An invalid request has been suspended due missing data.");
                                }
                                else
                                {
                                    packet.Context = queuedContext;
                                    packet.Query = query;
                                    packet.Handle();
                                }
                            }
                        }
                    }
                })
                {
                    Name = $"Listener Thread #{i}",
                    IsBackground = true
                };
                _listenerThreads[i].Start();
            }

            Thread.CurrentThread.Join();
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
    }
}

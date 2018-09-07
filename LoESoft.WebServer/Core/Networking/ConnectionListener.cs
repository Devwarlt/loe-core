using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;

namespace LoESoft.WebServer.Core.Networking
{
    // TODO: continue migration from
    // https://github.com/Devwarlt/LOE-V7-SERVER/blob/Vocations/appengine/AppEngineManager.cs#L18-L324
    public class ConnectionListener
    {
        public delegate bool ConnectionListenerDelegate();

        private int _port => 7172;
        private HttpListener _listener { get; set; }
        private Queue<HttpListenerContext> _listenerContext { get; set; }
        private ManualResetEvent _resetEvent { get; set; }
        private Thread[] _threads { get; set; }
        private object _lock { get; set; }
        private bool _shutdown { get; set; }
        private bool _isCompleted { get; set; }

        public void StartAccept()
        {
            if (!IsPortUsed())
            {
                ForceShutdown();
                return;
            }

            _isCompleted = false;
            _threads = new Thread[3];
            _listenerContext = new Queue<HttpListenerContext>();
            _resetEvent = new ManualResetEvent(false);
            _lock = new object();
        }

        public void EndAccept()
        {

        }

        private bool IsPortUsed()
            => IPGlobalProperties.GetIPGlobalProperties().
                    GetActiveTcpConnections().All(_ => _.LocalEndPoint.Port != _port) &&
                IPGlobalProperties.GetIPGlobalProperties().
                    GetActiveTcpListeners().All(_ => _.Port != _port);

        private void ForceShutdown()
        {
            _shutdown = true;

            int i = 3;

            do
            {
                GameWebServer.Info($"Port {_port} is occupied, restarting in {i} second{(i > 1 ? "s" : "")}...");
                Thread.Sleep(1 * 1000);
                i--;
            } while (i != 0);

            Process.Start($"{GameWebServer._name}.exe");

            Environment.Exit(0);
        }
    }
}

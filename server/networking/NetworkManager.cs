using LoESoft.Log;
using LoESoft.Server.client;
using LoESoft.Server.utils;
using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;

namespace LoESoft.Server.networking
{
    public class NetworkManager
    {
        public static Info _info => new Info(nameof(NetworkManager));
        public static Warn _warn => new Warn(nameof(NetworkManager));
        public static Error _error => new Error(nameof(NetworkManager));

        internal static ConcurrentBag<Client> _connections = new ConcurrentBag<Client>();

        private TCPServerSettings _tcpServerSettings { get; set; }
        private Socket _socket { get; set; }

        public NetworkManager(TCPServerSettings tcpServerSettings)
        {
            _tcpServerSettings = tcpServerSettings;
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            _info.Write("Network Manager is loading...");

            _socket.Bind(new IPEndPoint(IPAddress.Any, _tcpServerSettings._port));
            _socket.Listen(_tcpServerSettings._maxClients);
            _socket.BeginAccept(new AsyncCallback(AcceptCallback), null);

            _info.Write("Network Manager is loading... OK!");
        }

        public void Stop()
        {
            _info.Write("Network Manager has been stopped.");

            foreach (var connection in _connections)
                connection.Dispose();

            _socket.Dispose();
            _socket.Close();
        }

        private void AcceptCallback(IAsyncResult asyncResult)
        {
            Socket socket = null;

            try {
                socket = _socket.EndAccept(asyncResult);
                _socket.BeginAccept(new AsyncCallback(AcceptCallback), null);
            }
            catch (ObjectDisposedException) { }
            
            if (socket != null)
                _connections.Add(new Client(socket));
        }
    }
}

using LoESoft.Server.Core.client;
using LoESoft.Server.utils;
using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace LoESoft.Server.Core.networking
{
    public class NetworkManager : IDisposable
    {
        internal static ConcurrentBag<Client> _connections = new ConcurrentBag<Client>();

        public static bool _dispose { get; private set; } = false;

        private static Socket _socket { get; } = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        {
            NoDelay = true,
            UseOnlyOverlappedIO = true,
            SendTimeout = 1000,
            ReceiveTimeout = 1000,
            Ttl = 112
        };

        private TCPServerSettings _tcpServerSettings { get; set; }
        private Thread _connectionThread { get; set; }

        public NetworkManager(TCPServerSettings tcpServerSettings)
        {
            _tcpServerSettings = tcpServerSettings;
            _connectionThread = new Thread(CheckConnections) { IsBackground = true };
        }

        public void Start()
        {
            GameServer.Info("Network Manager is loading...");

            _socket.Bind(new IPEndPoint(IPAddress.Any, _tcpServerSettings._port));
            _socket.Listen(_tcpServerSettings._maxClients);
            _socket.BeginAccept(new AsyncCallback(AcceptCallback), null);
            _connectionThread.Start();

            GameServer.Info("Network Manager is loading... OK!");
        }

        private void CheckConnections()
        {
            while (_socket != null && !_dispose)
            {
                foreach (var connection in _connections)
                {
                    if (_dispose)
                        break;

                    try
                    {
                        if (!connection._socket.Connected)
                            DisposeClient();
                    }
                    catch (SocketException)
                    {
                        DisposeClient();
                        continue;
                    }

                    Thread.Sleep(10);
                }
            }
        }

        private void AcceptCallback(IAsyncResult asyncResult)
        {
            Socket socket = null;

            try
            {
                socket = _socket.EndAccept(asyncResult);
                _socket.BeginAccept(new AsyncCallback(AcceptCallback), null);
            }
            catch (ObjectDisposedException) { }

            if (socket != null)
                _connections.Add(new Client(socket));
        }

        private static void DisposeClient()
        {
            _connections.TryTake(out Client client);

            GameServer.Warn($"Client with IP '{client._ip}' dropped connection, disposing...");

            client.Dispose();
        }

        public void Dispose()
        {
            _dispose = true;

            GameServer.Info("Network Manager has been stopped.");

            foreach (var connection in _connections)
                connection.Dispose();

            _socket.Close();
            _socket.Dispose();
        }
    }
}

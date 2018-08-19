using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace LoESoft.Client.Core.networking.gamenetwork
{
    public class NetworkManager : IDisposable
    {
        public int _connectionAttempts { get; private set; } = 0;

        private Socket _socket { get; set; } = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private IPEndPoint _server { get; } = Server.GetServers["Test Server"];
        private bool _disposed { get; set; } = false;

        public void Start()
        {
            while (!_disposed)
            {
                if (_socket == null)
                    break;

                if (!_socket.Connected)
                    break;

                try
                {
                    _connectionAttempts++;
                    _socket.Connect(_server);
                }
                catch (SocketException) { GameClient._log.Warn($"[Attempts: {_connectionAttempts}] The game client cannot connect to IP '{_server.Address.ToString()}' via port '{_server.Port}'..."); }

                Thread.Sleep(3 * 1000);
            }
        }

        public void Dispose()
        {
            GameClient._log.Info("Network Manager has been stopped.");

            _disposed = false;
            _socket = null;
        }
    }
}

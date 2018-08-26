using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Utils;
using System;
using System.Net.Sockets;
using System.Threading;

namespace LoESoft.Client.Core.Networking
{
    public class NetworkMonitor
    {
        public event EventHandler<SocketEventArgs> _socketEventHandler;

        private GameUser _gameUser { get; set; }
        private Thread _connectionTread { get; set; }

        public NetworkMonitor(GameUser gameUser)
        {
            _gameUser = gameUser;
            _connectionTread = new Thread(CheckConnection) { IsBackground = true };
        }

        public void Start() => _connectionTread.Start();

        private void CheckConnection()
        {
            _gameUser._networkHandler._networkHandlerSemaphore.WaitOne();

            while (!NetworkManager._dispose)
            {
                if (!_gameUser._socket.Connected)
                    OnConnectionLost(new SocketEventArgs()
                    {
                        _server = _gameUser._server,
                        _socket = _gameUser._socket
                    });
            }
        }

        private void OnConnectionLost(SocketEventArgs e) => _socketEventHandler?.Invoke(TextType.CONNECTION_LOST_WITH_ATTEMPTS, e);
    }

    public class SocketEventArgs : EventArgs
    {
        public Socket _socket { get; set; }
        public Server _server { get; set; }
    }
}

using LoESoft.Client.Core.Client;
using System;
using System.Net.Sockets;
using System.Threading;

namespace LoESoft.Client.Core.Networking
{
    public class NetworkManager : IDisposable
    {
        public static bool _dispose { get; private set; } = false;
        public static Semaphore _networkManagerDisposeSemaphore { get; set; } = new Semaphore(1, 1);

        public Socket _socket { get; set; }
        public Server _server { get; set; }
        public GameUser _gameUser { get; private set; }

        public void Start()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            {
                NoDelay = true,
                UseOnlyOverlappedIO = true,
                SendTimeout = 1000,
                ReceiveTimeout = 1000,
                Ttl = 112
            };
            _server = Server.GetServers["Local Server"];
            _gameUser = new GameUser(_socket, _server);
        }

        public void Dispose()
        {
            _dispose = true;

            GameClient.Info("Network Manager has been stopped.");

            _socket.Close();
            _socket.Dispose();
        }
    }
}

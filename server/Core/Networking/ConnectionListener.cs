using LoESoft.Server.Core.World;
using System;
using System.Net;
using System.Net.Sockets;

namespace LoESoft.Server.Core.Networking
{
    public class ConnectionListener
    {
        public Socket Socket { get; set; }

        private WorldManager _manager;

        public ConnectionListener(WorldManager manager)
        {
            _manager = manager;
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Socket.Bind(new IPEndPoint(IPAddress.Any, 7171));
            Socket.Listen(0xFF);

            Socket.NoDelay = true;
            Socket.UseOnlyOverlappedIO = true;
            Socket.SendTimeout = 1000;
            Socket.ReceiveTimeout = 1000;
            Socket.Ttl = 112;
        }

        public void StartAccept() => Socket.BeginAccept(OnAccept, null);

        private void OnAccept(IAsyncResult asyncResult)
        {
            var socket = Socket.EndAccept(asyncResult);

            if (socket != null)
            {
                var client = new Client(socket, _manager);
            }
            StartAccept();
        }

        public void EndAccept() => Socket.Close();
    }
}
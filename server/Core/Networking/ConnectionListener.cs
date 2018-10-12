using LoESoft.Server.Core.World;
using System;
using System.Net;
using System.Net.Sockets;

namespace LoESoft.Server.Core.Networking
{
    public class ConnectionListener
    {
        private WorldManager Manager { get; set; }

        public Socket Socket { get; set; }

        public ConnectionListener(WorldManager manager)
        {
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            {
                NoDelay = true,
                UseOnlyOverlappedIO = true,
                Ttl = 112
            };
            Socket.Bind(new IPEndPoint(IPAddress.Any, 7171));
            Socket.Listen(0xFF);

            Manager = manager;
        }

        public void StartAccept() =>
            Socket.BeginAccept((IAsyncResult result) =>
            {
                var socket = Socket.EndAccept(result);

                if (socket != null)
                    Manager.Clients.Add(new Client(socket, Manager));

                StartAccept();
            }, null);

        public void EndAccept() => Socket.Close();
    }
}
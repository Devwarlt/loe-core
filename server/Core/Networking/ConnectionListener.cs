using LoESoft.Server.Core.World;
using System;
using System.Net;
using System.Net.Sockets;

namespace LoESoft.Server.Core.Networking
{
    public class ConnectionListener
    {
        public static IPEndPoint TcpEndPoint = new IPEndPoint(IPAddress.Any, 7171);
        public static IPEndPoint UdpEndPoint = new IPEndPoint(IPAddress.Any, 7271);

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
            Socket.Bind(TcpEndPoint);
            Socket.Listen(0xFF);

            Manager = manager;
        }

        public void StartAccept()
        {
            try
            {
                Socket.BeginAccept((IAsyncResult result) =>
                {
                    try
                    {
                        var socket = Socket.EndAccept(result);

                        if (socket != null)
                            Manager.Clients.Add(new Client(socket, Manager));

                        StartAccept();
                    }
                    catch (ObjectDisposedException) { }
                }, null);
            }
            catch (ObjectDisposedException) { }
        }

        public void EndAccept() => Socket.Close();
    }
}
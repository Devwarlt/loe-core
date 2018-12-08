using LoESoft.Server.Core.World;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace LoESoft.Server.Core.Networking
{
    public class ConnectionListener
    {
        private IPEndPoint TcpEndPoint => new IPEndPoint(IPAddress.Any, 7171);

        private WorldManager Manager { get; set; }

        public Socket TcpSocket { get; set; }

        public ConnectionListener(WorldManager manager)
        {
            TcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            {
                NoDelay = true,
                UseOnlyOverlappedIO = true,
                SendTimeout = 1000,
                ReceiveTimeout = 1000
            };
            TcpSocket.Bind(TcpEndPoint);
            TcpSocket.Listen(0xFF);
            Manager = manager;
        }

        public void StartAccept()
        {
            try
            {
                TcpSocket.BeginAccept(result =>
                {
                    var tcpSocket = TcpSocket.EndAccept(result);

                    if (tcpSocket != null)
                    {
                        var client = new Client(Manager)
                        {
                            Id = Interlocked.Increment(ref Client.LatestId),
                            TcpSocket = tcpSocket
                        };

                        client.Handle();
                    }

                    StartAccept();
                }, null);
            }
            catch (ObjectDisposedException) { }
        }

        public void EndAccept()
        {
            TcpSocket.Close();
            TcpSocket.Dispose();
        }
    }
}
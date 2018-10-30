using LoESoft.Server.Core.World;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace LoESoft.Server.Core.Networking
{
    public class ConnectionListener
    {
        public static ConcurrentDictionary<int, Client> Clients = new ConcurrentDictionary<int, Client>();

        private IPEndPoint TcpEndPoint => new IPEndPoint(IPAddress.Any, 7171);

        private WorldManager Manager { get; set; }

        public Socket TcpSocket { get; set; }

        public ConnectionListener(WorldManager manager)
        {
            TcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            {
                NoDelay = true,
                UseOnlyOverlappedIO = true,
                Ttl = 112
            };
            TcpSocket.Bind(TcpEndPoint);
            TcpSocket.Listen(0xFF);
            Manager = manager;

            new Thread(ConnectionManager) { IsBackground = true }.Start();
        }

        public void StartAccept()
        {
            try
            {
                TcpSocket.BeginAccept(result =>
                {
                    try
                    {
                        var tcpSocket = TcpSocket.EndAccept(result);

                        if (tcpSocket != null)
                        {
                            var client = new Client(Manager)
                            {
                                Id = Interlocked.Increment(ref Client.LatestId),
                                TcpSocket = tcpSocket
                            };

                            if (Clients.TryAdd(client.Id, client))
                                client.Handle();
                        }

                        StartAccept();
                    }
                    catch (ObjectDisposedException) { }
                }, null);
            }
            catch (ObjectDisposedException) { }
        }

        public void EndAccept()
        {
            Clients.Select(client => { client.Value.Disconnect(); return client; }).ToList();

            TcpSocket.Close();
            TcpSocket.Dispose();
        }

        public void ConnectionManager()
        {
            Clients.Select(client =>
            {
                if (!client.Value.IsConnected)
                    if (Clients.TryRemove(client.Value.Id, out Client invalidClient))
                        invalidClient.Disconnect();

                return client;
            }).ToList();

            Thread.Sleep(10 * 1000); // it's not even a thread priority for us due stability :)

            ConnectionManager();
        }
    }
}
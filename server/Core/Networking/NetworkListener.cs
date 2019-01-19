using LoESoft.Server.Core.World;
using LoESoft.Server.Settings;
using System;
using System.Net.Sockets;
using System.Threading;

namespace LoESoft.Server.Core.Networking
{
    public class NetworkListener
    {
        public Socket NetworkSocket { get; set; }

        public WorldManager Manager { get; set; }

        public static int CurrentClientId = 0;

        public NetworkListener(WorldManager manager)
        {
            NetworkSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            {
                NoDelay = true
            };

            Manager = manager;
        }

        public void Listen(int backlog = 100)
        {
            NetworkSocket.Bind(ServerSettings.ServerEndPoint);
            NetworkSocket.Listen(backlog);

            Begin(NetworkSocket);
        }

        private void Begin(Socket skt)
        {
            skt.BeginAccept(onAccept, NetworkSocket);
        }

        private void onAccept(IAsyncResult result)
        {
            var serverSkt = (Socket)result.AsyncState;
            var clientSkt = serverSkt.EndAccept(result);

            var client = new NetworkClient(clientSkt, Manager)
            {
                ClientId = Interlocked.Increment(ref CurrentClientId),
                IpAdress = clientSkt.RemoteEndPoint.ToString()
            };
            client.Start();

            App.Info($"New connection recieved! @{client.IpAdress} #{client.ClientId}");

            Begin(serverSkt);
        }
    }
}

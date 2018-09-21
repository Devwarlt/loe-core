using LoESoft.Server.Core.Networking.Packets.Incoming;
using LoESoft.Server.Core.Networking.Packets.Outgoing;
using LoESoft.Server.Core.World.Entities.Player;
using System;
using System.Net.Sockets;

namespace LoESoft.Server.Core.Networking
{
    public class Client
    {
        public Socket Socket { get; set; }
        public NetworkControl NetworkControl { get; set; }
        public Player Player { get; private set; }
        public string IpAddress { get; set; }

        public Client(Socket socket)
        {
            Socket = socket;

            IpAddress = socket.RemoteEndPoint.ToString().Split(':')[0];

            GameServer.Warn($"Client with IP '{IpAddress}' has connected!");

            NetworkControl = new NetworkControl(this, Socket);
            NetworkControl.ReceivePacket();

            Player = new Player(this);

            var value = new Random().Next();

            GameServer.Info($"Server is sending value '{value}' via Ping packet.");

            SendPacket(new Ping() { Value = value });
        }

        public void SendPacket(OutgoingPacket pkt) => NetworkControl.SendPacket(pkt);

        public void Disconnect()
        {
            Player.Dispose();
            Socket.Close();
        }
    }
}

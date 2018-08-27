using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Networking.Packets;
using LoESoft.Client.Core.Networking.Packets.Incoming;
using LoESoft.Client.Core.Networking.Packets.Outgoing;
using LoESoft.Client.Core.Screens;
using LoESoft.Client.Core.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace LoESoft.Client.Core.Networking
{
    public class NetworkControl
    {
        protected const int BUFFER_SIZE = ushort.MaxValue + 1;
        public const int MAX_CONNECTION_ATTEMPTS = 5;

        public Socket Socket { get; set; }
        public Server Server { get; set; }

        private GameUser GameUser { get; set; }
        private byte[] ReceiveBuffer { get; set; }
        private byte[] SendBuffer { get; set; }
        private Dictionary<PacketID, IncomingPacket> IncomingPackets { get; set; }
        private int ConnectionAttempt { get; set; }
        private bool Disconnected { get; set; }

        public NetworkControl(GameUser gameUser)
        {
            GameUser = gameUser;
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            {
                NoDelay = true,
                UseOnlyOverlappedIO = true,
                SendTimeout = 1000,
                ReceiveTimeout = 1000,
                Ttl = 112
            };
        }

        public void Connect(Server server)
        {
            if (Server == null)
                Server = server;
            Socket.BeginConnect(server.RemoteEndPoint, OnConnect, null);
        }

        private void OnConnect(IAsyncResult asyncResult)
        {
            ConnectionAttempt++;
            try
            {
                GameClient.Warn($"[Attempt {ConnectionAttempt}/{MAX_CONNECTION_ATTEMPTS}] Trying to connect to {Server}");
                Socket.EndConnect(asyncResult);
            }
            catch
            {
                if (ConnectionAttempt == MAX_CONNECTION_ATTEMPTS)
                {
                    GameClient.Warn($"Unable to connect to {Server}");
                    Disconnect();
                    return;
                }
                GameClient.Warn($"Failed to connect to {Server} retrying");
                Connect(Server);
                return;
            }
            GameClient.Warn($"Connected to {Server}");
            ReceivePacket();
        }

        public void SendPacket(OutgoingPacket outgoingPacket)
        {
            if (SendBuffer == null)
                SendBuffer = new byte[BUFFER_SIZE];

            var buffer = Encoding.UTF8.GetBytes(IO.ExportPacket(new PacketData()
            {
                PacketID = outgoingPacket.PacketID,
                Content = Regex.Replace(JsonConvert.SerializeObject(outgoingPacket), @"\r\n?|\n", string.Empty)
            }));

            Socket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, OnSend, null);
        }

        public void SendPackets(OutgoingPacket[] outgoingPackets)
        {
            for (var i = 0; i < outgoingPackets.Length; i++)
                SendPacket(outgoingPackets[i]);
        }

        private void OnSend(IAsyncResult asyncResult)
        {
            try
            {
                Socket.EndSend(asyncResult);
            }
            catch
            {
                Disconnect();
            }
        }

        public void ReceivePacket()
        {
            if (ReceiveBuffer == null)
                ReceiveBuffer = new byte[BUFFER_SIZE];
            Socket.BeginReceive(ReceiveBuffer, 0, ReceiveBuffer.Length, SocketFlags.None, OnReceivePacket, null);
        }

        private void OnReceivePacket(IAsyncResult asyncResult)
        {
            try
            {
                var len = Socket.EndReceive(asyncResult);

                var buffer = new byte[len];
                Array.Copy(ReceiveBuffer, buffer, len);

                var data = Encoding.UTF8.GetString(buffer);
                var packetData = JsonConvert.DeserializeObject<PacketData>(data);

                var incomingPacket = GetIncomingPacket(packetData);
                incomingPacket.Handle(GameUser);

                GameClient.Warn($"New packet received! {packetData.PacketID}");

                ReceivePacket();
            }
            catch
            {
                Disconnect();
            }
        }

        private void SetupIncomingPackets()
        {
            IncomingPackets = new Dictionary<PacketID, IncomingPacket>();
            foreach (var type in Assembly.GetAssembly(typeof(IncomingPacket)).GetTypes().Where(_ => _.IsClass && !_.IsAbstract && _.IsSubclassOf(typeof(IncomingPacket))))
            {
                var incomingMessage = (IncomingPacket)Activator.CreateInstance(type);
                IncomingPackets.Add(incomingMessage.PacketID, incomingMessage);
            }
        }

        private IncomingPacket GetIncomingPacket(PacketData packetData)
        {
            var packetID = packetData.PacketID;

            if (IncomingPackets == null)
                SetupIncomingPackets();
            if (!IncomingPackets.ContainsKey(packetID))
                throw new Exception($"Unknown IncomingPacket: {packetID}");
            return (IncomingPacket)JsonConvert.DeserializeObject(packetData.Content, IncomingPackets[packetID].GetType());
        }

        public void Disconnect()
        {
            if (Disconnected)
                return;
            Disconnected = true;
            ScreenManager.DispatchScreen(new SplashScreen());
            Socket.Close();
        }
    }
}

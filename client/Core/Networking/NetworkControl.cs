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
using System.Threading;

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
                Ttl = 112
            };
        }

        public bool IsConnected => Socket.Connected;

        public void Connect(Server server)
        {
            if (Server == null)
                Server = server;

            Socket.BeginConnect(server.RemoteEndPoint,
                (IAsyncResult result) =>
                {
                    try
                    {
                        ConnectionAttempt++;

                        try
                        {
                            GameClient.Warn($"[Attempt {ConnectionAttempt}/{MAX_CONNECTION_ATTEMPTS}] Trying to connect to {Server}");

                            Socket.EndConnect(result);
                        }
                        catch
                        {
                            if (ConnectionAttempt == MAX_CONNECTION_ATTEMPTS)
                            {
                                GameClient.Warn($"Unable to connect to {Server} due max number of invalid attempts reached the limit.");

                                Disconnect();

                                return;
                            }

                            GameClient.Warn($"Failed to connect to {Server}. Retrying...");

                            Connect(Server);

                            return;
                        }

                        GameClient.Info($"Connected to {Server}.");

                        Thread.Sleep(250);

                        ReceivePacket();
                    }
                    catch (SocketException) { }
                }, null);
        }

        private bool _firstMove = true;
        private float LastX;
        private float LastY;

        // Send move packet only if cached positions doesn't match and prevent unecessary move packets.
        private bool HandleMovePacket(ClientMove move)
        {
            if (_firstMove)
            {
                _firstMove = false;
                LastX = move.Player.X;
                LastY = move.Player.Y;
            }
            else if (LastX == move.Player.X && LastY == move.Player.Y)//Server hasnt sent move packet
                return false;
            else
            {
                LastX = move.Player.X;
                LastY = move.Player.Y;
            }
            return true;
        }

        public void SendPacket(OutgoingPacket outgoingPacket)
        {
            if (SendBuffer == null)
                SendBuffer = new byte[BUFFER_SIZE];

            var buffer = Encoding.UTF8.GetBytes(IO.ExportPacket(new PacketData()
            {
                PacketID = outgoingPacket.PacketID,
                Content = Regex.Replace(IO.ExportPacket(outgoingPacket), @"\r\n?|\n", string.Empty)
            }));

            if (outgoingPacket.PacketID == PacketID.CLIENTMOVE)
            {
                if (!HandleMovePacket(outgoingPacket as ClientMove))
                    return;
            }

            GameClient.Warn($"Sending {outgoingPacket.PacketID}");

            try
            {
                Socket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None,
                    (IAsyncResult result) =>
                    {
                        try { Socket.EndSend(result); }
                        catch (SocketException) { }
                    }, null);
            }
            catch (SocketException) { }
        }

        public void SendPackets(OutgoingPacket[] outgoingPackets)
        {
            for (var i = 0; i < outgoingPackets.Length; i++)
                SendPacket(outgoingPackets[i]);
        }

        public void ReceivePacket()
        {
            if (ReceiveBuffer == null)
                ReceiveBuffer = new byte[BUFFER_SIZE];

            Socket.BeginReceive(ReceiveBuffer, 0, ReceiveBuffer.Length, SocketFlags.None,
                (IAsyncResult result) =>
                {
                    try
                    {
                        var len = Socket.EndReceive(result);

                        var buffer = new byte[len];
                        Array.Copy(ReceiveBuffer, buffer, len);

                        var data = Encoding.UTF8.GetString(buffer);
                        var packetData = JsonConvert.DeserializeObject<PacketData>(data);

                        GetIncomingPacket(packetData).Handle(GameUser);

                        GameClient.Warn($"New packet received! Packet: {packetData.PacketID}");

                        ReceivePacket();
                    }
                    catch (SocketException) { }
                    catch (JsonReaderException) { }
                }, null);
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

            GameClient.Info("Client disconnected.");

            Disconnected = true;

            ScreenManager.DispatchScreen(new SplashScreen());

            Socket.Close();
        }
    }
}

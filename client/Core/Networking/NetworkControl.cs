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
        public const int MAX_CONNECTION_ATTEMPTS = 5;

        public Socket TcpSocket { get; set; }
        public UdpClient UdpClient { get; set; }
        public Server Server { get; set; }

        private const int BUFFER_SIZE = ushort.MaxValue + 1;

        private GameUser GameUser { get; set; }
        private byte[] ReceiveBuffer { get; set; }
        private byte[] SendBuffer { get; set; }
        private Dictionary<PacketID, IncomingPacket> IncomingPackets { get; set; }
        private int ConnectionAttempt { get; set; }
        private bool Disconnected { get; set; }

        public NetworkControl(GameUser gameUser)
        {
            GameUser = gameUser;
            TcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            {
                NoDelay = true,
                UseOnlyOverlappedIO = true,
                Ttl = 112
            };
            UdpClient = new UdpClient();
        }

        public bool IsConnected => TcpSocket.Connected;

        public void Connect(Server server)
        {
            if (Server == null)
                Server = server;

            TcpSocket.BeginConnect(server.TcpEndPoint,
                (IAsyncResult result) =>
                {
                    try
                    {
                        ConnectionAttempt++;

                        try
                        {
                            BrmeClient.Warn($"[Attempt {ConnectionAttempt}/{MAX_CONNECTION_ATTEMPTS}] Trying to connect to {Server}");

                            TcpSocket.EndConnect(result);
                        }
                        catch
                        {
                            if (ConnectionAttempt == MAX_CONNECTION_ATTEMPTS)
                            {
                                BrmeClient.Warn($"Unable to connect to {Server} due max number of invalid attempts reached the limit.");

                                Disconnect();

                                return;
                            }

                            BrmeClient.Warn($"Failed to connect to {Server}. Retrying...");

                            Connect(Server);

                            return;
                        }

                        BrmeClient.Info($"Connected to {Server}.");

                        Thread.Sleep(250);

                        ReceivePacket();
                    }
                    catch (SocketException) { }
                }, null);

            UdpClient.Connect(Server.UdpEndPoint);
        }

        public static bool _recievedServerMove = true;
        private static bool _firstMove = true;

        // Send move packet only if cached positions doesn't match and prevent unecessary move packets.
        private bool HandleMovePacket(ClientMove move)
        {
            if (_recievedServerMove == true)
            {
                _recievedServerMove = false;
                return true;
            }
            return false;
        }

        public void SendPacket(OutgoingPacket outgoingPacket)
        {
            if (!GameUser.IsConnected)
            {
                BrmeClient.Warn($"Client isn't connected! Disposing packet {outgoingPacket.PacketID}...");
                return;
            }

            if (SendBuffer == null)
                SendBuffer = new byte[BUFFER_SIZE];

            var buffer = Encoding.UTF8.GetBytes(IO.ExportPacket(new PacketData()
            {
                PacketID = outgoingPacket.PacketID,
                Content = Regex.Replace(IO.ExportPacket(outgoingPacket), @"\r\n?|\n", string.Empty)
            }));

            if (outgoingPacket.PacketID == PacketID.CLIENTMOVE)
                if (!HandleMovePacket(outgoingPacket as ClientMove))
                    return;

            BrmeClient.Warn($"Sending {outgoingPacket.PacketID}...");

            if (outgoingPacket is IUdpPacket)
            {
                UdpClient.BeginSend(buffer, buffer.Length, (IAsyncResult result) => UdpClient.EndSend(result), null);
                return;
            }

            try
            {
                TcpSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None,
                    (IAsyncResult result) =>
                    {
                        try { TcpSocket.EndSend(result); }
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

            TcpSocket.BeginReceive(ReceiveBuffer, 0, ReceiveBuffer.Length, SocketFlags.None,
                (IAsyncResult result) =>
                {
                    try
                    {
                        var len = TcpSocket.EndReceive(result);
                        var buffer = new byte[len];

                        Array.Copy(ReceiveBuffer, buffer, len);

                        var data = Encoding.UTF8.GetString(buffer);
                        var packetData = JsonConvert.DeserializeObject<PacketData>(data);

                        GetIncomingPacket(packetData).Handle(GameUser);

                        BrmeClient.Warn($"New packet received! Packet: {packetData.PacketID}");

                        ReceivePacket();
                    }
                    catch (SocketException) { }
                    catch (JsonReaderException) { }
                    catch (NullReferenceException) { }
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

            BrmeClient.Info("Client disconnected.");

            Disconnected = true;

            ScreenManager.DispatchScreen(new SplashScreen());

            TcpSocket.Close();
            TcpSocket.Dispose();

            UdpClient.Close();
            UdpClient.Dispose();
        }
    }
}
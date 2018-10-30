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
        public static bool ReceivedServerMove = true;

        public Socket TcpSocket { get; set; }
        public Server Server { get; set; }

        public bool IsConnected => TcpSocket.Connected;

        private const int BUFFER_SIZE = ushort.MaxValue + 1;

        private GameUser GameUser { get; set; }
        private byte[] Buffer { get; set; }
        private Dictionary<PacketID, IncomingPacket> IncomingPackets { get; set; }
        private int ConnectionAttempt { get; set; }
        private bool Disconnected { get; set; }

        public NetworkControl(GameUser gameUser, Server server)
        {
            GameUser = gameUser;
            Server = server;
            TcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            {
                NoDelay = true,
                UseOnlyOverlappedIO = true,
                SendTimeout = 1000,
                ReceiveTimeout = 1000
            };
        }

        public void Connect()
        {
            try
            {
                TcpSocket.BeginConnect(Server.TcpEndPoint, (result) =>
                {
                    ConnectionAttempt++;

                    App.Info($"[Attempt {ConnectionAttempt}] Connecting to {Server}...");

                    try
                    {
                        TcpSocket.EndConnect(result);

                        App.Info($"Connected to {Server}!");

                        ReceivePacket();
                    }
                    catch
                    {
                        Thread.Sleep(3000);

                        Connect();
                    }
                }, null);
            }
            catch
            {
                App.Info("Server is offline.");
            }
        }

        // Send move packet only if cached positions doesn't match and prevent unecessary move packets.
        private bool HandleMovePacket(ClientMove move)
        {
            if (ReceivedServerMove == true)
            {
                ReceivedServerMove = false;
                return true;
            }

            return false;
        }

        public void SendPacket(OutgoingPacket outgoingPacket)
        {
            App.Info($"Processing new outgoing packet...");

            if (!IsConnected && !Disconnected)
            {
                App.Warn($"Disposing packet {outgoingPacket.PacketID} and reconnecting...");

                Connect();

                return;
            }

            var buffer = Encoding.UTF8.GetBytes(IO.ExportPacket(new PacketData()
            {
                PacketID = outgoingPacket.PacketID,
                Content = Regex.Replace(IO.ExportPacket(outgoingPacket), @"\r\n?|\n", string.Empty)
            }));

            if (outgoingPacket.PacketID == PacketID.CLIENTMOVE)
                if (!HandleMovePacket(outgoingPacket as ClientMove))
                    return;

            App.Info($"Packet buffer length: {buffer.Length}");

            try
            {
                App.Info($"Sending {outgoingPacket.PacketID}...");

                TcpSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, (result) =>
                {
                    try
                    { TcpSocket.EndSend(result); }
                    catch (SocketException) { }
                    catch
                    {
                        if (!Disconnected)
                            App.Warn("Something went wrong!");
                    }
                }, null);
            }
            catch (SocketException) { }
            catch
            {
                if (!Disconnected)
                    App.Warn("Something went wrong!");
            }

            App.Info("Sent!");
        }

        public void SendPackets(IEnumerable<OutgoingPacket> outgoingPackets)
            => outgoingPackets.Select(outgoingPacket =>
            {
                SendPacket(outgoingPacket);
                return outgoingPacket;
            }).ToList();

        public void ReceivePacket()
        {
            if (Buffer == null)
                Buffer = new byte[BUFFER_SIZE];

            if (!IsConnected && !Disconnected)
            {
                App.Warn($"Reconnecting...");

                Connect();

                return;
            }
            try
            {
                TcpSocket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, (result) =>
                {
                    App.Info("Processing new incoming packet...");

                    try
                    {
                        var len = TcpSocket.EndReceive(result);
                        var buffer = new byte[len];

                        Array.Copy(Buffer, buffer, len);

                        var data = Encoding.UTF8.GetString(buffer);
                        var packetData = JsonConvert.DeserializeObject<PacketData>(data);

                        GetIncomingPacket(packetData).Handle(GameUser);

                        App.Warn($"New packet received! Packet: {packetData.PacketID}");

                        ReceivePacket();
                    }
                    catch (SocketException) { }
                    catch (JsonReaderException) { }
                    catch (NullReferenceException) { }
                    catch
                    {
                        if (!Disconnected)
                        {
                            App.Warn("Something went wrong!");

                            ReceivePacket();
                        }
                    }
                }, null);
            }
            catch
            {
                if (!Disconnected)
                {
                    App.Warn("Something went wrong!");

                    ReceivePacket();
                }
            }
        }

        private void SetupIncomingPackets()
        {
            IncomingPackets = new Dictionary<PacketID, IncomingPacket>();

            foreach (var type in Assembly.GetAssembly(typeof(IncomingPacket)).GetTypes().Where(_ => _.IsClass && !_.IsAbstract && _.IsSubclassOf(typeof(IncomingPacket))))
            {
                var incomingMessage = (IncomingPacket) Activator.CreateInstance(type);

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

            return (IncomingPacket) JsonConvert.DeserializeObject(packetData.Content, IncomingPackets[packetID].GetType());
        }

        public void Disconnect()
        {
            if (Disconnected)
                return;

            Disconnected = true;

            ScreenManager.DispatchScreen(new SplashScreen());

            TcpSocket?.Close();
            TcpSocket?.Dispose();

            App.Info("Client disconnected.");
        }
    }
}
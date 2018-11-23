using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Networking.Packets;
using LoESoft.Client.Core.Networking.Packets.Incoming;
using LoESoft.Client.Core.Networking.Packets.Outgoing;
using LoESoft.Client.Core.Screens;
using LoESoft.Client.Core.Utils;
using LoESoft.Dlls.GZip;
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

        private const int BUFFER_SIZE = 4096;

        private GameUser GameUser { get; set; }
        private byte[] Buffer { get; set; }
        private Dictionary<PacketID, IncomingPacket> IncomingPackets { get; set; }
        private int ConnectionAttempt { get; set; }
        private bool Disconnected { get; set; }
        private bool Reconnecting { get; set; }

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
            Reconnecting = true;
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

                        Reconnecting = false;

                        ReceivePacket();
                    }
                    catch
                    {
                        App.Info("Server is probably offline, retrying...");

                        Thread.Sleep(3000);

                        Connect();
                    }
                }, null);
            }
            catch
            {
                App.Info("Server is offline! Retrying...");

                Thread.Sleep(3000);

                Connect();
            }
        }

        public void SendPacket(OutgoingPacket outgoingPacket)
            => new Thread(() =>
            {
                if (!IsConnected)
                {
                    if (Reconnecting)
                        return;

                    if (!Disconnected)
                        App.Info($"Disposing packet {outgoingPacket.PacketID} and reconnecting...");

                    Reconnecting = true;

                    Connect();

                    return;
                }

                var buffer = GZipCompression.Zip(IO.ExportPacket(new PacketData()
                {
                    PacketID = outgoingPacket.PacketID,
                    Content = Regex.Replace(IO.ExportPacket(outgoingPacket), @"\r\n?|\n", string.Empty)
                }));

                try
                {
                    TcpSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, (result) =>
                    {
                        try
                        { TcpSocket.EndSend(result); }
                        catch { }
                    }, null);
                }
                catch (Exception ex) { App.Warn(ex.ToString()); }
            })
            { IsBackground = true }.Start();

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

            if (!IsConnected)
            {
                if (Reconnecting)
                    return;

                if (!Disconnected)
                    App.Info($"Reconnecting...");

                Reconnecting = true;

                Connect();

                return;
            }
            try
            {
                TcpSocket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, (result) =>
                {
                    try
                    {
                        var len = TcpSocket.EndReceive(result);
                        var buffer = new byte[len];

                        Array.Copy(Buffer, buffer, len);

                        var data = Encoding.UTF8.GetString(GZipCompression.UnZip(buffer));
                        var packetData = JsonConvert.DeserializeObject<PacketData>(data);

                        GetIncomingPacket(packetData).Handle(GameUser);

                        ReceivePacket();
                    }
                    catch
                    {
                        if (!Disconnected)
                            ReceivePacket();
                    }
                }, null);
            }
            catch (Exception ex)
            {
                if (!Disconnected)
                    ReceivePacket();

                App.Warn(ex.ToString());
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

            ScreenManager.DispatchScreen(GameApplication.CharacterScreen);

            TcpSocket?.Close();
            TcpSocket?.Dispose();

            App.Info("Client has left from the server network.");
        }
    }
}
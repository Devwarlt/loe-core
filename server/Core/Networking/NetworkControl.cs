using LoESoft.Server.Core.Networking.Packets;
using LoESoft.Server.Core.Networking.Packets.Incoming;
using LoESoft.Server.Core.Networking.Packets.Outgoing;
using LoESoft.Server.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace LoESoft.Server.Core.Networking
{
    public class NetworkControl
    {
        public Socket TcpSocket { get; set; }
        public UdpClient UdpClient { get; set; }
        public Client Client { get; set; }

        private const int BUFFER_SIZE = ushort.MaxValue + 1;
        private ManualResetEvent SafeDisconnect = new ManualResetEvent(false);

        private byte[] ReceiveBuffer { get; set; }
        private byte[] SendBuffer { get; set; }
        private Dictionary<PacketID, IncomingPacket> IncomingPackets { get; set; }

        public NetworkControl(Client client, Socket socket)
        {
            Client = client;
            TcpSocket = socket;
            UdpClient = new UdpClient(ConnectionListener.UdpEndPoint);
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

            try
            {
                TcpSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None,
                    (IAsyncResult result) =>
                    {
                        try { TcpSocket.EndAccept(result); }
                        catch (SocketException) { }
                        catch (ArgumentException) { }
                    }, null);
            }
            catch (SocketException) { }
        }

        public bool IsConnected => TcpSocket.Connected;

        public void SendPackets(OutgoingPacket[] outgoingPacket)
        {
            for (var i = 0; i < outgoingPacket.Length; i++)
                SendPacket(outgoingPacket[i]);
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

                        GetIncomingPacket(packetData).Handle(Client);

                        GameServer.Warn($"New packet received! Packet: {packetData.PacketID}");

                        ReceivePacket();
                    }
                    catch (SocketException) { }
                    catch (JsonReaderException) { }
                    catch (NullReferenceException) { }
                }, null);

            UdpClient.BeginReceive(
                (IAsyncResult result) =>
                {
                    try
                    {
                        var endPoint = (IPEndPoint)result.AsyncState;
                        var buffer = UdpClient.EndReceive(result, ref endPoint);
                        var data = Encoding.UTF8.GetString(buffer);
                        var packetData = JsonConvert.DeserializeObject<PacketData>(data);

                        GetIncomingPacket(packetData).Handle(Client);

                        GameServer.Warn($"New packet received! Packet: {packetData.PacketID}");

                        ReceivePacket();
                    }
                    catch (JsonReaderException) { }
                    catch (NullReferenceException) { }
                }, ConnectionListener.UdpEndPoint);
        }

        private void SetupIncomingPackets()
        {
            IncomingPackets = new Dictionary<PacketID, IncomingPacket>();

            foreach (var type in Assembly.GetAssembly(typeof(IncomingPacket)).GetTypes().Where(_ => _.IsClass && !_.IsAbstract && _.IsSubclassOf(typeof(IncomingPacket))))
            {
                try
                {
                    var incomingMessage = (IncomingPacket)Activator.CreateInstance(type);
                    IncomingPackets.Add(incomingMessage.PacketID, incomingMessage);
                }
                catch (ArgumentException) { continue; }
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
            GameServer.Info($"Disconnecting client '{Client.IpAddress}'...");

            SafeDisconnect.Set();

            ((IAsyncResult)Task.Run(() =>
            {
                try { Client.Player?.Save(); }
                catch (Exception e) { GameServer.Error(e); }

                SafeDisconnect.Reset();
            })).AsyncWaitHandle.WaitOne();

            SafeDisconnect.WaitOne();

            Client.Player?.Dispose();
            Client.Socket.Close();
            Client.Socket.Dispose();

            UdpClient.Close();
            UdpClient.Dispose();

            GameServer.Info($"Client disconnected '{Client.IpAddress}'.");
        }
    }
}
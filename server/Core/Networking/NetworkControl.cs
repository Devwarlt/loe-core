using LoESoft.Server.Core.Networking.Packets;
using LoESoft.Server.Core.Networking.Packets.Incoming;
using LoESoft.Server.Core.Networking.Packets.Outgoing;
using LoESoft.Server.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace LoESoft.Server.Core.Networking
{
    public class NetworkControl
    {
        public static int BUFFER_SIZE => ushort.MaxValue + 1;

        public Socket TcpSocket { get; set; }
        public Client Client { get; set; }

        private byte[] ReceiveBuffer { get; set; }
        private byte[] SendBuffer { get; set; }
        private Dictionary<PacketID, IncomingPacket> IncomingPackets { get; set; }

        public NetworkControl(Client client, Socket tcpSocket)
        {
            Client = client;
            TcpSocket = tcpSocket;
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
                TcpSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, result =>
                {
                    try
                    { TcpSocket.EndAccept(result); }
                    catch (SocketException) { }
                    catch (ArgumentException) { }
                }, null);
            }
            catch (SocketException) { }
        }

        public bool IsConnected => TcpSocket.Connected;

        public void SendPackets(OutgoingPacket[] outgoingPacket)
            => outgoingPacket.Select(packet => { SendPacket(packet); return packet; }).ToList();

        public void ReceivePacket()
        {
            if (ReceiveBuffer == null)
                ReceiveBuffer = new byte[BUFFER_SIZE];

            TcpSocket.BeginReceive(ReceiveBuffer, 0, ReceiveBuffer.Length, SocketFlags.None, result =>
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
        }

        private void SetupIncomingPackets()
        {
            IncomingPackets = new Dictionary<PacketID, IncomingPacket>();

            Assembly.GetAssembly(typeof(IncomingPacket)).GetTypes().Where(_ => _.IsClass && !_.IsAbstract && _.IsSubclassOf(typeof(IncomingPacket))).Select(type =>
            {
                try
                {
                    var incomingMessage = (IncomingPacket) Activator.CreateInstance(type);
                    IncomingPackets.Add(incomingMessage.PacketID, incomingMessage);
                }
                catch (ArgumentException) { }

                return type;
            }).ToList();
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
            Client.Player?.Save();
            Client.Player?.Dispose();
            Client.TcpSocket?.Close();
            Client.TcpSocket?.Dispose();

            GameServer.Info($"Client ID {Client.Id} has left.");
        }
    }
}
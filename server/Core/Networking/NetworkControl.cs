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
        protected const int BUFFER_SIZE = ushort.MaxValue + 1;

        public Socket Socket { get; set; }
        public Client Client { get; set; }

        private byte[] ReceiveBuffer { get; set; }
        private byte[] SendBuffer { get; set; }
        private Dictionary<PacketID, IncomingPacket> IncomingPackets { get; set; }

        public NetworkControl(Client client, Socket socket)
        {
            Socket = socket;
            Client = client;
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
                Socket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None,
                    (IAsyncResult result) =>
                    {
                        try { Socket.EndAccept(result); }
                        catch (SocketException) { }
                        catch (ArgumentException) { }
                    }, null);
            }
            catch (SocketException) { }
        }

        public bool IsConnected => Socket.Connected;

        public void SendPackets(OutgoingPacket[] outgoingPacket)
        {
            for (var i = 0; i < outgoingPacket.Length; i++)
                SendPacket(outgoingPacket[i]);
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
                        int len = Socket.EndReceive(result);
                        byte[] buffer = new byte[len];

                        Array.Copy(ReceiveBuffer, buffer, len);

                        string data = Encoding.UTF8.GetString(buffer);

                        PacketData packetData = JsonConvert.DeserializeObject<PacketData>(data);

                        GetIncomingPacket(packetData).Handle(Client);

                        GameServer.Warn($"New packet received! Packet: {packetData.PacketID}");

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
            GameServer.Warn($"Client disconnected '{Client.IpAddress}'.");

            Client.Player.Dispose();
            Client.Disconnect();
            Client.Socket.Close();
            Client.Socket.Dispose();
        }
    }
}

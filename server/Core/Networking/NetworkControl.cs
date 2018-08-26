using LoESoft.Server.Core.Networking.Packets;
using LoESoft.Server.Core.Networking.Packets.Incoming;
using LoESoft.Server.Core.Networking.Packets.Outgoing;
using LoESoft.Server.utils;
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
    internal class PacketData
    {
        public PacketID PacketID { get; set; }
        public string Content { get; set; }
    }

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

            GameServer.Warn($"Client with IP '{client.IpAddress}' has connected!");
        }

        public void SendPacket(OutgoingPacket outgoingPacket)
        {
            if(SendBuffer == null)
                SendBuffer = new byte[BUFFER_SIZE];

            var buffer = Encoding.UTF8.GetBytes(IO.ExportPacket(new PacketData()
            {
                PacketID = outgoingPacket.PacketID,
                Content = Regex.Replace(JsonConvert.SerializeObject(outgoingPacket), @"\r\n?|\n", string.Empty)
            }));

            Socket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, OnSend, null);
        }

        public void SendPackets(OutgoingPacket[] outgoingPacket)
        {
            for (var i = 0; i < outgoingPacket.Length; i++)
                SendPacket(outgoingPacket[i]);  
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
            if(ReceiveBuffer == null)
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
                incomingPacket.Handle(Client);

                GameServer.Warn($"New packet received!\n {packetData.PacketID}");

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
            GameServer.Warn($"Client disconnected {Client.IpAddress}");
            Client.Disconnect();
        }
    }
}

using LoESoft.Dlls.GZip;
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
        public static int BUFFER_SIZE => 4096;

        public bool IsConnected => TcpSocket.Connected;

        public Socket TcpSocket { get; set; }
        public Client Client { get; set; }

        private byte[] Buffer { get; set; }
        private Dictionary<PacketID, IncomingPacket> IncomingPackets { get; set; }
        private bool Disconnected { get; set; }

        public NetworkControl(Client client, Socket tcpSocket)
        {
            Client = client;
            TcpSocket = tcpSocket;
        }

        public void SendPacket(OutgoingPacket outgoingPacket)
        {
            if (!IsConnected)
            {
                if (!Disconnected)
                    App.Warn($"Disposing packet {outgoingPacket.PacketID} and client...");

                Disconnect();

                return;
            }

            var buffer = GZipCompression.Zip(IO.ExportPacket(new PacketData()
            {
                PacketID = outgoingPacket.PacketID,
                Content = Regex.Replace(IO.ExportPacket(outgoingPacket), @"\r\n?|\n", string.Empty)
            }));

            if (outgoingPacket is Update)
                App.Warn($"Update: {buffer.Length}");

            try
            {
                TcpSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, result =>
                {
                    try
                    { TcpSocket.EndAccept(result); }
                    catch (SocketException) { }
                    catch (ArgumentException) { }
                    catch (Exception ex)
                    {
                        if (!Disconnected)
                            App.Warn("Something went wrong!" + ex.ToString());
                    }
                }, null);
            }
            catch (SocketException) { }
            catch (Exception ex)
            {
                if (!Disconnected)
                    App.Warn("Something went wrong!" + ex.ToString());
            }
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

            if (!IsConnected)
            {
                if (!Disconnected)
                    App.Warn($"Disposing client...");

                Disconnect();

                return;
            }

            try
            {
                TcpSocket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, result =>
                {
                    try
                    {
                        var len = TcpSocket.EndReceive(result);
                        var buffer = new byte[len];

                        Array.Copy(Buffer, buffer, len);

                        var data = Encoding.UTF8.GetString(GZipCompression.UnZip(buffer));
                        var packetData = JsonConvert.DeserializeObject<PacketData>(data);

                        if (Client != null)
                            GetIncomingPacket(packetData).Handle(Client);

                        ReceivePacket();
                    }
                    catch (SocketException) { }
                    catch (JsonReaderException) { }
                    catch (NullReferenceException) { }
                    catch (Exception ex)
                    {
                        if (!Disconnected)
                        {
                            App.Warn("Something went wrong!" + ex.ToString());

                            ReceivePacket();
                        }
                    }
                }, null);
            }
            catch (Exception ex)
            {
                if (!Disconnected)
                {
                    App.Warn("Something went wrong!" + ex.ToString());

                    ReceivePacket();
                }
            }
        }

        private void SetupIncomingPackets()
        {
            IncomingPackets = new Dictionary<PacketID, IncomingPacket>();

            Assembly.GetAssembly(typeof(IncomingPacket)).GetTypes().Where(_ => _.IsClass && !_.IsAbstract && _.IsSubclassOf(typeof(IncomingPacket))).Select(type =>
            {
                try
                {
                    var incomingMessage = (IncomingPacket)Activator.CreateInstance(type);
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

            return (IncomingPacket)JsonConvert.DeserializeObject(packetData.Content, IncomingPackets[packetID].GetType());
        }

        public void Disconnect()
        {
            if (Disconnected)
                return;

            Client.Disconnect();
            Disconnected = true;

            App.Info($"Client ID {Client.Id} has left from the server.");
        }
    }
}
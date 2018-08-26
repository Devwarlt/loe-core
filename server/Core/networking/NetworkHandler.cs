using LoESoft.Server.Core.client;
using LoESoft.Server.Core.networking.packet;
using LoESoft.Server.Core.networking.packet.client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace LoESoft.Server.Core.networking
{
    internal class NetworkHandler
    {
        public static byte[] _buffer => new byte[1024];

        private Client _client { get; set; }
        private Thread _packetThread { get; set; }

        public NetworkHandler(Client client)
        {
            _client = client;
            _packetThread = new Thread(SendPendingPackets) { IsBackground = true };
        }

        public void Start()
        {
            _client._socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), _client._socket);
            _packetThread.Start();
        }

        public void SendCallback(IAsyncResult asyncResult)
        {
            Socket socket = (Socket)asyncResult.AsyncState;
            socket.EndSend(asyncResult);
        }

        public void ReceiveCallback(IAsyncResult asyncResult)
        {
            try
            {
                int received = ((Socket)asyncResult.AsyncState).EndReceive(asyncResult);
                byte[] dataBuff = new byte[received];

                Array.Copy(_buffer, dataBuff, received);

                string data = Encoding.UTF8.GetString(dataBuff);

                if (!string.IsNullOrEmpty(data))
                {
                    try
                    {
                        PacketData packetData = JsonConvert.DeserializeObject<PacketData>(data);
                        Packet packet = Packet.ClientPackets[packetData.PacketID];
                        packet.CreateInstance();

                        GameServer.Info($"New packet received!\n{packet.ToString()}");

                        _client._pendingPacket.Enqueue(packet as ClientPacket);
                    }
                    catch (Exception e) { GameServer.Error(e, $"Data: {data}"); }
                }
            }
            catch (ObjectDisposedException) { }
        }

        private void SendPendingPackets()
        {
            while (_client._socket != null)
            {
                if (_client._socket.Connected)
                {
                    if (_client._pendingPacket.Count != 0)
                        foreach (var i in _client._pendingPacket)
                        {
                            _client._pendingPacket.TryDequeue(out ClientPacket clientPacket);
                            try { Packet.ClientPacketHandlers[clientPacket.ID].Handle(_client, clientPacket); }
                            catch (KeyNotFoundException) { }
                        }
                    else
                        Thread.Sleep(100);
                }
                else
                    break;
            }
        }
    }
}

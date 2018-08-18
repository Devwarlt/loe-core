﻿using LoESoft.Log;
using LoESoft.Server.client;
using LoESoft.Server.networking.packet;
using LoESoft.Server.networking.packet.client;
using Newtonsoft.Json;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace LoESoft.Server.networking
{
    internal class NetworkHandler
    {
        public static Info _info => new Info(nameof(NetworkHandler));
        public static Warn _warn => new Warn(nameof(NetworkHandler));
        public static Error _error => new Error(nameof(NetworkHandler));
        public static byte[] _buffer => new byte[1024];

        private Client _client { get; set; }
        private Thread _packetProcessing { get; set; }

        public NetworkHandler(Client client)
        {
            _client = client;
            _packetProcessing = new Thread(() =>
            {
                while (_client._socket != null)
                {
                    if (_client._socket.Connected)
                    {
                        if (_client._pendingPacket.Count != 0)
                            foreach (var i in _client._pendingPacket)
                            {
                                _client._pendingPacket.TryDequeue(out ClientPacket clientPacket);
                                Packet.ClientPacketHandlers[clientPacket.ID].Handle(_client, clientPacket);
                            }
                        else
                            Thread.Sleep(100);
                    }
                    else
                        break;
                }
            });
        }

        public void Start()
        {
            _client._socket.NoDelay = true;
            _client._socket.UseOnlyOverlappedIO = true;
            _client._socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), _client._socket);
            _packetProcessing.Start();
        }

        public void SendCallback(IAsyncResult asyncResult)
        {
            Socket socket = (Socket)asyncResult.AsyncState;
            socket.EndSend(asyncResult);
        }

        public void ReceiveCallback(IAsyncResult asyncResult)
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
                    Packet packet = Packet.ClientMessages[packetData.PacketID];
                    packet.CreateInstance();

                    _info.Write($"New message received!\n{packet.ToString()}");
                    _client._pendingPacket.Enqueue(packet as ClientPacket);
                }
                catch (Exception e)
                {
                    _error.Write($"Data: {data}\n{e}");
                    _error.Export();
                }
            }
        }
    }
}

using LoESoft.Log;
using LoESoft.Server.client;
using LoESoft.Server.networking.packet;
using LoESoft.Server.networking.packet.client;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace LoESoft.Server.networking
{
    public class NetworkHandler
    {
        public static Info _info => new Info(nameof(NetworkHandler));
        public static Warn _warn => new Warn(nameof(NetworkHandler));
        public static Error _error => new Error(nameof(NetworkHandler));

        private Client _client { get; set; }
        private ConcurrentBag<ClientPacket> _pendingPacket { get; set; }
        private Thread _packetProcessing { get; set; }

        private byte[] _buffer => new byte[1024];

        public NetworkHandler(Client client)
        {
            _client = client;
            _pendingPacket = new ConcurrentBag<ClientPacket>();
            _packetProcessing = new Thread(() =>
            {
                while (_client._socket.Connected)
                {
                    if (_pendingPacket.Count != 0)
                        foreach (var i in _pendingPacket)
                        {
                            _pendingPacket.TryTake(out ClientPacket clientPacket);
                            Packet.ClientPacketHandlers[clientPacket.ID].Handle(_client, clientPacket);
                        }
                    else
                        Thread.Sleep(100);
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

        private void ReceiveCallback(IAsyncResult asyncResult)
        {
            int received = ((Socket)asyncResult.AsyncState).EndReceive(asyncResult);
            byte[] dataBuff = new byte[received];

            Array.Copy(_buffer, dataBuff, received);

            string data = Encoding.UTF8.GetString(dataBuff);

            if (!string.IsNullOrEmpty(data))
            {
                try
                {
                    // TODO: enqueue client packet to network pending messages.
                    PacketData packetData = JsonConvert.DeserializeObject<PacketData>(data);
                    Packet packet = Packet.ClientMessages[packetData.PacketID];
                    packet.CreateInstance();

                    _info.Write($"New message received!\n{packet.ToString()}");
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

using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Networking.Packets;
using LoESoft.Client.Core.Networking.Packets.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace LoESoft.Client.Core.Networking
{
    internal class NetworkHandler
    {
        public static byte[] _buffer => new byte[1024];
        public static int _connectionRetryMS => 2 * 000;
        public static int _connectionAttempts { get; set; } = 0;
        public static Semaphore _networkHandlerSemaphore = new Semaphore(1, 1);
        public static AutoResetEvent _connectionEvent = new AutoResetEvent(false);

        private static Socket _socket { get; set; }
        private static Server _server { get; set; }

        private GameUser _gameUser { get; set; }
        private Thread _packetProcessing { get; set; }

        public NetworkHandler(GameUser gameUser, Server server)
        {
            _gameUser = gameUser;
            _packetProcessing = new Thread(() =>
            {
                while (_gameUser._socket != null)
                {
                    if (_gameUser._socket.Connected)
                    {
                        if (_gameUser._pendingPacket.Count != 0)
                            foreach (var i in _gameUser._pendingPacket)
                            {
                                _gameUser._pendingPacket.TryDequeue(out ServerPacket serverPacket);
                                try { Packet.ServerPacketHandlers[serverPacket.ID].Handle(_gameUser, serverPacket); }
                                catch (KeyNotFoundException) { }
                            }
                        else
                            Thread.Sleep(100);
                    }
                    else
                        break;
                }
            })
            { IsBackground = true };

            _socket = _gameUser._socket;
            _socket.NoDelay = true;
            _socket.UseOnlyOverlappedIO = true;
            _socket.SendTimeout = 1000;
            _socket.ReceiveTimeout = 1000;
            _socket.Ttl = 112;
            _server = server;
        }

        public void Start() => _packetProcessing.Start();

        public void HandlePacket()
        {
            int received = _socket.Receive(_buffer);
            byte[] dataBuff = new byte[received];

            Array.Copy(_buffer, dataBuff, received);

            string data = Encoding.UTF8.GetString(dataBuff);

            if (!string.IsNullOrEmpty(data))
            {
                try
                {
                    PacketData packetData = JsonConvert.DeserializeObject<PacketData>(data);
                    Packet packet = Packet.ServerPackets[packetData.PacketID];
                    packet.CreateInstance();

                    GameClient.Info($"New packet received!\n{packet.ToString()}");

                    _gameUser._pendingPacket.Enqueue(packet as ServerPacket);
                }
                catch (Exception e) { GameClient.Error(e, $"Data: {data}"); }
            }
        }

        public static void BeginConnect()
        {
            NetworkManager._networkManagerDisposeSemaphore.WaitOne();

            _networkHandlerSemaphore.WaitOne();

            GameClient.Info("Attempting to connect to the game server...");

            while (!_socket.Connected && !NetworkManager._dispose)
            {
                _connectionAttempts++;
                
                try { _socket.Connect(_server._dns, _server._port); }
                catch { GameClient.Warn($"[Attempts: {_connectionAttempts}] Connection failed. Retrying..."); }

                Thread.Sleep(_connectionRetryMS);
            }

            if (!NetworkManager._dispose)
            {
                GameClient.Warn($"[Attempts: {_connectionAttempts}] The game client has been connected to IP '{_server._dns}' via port '{_server._port}'!");
                GameClient.Info("Connecting to the game server... OK!");

                _networkHandlerSemaphore.Release();

                NetworkManager._networkManagerDisposeSemaphore.Release();
            }
        }
    }
}

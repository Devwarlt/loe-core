using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Networking.Packets;
using LoESoft.Client.Core.Networking.Packets.Server;
using LoESoft.Client.Core.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LoESoft.Client.Core.Networking
{
    internal class NetworkHandler
    {
        public byte[] _buffer => new byte[1024];
        public int _connectionRetryMS => 2 * 000;
        public int _connectionAttempts { get; private set; } = 0;
        public Semaphore _networkHandlerSemaphore = new Semaphore(1, 1);
        public AutoResetEvent _connectionEvent = new AutoResetEvent(false);

        private GameUser _gameUser { get; set; }
        private Thread _connectionThread { get; set; }
        private Thread _packetThread { get; set; }

        public NetworkHandler(GameUser gameUser)
        {
            _gameUser = gameUser;
            _connectionThread = new Thread(BeginConnect) { IsBackground = true };
            _packetThread = new Thread(SendPendingPackets) { IsBackground = true };
        }

        public void Start()
        {
            _connectionThread.Start();
            _packetThread.Start();
        }

        public void HandlePacket()
        {
            int received = _gameUser._socket.Receive(_buffer);
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

        public void OnConnectionLost(object data, SocketEventArgs e)
        {
            GameClient.Warn(
                TextLabel.GetText(
                    (TextType)data,
                    TextLabel.AddParams(
                        new TextParams(LabelType.ATTEMPTS, _connectionAttempts)
                        )
                    )
                );

            Thread reconnectThread = new Thread(BeginConnect) { IsBackground = true };
            reconnectThread.Start();
        }

        private void BeginConnect()
        {
            NetworkManager._networkManagerDisposeSemaphore.WaitOne();

            _networkHandlerSemaphore.WaitOne();

            GameClient.Info(TextLabel.GetText(TextType.CONNECTION_ATTEMPT_TO_CONNECT));

            while (!_gameUser._socket.Connected && !NetworkManager._dispose)
            {
                _connectionAttempts++;

                try { _gameUser._socket.Connect(_gameUser._server._dns, _gameUser._server._port); }
                catch { GameClient.Warn(TextLabel.GetText(TextType.CONNECTION_FAILED_WITH_ATTEMPTS, TextLabel.AddParams(new TextParams(LabelType.ATTEMPTS, _connectionAttempts)))); }

                Thread.Sleep(_connectionRetryMS);
            }

            if (!NetworkManager._dispose)
            {
                GameClient.Warn(
                    TextLabel.GetText(
                        TextType.CONNECTION_STABLISHED,
                        TextLabel.AddParams(new TextParams[]
                            {
                                new TextParams(LabelType.ATTEMPTS, _connectionAttempts),
                                new TextParams(LabelType.DNS, _gameUser._server._dns),
                                new TextParams(LabelType.PORT, _gameUser._server._port)
                            })
                        )
                    );
                GameClient.Info("Connecting to the game server... OK!");

                _networkHandlerSemaphore.Release();

                NetworkManager._networkManagerDisposeSemaphore.Release();
            }
        }

        private void SendPendingPackets()
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
                            catch (KeyNotFoundException) { continue; }
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

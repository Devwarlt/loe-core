using LoESoft.Client.Core.client;
using LoESoft.Client.Core.networking.packets;
using Newtonsoft.Json;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace LoESoft.Client.Core.networking
{
    public class NetworkHandler
    {
        public static byte[] _buffer { get; } = new byte[1024];
        public static int _connectionTimeout { get; } = 3000;
        public static int _connectionAttempts { get; set; } = 0;
        public static Semaphore _networkHandlerSemaphore { get; } = new Semaphore(1, 1);
        public static Semaphore _connectionThreadSemaphore { get; } = new Semaphore(1, 1);

        private static Socket _socket { get; set; }
        private static Server _server { get; set; }

        public NetworkHandler(GameUser gameUser, Server server)
        {
            _socket = gameUser._socket;
            _socket.NoDelay = true;
            _socket.UseOnlyOverlappedIO = true;
            _socket.SendTimeout = 1000;
            _socket.ReceiveTimeout = 1000;
            _socket.Ttl = 112;

            _server = server;
        }

        public void HandlePacket()
        {
            int received = _socket.Receive(_buffer);
            byte[] dataBuff = new byte[received];

            Array.Copy(_buffer, dataBuff, received);

            string data = Encoding.UTF8.GetString(dataBuff);

            if (!string.IsNullOrEmpty(data))
            {
                // TODO: implement packet handler here.
                GameClient._log.Info($"New packet received!\n{data}");
            }
        }

        public static void BeginConnect()
        {
            NetworkManager._networkManagerDisposeSemaphore.WaitOne();

            _networkHandlerSemaphore.WaitOne();

            GameClient._log.Info("Connecting to the game server...");

            while (!_socket.Connected && !NetworkManager._dispose)
            {
                if (_socket == null)
                    break;

                try
                {
                    _connectionAttempts++;

                    Thread connectionThread = new Thread(() =>
                    {
                        _connectionThreadSemaphore.WaitOne();

                        try { _socket.Connect(_server._dns, _server._port); }
                        catch (ObjectDisposedException) { }
                        catch (SocketException) { }

                        _connectionThreadSemaphore.Release();
                    })
                    { IsBackground = true };
                    connectionThread.Start();
                    connectionThread.Join(_connectionTimeout);

                    if (!_socket.Connected)
                        throw new SocketException((int)SocketError.TimedOut);
                }
                catch (ObjectDisposedException) { }
                catch (SocketException e)
                {
                    if (!NetworkManager._dispose)
                    {
                        if (e.SocketErrorCode == SocketError.TimedOut)
                            GameClient._log.Warn($"[Attempts: {_connectionAttempts}] Connection timeout. Retrying...");
                        else
                            GameClient._log.Warn($"[Attempts: {_connectionAttempts}] Connection failed. Retrying...");
                    }
                }
            }

            if (!NetworkManager._dispose)
            {
                GameClient._log.Warn($"[Attempts: {_connectionAttempts}] The game client has been connected to IP '{_server._dns}' via port '{_server._port}'!");
                GameClient._log.Info("Connecting to the game server... OK!");

                _networkHandlerSemaphore.Release();

                NetworkManager._networkManagerDisposeSemaphore.Release();
            }
        }
    }
}

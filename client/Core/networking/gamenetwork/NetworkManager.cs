﻿using System;
using System.Net.Sockets;
using System.Threading;

namespace LoESoft.Client.Core.networking.gamenetwork
{
    public class NetworkManager : IDisposable
    {
        public static bool _dispose { get; private set; } = false;
        public static Semaphore _networkManagerDisposeSemaphore { get; set; } = new Semaphore(1, 1);

        public Server _server { get; set; } = Server.GetServers["Local Server"];
        public NetworkHandler _networkHandler { get; private set; }

        private static Socket _socket { get; set; } = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public NetworkManager()
        {
            _networkHandler = new NetworkHandler(_socket, _server);
        }

        public void Start()
            => Connect();

        private static void Connect()
        {
            Thread networkBackgroundThread = new Thread(NetworkHandler.BeginConnect)
            {
                IsBackground = true
            };
            networkBackgroundThread.Start();
        }

        private static void Reconnect()
        {
            GameClient._log.Warn($"Client dropped connection to the server, retrying...");

            NetworkHandler._connectionAttempts = 0;

            Connect();
        }

        public void Dispose()
        {
            _dispose = true;

            GameClient._log.Info("Network Manager has been stopped.");

            _socket.Close();
            _socket.Dispose();
        }
    }
}

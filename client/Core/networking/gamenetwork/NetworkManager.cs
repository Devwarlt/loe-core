﻿using System;
using System.Net.Sockets;
using System.Threading;

namespace LoESoft.Client.Core.networking.gamenetwork
{
    public class NetworkManager : IDisposable
    {
        public Server _server { get; set; } = Server.GetServers["Test Server"];
        public NetworkHandler _networkHandler { get; private set; }

        private Socket _socket { get; set; } = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

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

        public void Reconnect()
        {
            NetworkHandler._connectionAttempts = 0;

            Connect();
        }

        public void Dispose()
        {
            GameClient._log.Info("Network Manager has been stopped.");

            _socket.Close();
        }
    }
}
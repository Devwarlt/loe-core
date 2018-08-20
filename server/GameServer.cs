﻿using LoESoft.Server.Core.networking;
using LoESoft.Server.settings;
using LoESoft.Server.utils;
using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Reflection;
using System.Threading;

namespace LoESoft.Server
{
    public class GameServer
    {
        // Assembly's Data
        public static string _name => Assembly.GetExecutingAssembly().GetName().Name;
        public static string _version => $"{Assembly.GetExecutingAssembly().GetName().Version}";

        // Log
        public static Logger _log { get; } = LogManager.GetLogger(_name);

        // Settings
        public static Settings _settings => IO.Import<Settings>("../../", "Settings");

        // Networking
        private static NetworkManager _networkManager { get; set; }

        public static void Main(string[] args)
        {
            Console.Title = $"{_name} - Build: {_version}";

            var config = new LoggingConfiguration();
            var developerLog = new ColoredConsoleTarget()
            {
                Name = "developer",
                Layout = @"[${date:format=HH\:mm\:ss}] ${level} ${message} ${exception}"
            };
            var developerFile = new FileTarget()
            {
                Name = "developer-file",
                FileName = "../../../logs/server/Build ${assembly-version}/${level}/${date:format=dd-MM-yyyy HH.mm.ss}.txt",
                Layout = @"[${date:format=HH\:mm\:ss}] ${level} ${message} ${exception}"
            };
            config.AddTarget(developerLog);
            config.AddTarget(developerFile);
            config.AddRule(LogLevel.Info, LogLevel.Fatal, developerFile);
            config.AddRuleForAllLevels(developerLog);

            LogManager.Configuration = config;

            _log.Info("Game Server is loading...");

            try
            {
                _networkManager = new NetworkManager(_settings._tcpServer);
                _networkManager.Start();

                _log.Info("Game Server is loading... OK!");

                while (Console.ReadKey(true).Key != ConsoleKey.Escape) ;

                _networkManager.Dispose();

                _log.Info("Game Server has been stopped.");

                Environment.Exit(0);
            }
            catch (Exception e)
            {
                _log.Info("An error occurred!");

                _log.Error(e.ToString());

                Thread.Sleep(100);

                _log.Warn("Press 'ESC' to close...");

                while (Console.ReadKey(true).Key != ConsoleKey.Escape) ;

                Environment.Exit(0);
            }
        }
    }
}

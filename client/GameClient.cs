﻿using LoESoft.Client.Core.Networking;
using NLog;
using NLog.Config;
using NLog.Targets;
using Rollbar;
using System;
using System.Reflection;
using System.Threading;

namespace LoESoft.Client
{
    public static class GameClient
    {
        // Assembly's Data
        public static string _name => Assembly.GetExecutingAssembly().GetName().Name;
        public static string _version => $"{Assembly.GetExecutingAssembly().GetName().Version}";

        // Log
        private static Logger _log => LogManager.GetLogger(_name);
        private static string _rollbarId => "ca02c5d9fb834c33880af31a6407fa18";

        // Network
        public static NetworkManager _networkManager { get; private set; }

        [STAThread]
        static void Main()
        {
            Console.Title = $"{_name} Console - Build: {_version}";

            var config = new LoggingConfiguration();
            var developerLog = new ColoredConsoleTarget()
            {
                Name = "developer",
                Layout = @"[${date:format=HH\:mm\:ss}] [${level}] ${message} ${exception}"
            };
            var developerFile = new FileTarget()
            {
                Name = "developer-file",
                FileName = "../../../../../logs/client/Build ${assembly-version}/${level}/${date:format=dd-MM-yyyy HH.mm.ss}.txt",
                Layout = @"[${date:format=HH\:mm\:ss}] [${level}] ${message} ${exception}"
            };
            config.AddTarget(developerLog);
            config.AddTarget(developerFile);
            config.AddRule(LogLevel.Info, LogLevel.Fatal, developerFile);
            config.AddRuleForAllLevels(developerLog);

            LogManager.Configuration = config;

            RollbarLocator.RollbarInstance.Configure(new RollbarConfig(_rollbarId));

            Info("Game Client is loading...");

            try
            {
                Info("Network Manager is loading...");

                _networkManager = new NetworkManager();
                //_networkManager.Start();

                Info("Network Manager is loading... OK!");
                Info("Game Client is loading... OK!");

                using (var game = new GameApplication())
                    game.Run();
            }
            catch (Exception e)
            {
                Info("An error occurred!");

                Error(e);

                Thread.Sleep(100);

                Warn("Press 'ESC' to close...");

                while (Console.ReadKey(true).Key != ConsoleKey.Escape) ;

                Environment.Exit(0);
            }
        }

        public static void Info(string data) => _log.Info(data);

        public static void Warn(string data) => _log.Warn(data);

        public static void Error(Exception e, string data = null)
        {
            _log.Error($"{data}{(data == null ? "" : "\n")}{e.ToString()}");

#if DEBUG
            // Rollbar error analytics for developers only.
            RollbarLocator.RollbarInstance.Error(e);
#endif
        }
    }
}

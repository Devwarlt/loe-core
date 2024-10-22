﻿using LoESoft.Dlls.Utils;
using LoESoft.Server.Assets.Xml;
using LoESoft.Server.Core.Database;
using LoESoft.Server.Core.Networking;
using LoESoft.Server.Core.World;
using LoESoft.Server.Core.World.Map.Structure;
using NLog;
using NLog.Config;
using NLog.Targets;
using Rollbar;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace LoESoft.Server
{
    public class App
    {
        // Assembly's Data
        public static string Name => Assembly.GetExecutingAssembly().GetName().Name;

        public static string Version =>
            $"{Assembly.GetExecutingAssembly().GetName().Version}".Substring(0,
            $"{Assembly.GetExecutingAssembly().GetName().Version}".Length - 2);

        // Log
        private static Logger Log => LogManager.GetLogger(Name);

        private static string RollbarId => "ca02c5d9fb834c33880af31a6407fa18";

        // Database
        public static Database Database { get; set; }

        // DLL Utils
        public static Util LoEUtils { get; set; }

        public static void Main(string[] args)
        {
            Console.Title = $"{Name} - Build: {Version}";

            var config = new LoggingConfiguration();
            var developerLog = new ColoredConsoleTarget()
            {
                Name = "developer",
                Layout = @"[${date:format=HH\:mm\:ss}] [${level}] ${message} ${exception}"
            };
            var developerFile = new FileTarget()
            {
                Name = "developer-file",
                FileName = "../../../logs/server/Build ${assembly-version}/${level}/${date:format=dd-MM-yyyy}.txt",
                Layout = @"[${date:format=HH\:mm\:ss}] [${level}] ${message} ${exception}"
            };
            config.AddTarget(developerLog);
            config.AddTarget(developerFile);
            config.AddRule(LogLevel.Info, LogLevel.Fatal, developerFile);
            config.AddRuleForAllLevels(developerLog);

            LogManager.Configuration = config;

            RollbarLocator.RollbarInstance.Configure(new RollbarConfig(RollbarId));

            Info("Game Server is loading...");

            XmlLibrary.Init();

            Database = new Database();
            LoEUtils = new Util((message) => Warn(message));

            try
            {
                Map.BinaryMapsCache = new Dictionary<string, KeyValuePair<bool, byte[]>>();
                Map.LoadEmbeddedMaps();

                var manager = new WorldManager();
                var connection = new NetworkListener(manager);
                NetworkProccessor.Start();

                connection.Listen();

                manager.BeginUpdate();

                Info("Game Server is loading... OK!");

                while (Console.ReadKey(true).Key != ConsoleKey.Escape)
                    ;

                Database.Dispose();

                Info("Game Server has been stopped.");

                Environment.Exit(0);
            }
            catch (Exception e)
            {
                Database.Dispose();

                Warn($"An error occurred! {e.ToString()}");

                Error(e);

                Thread.Sleep(100);

                Warn("Press 'ESC' to close...");

                while (Console.ReadKey(true).Key != ConsoleKey.Escape)
                    ;

                Environment.Exit(-1);
            }
        }

        public static void Info(string data) => Log.Info(data);

        public static void Warn(string data) => Log.Warn(data);

        public static void Error(Exception e, string data = null)
        {
            Log.Error($"{data}{(data == null ? "" : "\n")}{e.ToString()}");

            RollbarLocator.RollbarInstance.Error(e); // Rollbar error analytics for developers only.
        }
    }
}
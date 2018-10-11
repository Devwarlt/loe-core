using LoESoft.WebServer.Core.Database;
using LoESoft.WebServer.Core.Networking;
using LoESoft.WebServer.Core.Utils;
using NLog;
using NLog.Config;
using NLog.Targets;
using Rollbar;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace LoESoft.WebServer
{
    public class GameWebServer
    {
        // Assembly's Data
        public static string _name => Assembly.GetExecutingAssembly().GetName().Name;
        public static string _version =>
            $"{Assembly.GetExecutingAssembly().GetName().Version}".Substring(0,
            $"{Assembly.GetExecutingAssembly().GetName().Version}".Length - 2);

        // Log
        private static Logger _log => LogManager.GetLogger(_name);
        private static string _rollbarId => "ca02c5d9fb834c33880af31a6407fa18";

        // Database
        public static Database _database { get; set; }

        // Versions
        public static List<GameVersion> _gameVersions => new List<GameVersion>()
        {
            new GameVersion(Version: "0.1.0", Allowed: false, Link: "0.1.X/test-archive.zip"),
            new GameVersion(Version: "0.1.1", Allowed: false, Link: "0.1.X/test-archive.zip"),
            new GameVersion(Version: "0.1.2", Allowed: false, Link: "0.1.X/test-archive.zip"),
            new GameVersion(Version: "0.1.3", Allowed: false, Link: "0.1.X/test-archive.zip"),
            new GameVersion(Version: "0.1.4", Allowed: false, Link: "0.1.X/test-archive.zip"),
            new GameVersion(Version: "0.1.5", Allowed: true, Link: "0.1.X/test-archive.zip")
        };

        public static void Main(string[] args)
        {
            Console.Title = $"{_name} - Build: {_version}";

            var config = new LoggingConfiguration();
            var developerLog = new ColoredConsoleTarget()
            {
                Name = "developer",
                Layout = @"[${date:format=HH\:mm\:ss}] [${level}] ${message} ${exception}"
            };
            var developerFile = new FileTarget()
            {
                Name = "developer-file",
                FileName = "../../../logs/webserver/Build ${assembly-version}/${level}/${date:format=dd-MM-yyyy HH.mm.ss}.txt",
                Layout = @"[${date:format=HH\:mm\:ss}] [${level}] ${message} ${exception}"
            };
            config.AddTarget(developerLog);
            config.AddTarget(developerFile);
            config.AddRule(LogLevel.Info, LogLevel.Fatal, developerFile);
            config.AddRuleForAllLevels(developerLog);

            LogManager.Configuration = config;

            RollbarLocator.RollbarInstance.Configure(new RollbarConfig(_rollbarId));

            Info("Game Web Server is loading...");

            try
            {
                List<GameVersion> available = GameVersion.Available;
                List<GameVersion> supported = GameVersion.Supported;

                Info($"Game versions ({available.Count}/{supported.Count} available):");

                for (int i = supported.Count - 1; i >= 0; i--)
                    Info($"* [Access: {supported[i].Allowed}]\t{supported[i].Version}");

                _database = new Database();
                _database.Connect();

                var connectionListener = new ConnectionListener();
                connectionListener.StartAccept();

                Info("Game Web Server is loading... OK!");

                while (Console.ReadKey(true).Key != ConsoleKey.Escape) ;

                _database.Disconnect();

                connectionListener.EndAccept();

                Info("Game Web Server has been stopped.");

                Environment.Exit(0);
            }
            catch (Exception e)
            {
                Info("An error occurred!");

                Error(e);

                Thread.Sleep(100);

                Warn("Press 'ESC' to close...");

                while (Console.ReadKey(true).Key != ConsoleKey.Escape) ;

                Environment.Exit(-1);
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

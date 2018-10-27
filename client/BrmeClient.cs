﻿using DiscordRPC;
using NLog;
using NLog.Config;
using NLog.Targets;
using Rollbar;
using System;
using System.Reflection;
using System.Threading;

namespace LoESoft.Client
{
    public static class BrmeClient
    {
        // Assembly's Data
        public static string _name => Assembly.GetExecutingAssembly().GetName().Name;

        public static string _version =>
            $"{Assembly.GetExecutingAssembly().GetName().Version}".Substring(0,
            $"{Assembly.GetExecutingAssembly().GetName().Version}".Length - 2);

        // Log
        private static Logger _log => LogManager.GetLogger(_name);

        // Unique IDs
        private static string _rollbarId => "ca02c5d9fb834c33880af31a6407fa18";

        private static string _brmeRpcId => "483698369559003156";

        // Discord
        public static DiscordClient _discordClient { get; set; }

        public static RichPresence _discordPresence { get; set; }

        [STAThread]
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

            _discordClient = new DiscordClient(_brmeRpcId);
            _discordPresence = new RichPresence()
            {
                Timestamps = new Timestamps() { Start = DateTime.UtcNow },
                Assets = new DiscordRPC.Assets()
                {
                    LargeImageKey = "brme",
                    LargeImageText = "Baron Ramerok",
                    SmallImageKey = "loesoft",
                    SmallImageText = "LoESoft Games"
                }
            };

            try
            {
                _discordClient.SetPresence(_discordPresence);

                using (var game = new GameApplication())
                    game.Run();
            }
            catch (Exception e)
            {
                Info("An error occurred!");

                Error(e);

                Thread.Sleep(100);

                _discordClient.ClearPresence();
                _discordClient.Dispose();

                Warn("Press 'ESC' to close...");

                while (Console.ReadKey(true).Key != ConsoleKey.Escape) ;

                Environment.Exit(0);
            }
        }

        public static void UpdateRPC() => _discordClient.SetPresence(_discordPresence);

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
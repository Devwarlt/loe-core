using LoESoft.Client.Core.networking.gamenetwork;
using NLog;
using NLog.Config;
using NLog.Targets;
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
        public static Logger _log { get; } = LogManager.GetLogger(_name);

        // Network
        public static NetworkManager _networkHandler { get; private set; }

        [STAThread]
        static void Main()
        {
            Console.Title = $"{_name} Console - Build: {_version}";

            var time = DateTime.Now.ToString().Split(' ')[1];
            var config = new LoggingConfiguration();
            var developerLog = new ColoredConsoleTarget()
            {
                Name = "developer",
                Layout = "[${var:time}] ${level} ${message} ${exception}"
            };
            var developerFile = new FileTarget()
            {
                Name = "developer-file",
                FileName = "../../../../../logs/client/Build ${assembly-version}/${level}/${var:encoded-path}.txt",
                Layout = "[${var:time}] ${level} ${message} ${exception}"
            };
            config.AddTarget(developerLog);
            config.AddTarget(developerFile);
            config.AddRule(LogLevel.Info, LogLevel.Fatal, developerFile);
            config.AddRuleForAllLevels(developerLog);
            config.Variables["time"] = time;
            config.Variables["encoded-path"] = DateTime.Now.ToString("G").Replace("/", "-").Replace(":", ".");

            LogManager.Configuration = config;

            _log.Info("Game Client is loading...");

            try
            {
                _log.Info("Network Manager is loading...");

                _networkHandler = new NetworkManager();
                _networkHandler.Start();

                _log.Info("Network Manager is loading... OK!");

                using (var game = new GameApplication())
                    game.Run();

                _log.Info("Game Client is loading... OK!");
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

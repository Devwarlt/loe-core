using LoESoft.Server.networking;
using LoESoft.Server.settings;
using LoESoft.Server.utils;
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

        public static Logger _log = LogManager.GetCurrentClassLogger();

        // Settings
        public static Settings _settings => IO.Import<Settings>("../../", "Settings");

        // Networking
        private static NetworkManager _networkManager { get; set; }

        public static void Main(string[] args)
        {
            try
            {
                Console.Title = $"{_name} - Build: {_version}";

                _log.Info("Game Server is loading...");

                _networkManager = new NetworkManager(_settings._tcpServer);
                _networkManager.Start();

                _log.Info("Game Server is loading... OK!");

                while (Console.ReadKey(true).Key != ConsoleKey.Escape) ;

                _networkManager.Stop();

                _log.Info("Game Server has been stopped.");

                Thread.Sleep(2 * 1000);

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

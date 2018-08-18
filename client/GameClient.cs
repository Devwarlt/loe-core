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

        public static Logger _log = LogManager.GetLogger("NLog");

        [STAThread]
        static void Main()
        {
            Console.Title = $"{_name} Console - Build: {_version}";

            LogManager.Configuration = new XmlLoggingConfiguration("NLog.config");
            _log.Info("Game Client is loading...");

            try
            {
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

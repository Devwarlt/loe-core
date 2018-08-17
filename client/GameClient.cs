using LoESoft.Log;
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

        // Log's Type
        public static Info _info => new Info(_name);
        public static Warn _warn => new Warn(_name);
        public static Error _error => new Error(_name);

        [STAThread]
        static void Main()
        {
            try
            {
                Console.Title = $"{_name} Console - Build: {_version}";

                using (var game = new GameApplication())
                    game.Run();
            }
            catch (Exception e)
            {
                _info.Write("An error occurred!");

                _error.Write(e.ToString());

                Thread.Sleep(100);

                _warn.Write("Press 'ESC' to close...");

                while (Console.ReadKey(true).Key != ConsoleKey.Escape) ;

                Environment.Exit(0);
            }
        }
    }
}

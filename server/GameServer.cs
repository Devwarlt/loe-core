using System;
using System.Reflection;

namespace LoESoft.Server
{
    public class GameServer
    {
        public static string _name => Assembly.GetExecutingAssembly().GetName().FullName;
        public static string _version => $"{Assembly.GetExecutingAssembly().GetName().Version}";

        public static void Main(string[] args)
        {
            Console.Title = $"{_name} - v{_version}";

            while (Console.ReadKey(true).Key != ConsoleKey.Escape) ;

            Environment.Exit(0);
        }
    }
}

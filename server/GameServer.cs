using LoESoft.Log;
using System;
using System.Reflection;

namespace LoESoft.Server
{
    public class GameServer
    {
        // Assembly's Data
        public static string _name => Assembly.GetExecutingAssembly().GetName().Name;
        public static string _version => $"{Assembly.GetExecutingAssembly().GetName().Version}";
        
        // Log's Type
        public static Info _info => new Info(_name);
        public static Warn _warn => new Warn(_name);
        public static Error _error => new Error(_name);

        public static void Main(string[] args)
        {
            Console.Title = $"{_name} - Build: {_version}";

            while (Console.ReadKey(true).Key != ConsoleKey.Escape) ;

            Environment.Exit(0);
        }
    }
}

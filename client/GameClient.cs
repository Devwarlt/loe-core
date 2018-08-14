using System;
using System.Reflection;

namespace LoESoft.Client
{
    public static class GameClient
    {
        public static string _name => Assembly.GetExecutingAssembly().GetName().FullName;
        public static string _version => $"{Assembly.GetExecutingAssembly().GetName().Version}";

        [STAThread]
        static void Main()
        {
            using (var game = new GameApplication())
                game.Run();
        }
    }
}

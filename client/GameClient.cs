using System;

namespace LoESoft.Client
{
    public static class GameClient
    {
        [STAThread]
        static void Main()
        {
            using (var game = new GameApplication())
                game.Run();
        }
    }
}

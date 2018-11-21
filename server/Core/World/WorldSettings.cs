namespace LoESoft.Server.Core.World
{
    public class WorldSettings
    {
        public static readonly int MAX_CONNECTIONS = 120;
        public static readonly int TPS = 10;
        public static readonly int UPDATE_MS = 1000 / TPS;
    }
}
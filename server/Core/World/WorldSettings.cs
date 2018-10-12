namespace LoESoft.Server.Core.World
{
    public class WorldSettings
    {
        public static readonly int MAX_CONNECTIONS = 120;
        public static readonly int TPS = 15;
        public static readonly int COOLDOWN = 1000 / TPS;
    }
}

namespace LoESoft.Server.Core.World
{
    public class WorldSettings
    {
        public static readonly int MAX_CONNECTIONS = 120;
        public static readonly int TPS = 10; // 5 ticks a second should be just fine
        public static readonly int COOLDOWN = 1000 / TPS;
    }
}
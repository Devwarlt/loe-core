namespace LoESoft.Client.Core.Game
{
    public class TileData
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Type { get; set; }
    }
    public class EntityData
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Type { get; set; }
    }
    public class PlayerData : EntityData
    {
    }
}

using LoESoft.Server.Core.World.Entities.Player;
using Newtonsoft.Json;

namespace LoESoft.Server.Core.World
{
    public class TileData
    {
        public int Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
    public class EntityData
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Type { get; set; }
    }
    public class PlayerData : EntityData
    {
        [JsonIgnore]
        public Player BasePlayer { get; set; }
    }
}

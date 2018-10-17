using LoESoft.Server.Core.World.Entities.Player;
using Newtonsoft.Json;

namespace LoESoft.Server.Core.World.Map.Data
{
    public class MapData
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Type { get; set; }
    }
    public class EntityData : MapData
    {
    }
    public class PlayerData : MapData
    {
        [JsonIgnore]
        public Player BasePlayer { get; set; }
    }
    public class TileData : MapData
    {
    }
}

using LoESoft.Server.Core.World.Entities.Player;
using Newtonsoft.Json;

namespace LoESoft.Server.Core.World.Map.Data
{
    public class MapData
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Id { get; set; }
    }
    public class EntityData : MapData
    {
        public int UniqueId { get; set; }
    }
    public class PlayerData : EntityData
    {
        [JsonIgnore]
        public Player BasePlayer { get; set; }
    }
    public class TileData : MapData { }
}
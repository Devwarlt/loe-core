using LoESoft.Server.Core.World.Entities.Player;
using Newtonsoft.Json;

namespace LoESoft.Server.Core.World.Map.Data
{
    public class PlayerData : MapData
    {
        [JsonIgnore]
        public Player BasePlayer { get; set; }
    }
}
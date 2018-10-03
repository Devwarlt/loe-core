using LoESoft.Server.Core.World.Entities.Player;
using Newtonsoft.Json;

namespace LoESoft.Server.Core.World
{
    public class PlayerData : EntityData
    {
        [JsonIgnore]
        public Player BasePlayer { get; set; }
    }
}

using LoESoft.Server.Core.World.Entities.Player;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LoESoft.Server.Core.World.Map.Data
{
    public class RawPlayerData
    {
        public string[] Player;

        public RawPlayerData() => Player = new string[] { };

        public void AssignData(List<Player> data)
            => Player = data.ConvertAll(_ => _.GetPlayerData).ConvertAll(_ => JsonConvert.SerializeObject(_)).ToArray();
    }
}
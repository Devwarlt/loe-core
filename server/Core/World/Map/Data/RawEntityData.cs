using LoESoft.Server.Core.World.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LoESoft.Server.Core.World.Map.Data
{
    public class RawEntityData
    {
        public string[] Entity;

        public RawEntityData() => Entity = new string[] { };

        public void AssignData(List<Entity> data)
            => Entity = data.ConvertAll(_ => _.GetData()).ConvertAll(_ => JsonConvert.SerializeObject(_)).ToArray();
    }
}
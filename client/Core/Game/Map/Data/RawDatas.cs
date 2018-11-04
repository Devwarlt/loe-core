using Newtonsoft.Json;
using System.Collections.Generic;

namespace LoESoft.Client.Core.Game.Map.Data
{
    public class RawData
    {
        public string[] Data { get; set; }

        public RawData() => Data = new string[] { };

        public List<T> GetData<T>()
        {
            var data = new List<T>();

            foreach (var i in Data)
                data.Add(JsonConvert.DeserializeObject<T>(i));

            return data;
        }
    }

    public class RawMapData : RawData
    {
        public RawMapData()
        {
        }
    }

    public class RawEntityData : RawData
    {
        public RawEntityData()
        {
        }
    }

    public class RawPlayerData : RawData
    {
        public RawPlayerData()
        {
        }
    }
}
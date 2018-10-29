using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace LoESoft.Server.Core.World.Map.Data
{
    public class RawData
    {
        public string[] Data { get; set; }

        public RawData()
        {
            Data = new string[] { };
        }

        public virtual void SetData<T>(T data)
        {
            List<string> dataList = Data.ToList();

            dataList.Add(JsonConvert.SerializeObject(data));

            Data = dataList.ToArray();
        }
    }
    public class RawMapData : RawData
    {
        public RawMapData() : base() { }
    }

    public class RawEntityData : RawData
    {
        public RawEntityData() : base() { }
    }

    public class RawPlayerData : RawData
    {
        public RawPlayerData() : base() { }
    }
}

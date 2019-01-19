using LoESoft.Client.Core.Networking;
using Newtonsoft.Json;

namespace LoESoft.Client.Core.Game.Objects.Stats
{
    public struct Stat
    {
        public int StatType { get; set; }
        public object Data { get; set; }

        public void Read(NetworkReader reader)
        {
            StatType = reader.ReadInt32();
            Data = JsonConvert.DeserializeObject(reader.ReadUTF());
        }
    }
}

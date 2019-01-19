
using Newtonsoft.Json;

namespace LoESoft.Server.Core.Networking.Data
{
    public struct Stat
    {
        public int StatType { get; set; }
        public object Data { get; set; }

        public void Write(NetworkWriter writer)
        {
            writer.Write(StatType);
            writer.WriteUTF(JsonConvert.SerializeObject(Data));
        }
    }
}

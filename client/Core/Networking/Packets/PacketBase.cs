using Newtonsoft.Json;
using System.Text;

namespace LoESoft.Client.Core.Networking.Packets
{
    public enum PacketID : int
    {
        PING = 0,
        PONG = 1
    }

    public abstract class PacketBase
    {
        [JsonIgnore]
        public abstract PacketID PacketID { get; }

        public override string ToString()
        {
            var ret = new StringBuilder("{\n");
            var arr = GetType().GetProperties();
            for (var i = 0; i < arr.Length; i++)
            {
                if (i != 0) ret.Append(",\n");
                ret.AppendFormat("\t{0}: {1}", arr[i].Name, arr[i].GetValue(this, null));
            }
            ret.Append("\n}");
            return ret.ToString();
        }
    }
}

using Newtonsoft.Json;
using System.Text;

namespace LoESoft.Client.Core.Networking.Packets
{
    public abstract class PacketBase
    {
        [JsonIgnore]
        public abstract PacketID PacketID { get; }

        public override string ToString()
        {
            var ret = new StringBuilder("{\n");

            for (var i = 0; i < GetType().GetProperties().Length; i++)
            {
                if (i != 0)
                    ret.Append(",\n");

                ret.AppendFormat("\t{0}: {1}", GetType().GetProperties()[i].Name, GetType().GetProperties()[i].GetValue(this, null));
            }

            ret.Append("\n}");

            return ret.ToString();
        }
    }
}
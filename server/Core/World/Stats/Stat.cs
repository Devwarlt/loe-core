using Newtonsoft.Json;

namespace LoESoft.Server.Core.World.Stats
{
    public class Stat
    {
        public int StatType { get; set; }

        public object Value
        {
            get => _val;
            set
            {
                _val = value;
                ShouldUpdate = true;
            }
        }

        [JsonIgnore]
        private object _val;
        [JsonIgnore]
        public bool ShouldUpdate { get; set; }

        public Stat(int type, object val)
        {
            StatType = type;
            Value = val;
        }

        public string Serialize()
        {
            ShouldUpdate = false;
            return JsonConvert.SerializeObject(this);
        }
    }
}

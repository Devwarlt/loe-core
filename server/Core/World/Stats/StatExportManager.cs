using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Linq;

namespace LoESoft.Server.Core.World.Stats
{
    public class StatExportManager
    {
        public ConcurrentDictionary<int, Stat> StatsToExport { get; private set; }

        public StatExportManager() => StatsToExport = new ConcurrentDictionary<int, Stat>();

        public void AddOrUpdate<T>(int type, T value)
        {
            StatsToExport.AddOrUpdate(type, new Stat(type, value), (k, v) =>
            {
                if (!v.Value.Equals(value))
                    v.Value = value;

                return v;
            });
        }

        public string Serialize() => JsonConvert.SerializeObject(StatsToExport.Where(_ => _.Value.ShouldUpdate == true).Select(_ => _.Value.Serialize()).ToList());
    }
}
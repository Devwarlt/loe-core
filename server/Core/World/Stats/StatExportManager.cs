﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace LoESoft.Server.Core.World.Stats
{
    public class StatExportManager
    {
        public Dictionary<int, object> StatsToExport { get; private set; }
        public Dictionary<int, object> ExportedStats { get; private set; }

        public StatExportManager()
        {
            StatsToExport = new Dictionary<int, object>();
            ExportedStats = new Dictionary<int, object>();
        }

        public void AddOrUpdate<T>(int type, T value)
        {
            if (!ExportedStats.ContainsKey(type) || !ExportedStats[type].Equals(value))
                StatsToExport.Add(type, value);
        }

        public string Serialize()
        {
            string val = JsonConvert.SerializeObject(StatsToExport.Select(_ =>
            {
                if (!ExportedStats.ContainsKey(_.Key))
                    ExportedStats.Add(_.Key, _.Value);
                else
                    ExportedStats[_.Key] = _.Value;

                return _;
            }));

            StatsToExport.Clear();

            return val;
        }
    }
}
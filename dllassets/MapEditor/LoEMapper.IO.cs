using LoESoft.Dlls.GZip;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace LoESoft.Dlls.MapEditor
{
    public partial class LoEMapper<Map>
    {
        public void SaveMap(Map map, string name)
        {
            var path = Path.Combine(MainDir, $"/{BaseDir}/{name}.{_format}");

            if (map == null)
                Logger($"(SaveException) Missing data from path: {path}");
            else
            {
                var content = JsonConvert.SerializeObject(map);

                if (EnableCompression)
                    File.WriteAllBytes(path, GZipCompression.Zip(content));
                else
                    File.WriteAllText(path, content);

                Logger($"Saved map data to '{MainDir}\\{BaseDir}\\{name}.{_format}'.");
            }
        }

        public Map LoadMap(string name)
        {
            var path1 = Path.Combine(MainDir, $"/{BaseDir}/{name}.{FileFormatCompressed}");
            var path2 = Path.Combine(MainDir, $"/{BaseDir}/{name}.{FileFormatNonCompressed}");

            if (!File.Exists(path1) && !File.Exists(path2))
            {
                Logger($"(LoadException) Missing data from path: {Path.Combine(MainDir, $"/{BaseDir}/{name}.*")}");

                return default(Map);
            }

            Map content = default(Map);

            if (File.Exists(path1))
                content = JsonConvert.DeserializeObject<Map>(Encoding.UTF8.GetString(GZipCompression.UnZip(File.ReadAllBytes(path1))));
            else
                content = JsonConvert.DeserializeObject<Map>(File.ReadAllText(path2));

            Logger($"Loaded data from '{MainDir}\\{BaseDir}\\{name}.{_format}'.");

            return content;
        }
    }
}
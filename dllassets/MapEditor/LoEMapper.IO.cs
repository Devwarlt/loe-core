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
            var path = Path.Combine(MainDir, $"{name}.{_format}");

            if (map == null)
                Logger($"(SaveException) Missing data from path: {path}");
            else
            {
                var content = JsonConvert.SerializeObject(map);

                if (EnableCompression)
                    File.WriteAllBytes(path, GZipCompression.Zip(content));
                else
                    File.WriteAllText(path, content);

                Logger($"Saved map data to '/{MainDir}/{name}.{_format}'.");
            }
        }

        public Map LoadMap(string name)
        {
            var path = Path.Combine(MainDir, $"{name}.{_fileFormatCompressed}");

            if (!File.Exists(path))
            {
                Logger($"(LoadException) Missing data from path: {path}");

                return default(Map);
            }

            Map content = default(Map);

            if (EnableCompression)
                content = JsonConvert.DeserializeObject<Map>(Encoding.UTF8.GetString(GZipCompression.UnZip(File.ReadAllBytes(path))));
            else
                content = JsonConvert.DeserializeObject<Map>(File.ReadAllText(path));

            Logger($"Loaded data from '/{MainDir}/{name}.{_format}'.");

            return content;
        }
    }
}

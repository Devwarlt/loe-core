using LoESoft.Dlls.GZip;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace LoESoft.Dlls.MapEditor
{
    public partial class LoEMapper<Map>
    {
        public void SaveMap(string filename, Map map)
        {
            if (map == null)
                Logger($"Content data is empty and being ignored.");
            else
            {
                try
                {
                    var filepath = Path.Combine(BaseDir, $"{filename}.{_format}");
                    var data = JsonConvert.SerializeObject(map);

                    if (EnableCompression)
                        File.WriteAllBytes(filepath, GZipCompression.Zip(data));
                    else
                        File.WriteAllText(filepath, data);
                }
                catch (Exception e) { Logger($"(SaveException) An error occurred along save method:\n{e}"); }
            }
        }

        public Map LoadMap(string name)
        {
            var filepath1 = Path.Combine(BaseDir, $"{name}.{FileFormatCompressed}");
            var filepath2 = Path.Combine(BaseDir, $"{name}.{FileFormatNonCompressed}");
            var file1exist = File.Exists(filepath1);
            var file2exist = File.Exists(filepath2);

            object data = null;

            if (!file1exist && !file2exist)
            {
                Logger($"Content data is empty and being ignored.");

                return (Map)data;
            }

            try
            {
                data = file1exist ? JsonConvert.DeserializeObject<Map>(Encoding.UTF8.GetString(GZipCompression.UnZip(File.ReadAllBytes(filepath1))))
                    : JsonConvert.DeserializeObject<Map>(File.ReadAllText(filepath2));

                Logger($"Loaded from path: '{(file1exist ? filepath1 : filepath2)}'");
            }
            catch (Exception e)
            {
                Logger($"(LoadException) An error occurred along load method:" +
                    $"\n- File: '{(file1exist ? filepath1 : filepath2)}'" +
                    $"\n- Error: {e}");
            }

            return (Map)data;
        }
    }
}
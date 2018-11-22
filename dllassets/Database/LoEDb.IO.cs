using Newtonsoft.Json;
using System.IO;

namespace LoESoft.Dlls.Database
{
    public partial class LoEDb
    {
        public void Save<T>(string path, T data)
        {
            if (data == null)
                Logger($"(SaveException) Missing data from path: {path}.json");
            else
            {
                File.WriteAllText(Path.Combine(MainDir, $"{path}.json"), JsonConvert.SerializeObject(data));
                Logger($"Saved data to '{path}.json'.");
            }
        }

        public void Save<T>(string folder, string target, T data)
        {
            if (data == null)
                Logger($"(SaveException) Missing data from path: /{MainDir}/{BaseDir}/{folder}/{target}.json");
            else
            {
                File.WriteAllText(Path.Combine(MainDir, $"/{BaseDir}/{folder}/{target}.json"), JsonConvert.SerializeObject(data));
                Logger($"Saved data to '/{MainDir}/{BaseDir}/{folder}/{target}.json'.");
            }
        }

        public T Load<T>(string path)
        {
            object data = null;

            try
            {
                data = JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
                Logger($"Loaded data from '{path}'.");
            }
            catch { Logger($"(LoadException) Missing data from path: {path}"); }

            return (T)data;
        }

        public T Load<T>(string folder, string target)
        {
            object data = null;

            try
            {
                data = JsonConvert.DeserializeObject<T>(File.ReadAllText(Path.Combine(MainDir, $"{BaseDir}/{folder}/{target}.json")));
                Logger($"Loaded data from '/{MainDir}/{BaseDir}/{folder}/{target}.json'.");
            }
            catch { Logger($"(LoadException) Missing data from path: /{MainDir}/{BaseDir}/{folder}/{target}.json"); }

            return (T)data;
        }
    }
}

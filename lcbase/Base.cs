using Newtonsoft.Json;
using System;
using System.IO;

namespace LoESoft.LCBase
{
    public class Base
    {
        public string MainDir => Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        private string _basedir;
        private Action<string> _log;

        private void Logger(string message) => _log?.Invoke(message);

        public Base(string basedir, Action<string> log)
        {
            _basedir = basedir;
            _log = log;

            Logger("------------------------");
            Logger("-- LCBase by Devwarlt --");
            Logger("------------------------");
        }

        public void CreateMainDirectory()
        {
            var basedir = Path.Combine(MainDir, _basedir);

            if (!Directory.Exists(basedir))
            {
                Directory.CreateDirectory(basedir);
                Logger($"Directory '{basedir}' has been created!");
            }
        }

        public void CreateSubDirectory(string subfolder)
        {
            var subdir = Path.Combine(MainDir, $"/{_basedir}/{subfolder}/");

            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
                Logger($"Directory '{subdir}' has been created!");
            }
        }

        public void Save<T>(string folder, string target, T data)
        {
            if (data == null)
                Logger($"(SaveException) Missing data from path: {_basedir}/{folder}/{target}.json");
            else
            {
                File.WriteAllText(Path.Combine(MainDir, $"/{_basedir}/{folder}/{target}.json"), JsonConvert.SerializeObject(data));
                Logger($"Saved data to '{_basedir}/{folder}/{target}.json'.");
            }
        }

        public T Load<T>(string folder, string target)
        {
            object data = null;

            try
            {
                data = JsonConvert.DeserializeObject<T>(File.ReadAllText(Path.Combine(MainDir, $"{_basedir}/{folder}/{target}.json")));
                Logger($"Loaded data from '{_basedir}/{folder}/{target}.json'.");
            }
            catch { Logger($"(LoadException) Missing data from path: {_basedir}/{folder}/{target}.json"); }

            return (T)data;
        }
    }
}
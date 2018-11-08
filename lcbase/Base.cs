using Newtonsoft.Json;
using System;
using System.IO;

namespace LoESoft.LCBase
{
    public class Base
    {
        public string MainDir { get; }
        public string BaseDir { get; }

        private readonly Action<string> _log;

        private void Logger(string message) => _log?.Invoke(message);

        public Base(string basedir, Action<string> log)
        {
            MainDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            BaseDir = basedir;

            _log = log;

            Logger("------------------------");
            Logger("-- LCBase by Devwarlt --");
            Logger("------------------------");
        }

        public void CreateMainDirectory()
        {
            var basedir = Path.Combine(MainDir, BaseDir);

            if (!Directory.Exists(basedir))
            {
                Directory.CreateDirectory(basedir);
                Logger($"Directory '{basedir}' has been created!");
            }
        }

        public void CreateSubDirectory(string subfolder)
        {
            var subdir = Path.Combine(MainDir, $"/{BaseDir}/{subfolder}/");

            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
                Logger($"Directory '{subdir}' has been created!");
            }
        }

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
                Logger($"(SaveException) Missing data from path: {BaseDir}/{folder}/{target}.json");
            else
            {
                File.WriteAllText(Path.Combine(MainDir, $"/{BaseDir}/{folder}/{target}.json"), JsonConvert.SerializeObject(data));
                Logger($"Saved data to '{BaseDir}/{folder}/{target}.json'.");
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
                Logger($"Loaded data from '{BaseDir}/{folder}/{target}.json'.");
            }
            catch { Logger($"(LoadException) Missing data from path: {BaseDir}/{folder}/{target}.json"); }

            return (T)data;
        }
    }
}
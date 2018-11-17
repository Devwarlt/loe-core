using LoESoft.MapEditor.Core.Layer;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;

namespace LoESoft.MapEditor.Core.Util
{
    public static class Utils
    {
        private static string MainDir => Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private static string BaseDir => "BRMEMaps";

        public static string GetMapFolderPath => Path.Combine(MainDir, $"/{BaseDir}/");

        public static string GetPath(string fileName) => Path.Combine(GetMapFolderPath, fileName);

        public static Texture2D LoadEmbeddedTexture(string file)
        {
            var assembly = Assembly.GetExecutingAssembly();
            Texture2D texture2d = null;

            foreach (var name in assembly.GetManifestResourceNames())
                if (name.Contains(file))
                {
                    using (var stream = assembly.GetManifestResourceStream(name))
                        if (stream != null)
                            texture2d = Texture2D.FromStream(MapEditor.GraphicsDeviceManager.GraphicsDevice, stream);
                    break;
                }

            return texture2d;
        }

        public static void SaveMap(Map map, string name)
        {
            if (!Directory.Exists(GetMapFolderPath))
                Directory.CreateDirectory(GetMapFolderPath);

            App.Info($"Saving '{name}' map...");

            File.WriteAllText(GetPath($"{name}.brmemap"), JsonConvert.SerializeObject(map, Formatting.Indented));

            App.Info($"Saving '{name}' map... OK!");
        }

        public static Map LoadMap(string name)
        {
            if (!Directory.Exists(GetMapFolderPath))
                Directory.CreateDirectory(GetMapFolderPath);

            if (!File.Exists(GetPath($"{name}.brmemap")))
                return null;

            return JsonConvert.DeserializeObject<Map>(File.ReadAllText(GetPath($"{name}.brmemap")));
        }

        public static string ObjectToString<T>(T obj) => JsonConvert.SerializeObject(obj);

        public static T StringToObject<T>(string data) => JsonConvert.DeserializeObject<T>(data);
    }
}
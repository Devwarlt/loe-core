using LoESoft.MapEditor.Core.Layer;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace LoESoft.MapEditor.Core.Util
{
    public static class Utils
    {
        public static int TILE_SIZE = 16;

        public static string GetMapFolderPath => Path.Combine(MainDir, $"/{BaseDir}/");

        public static string GetPath(string fileName) => Path.Combine(GetMapFolderPath, fileName);

        private static string MainDir => Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private static string BaseDir => "BRMEMaps";

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

        public static KeyValuePair<string, Image> LoadEmbeddedSpritesheet(string file)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var spritedata = new KeyValuePair<string, Image>();

            foreach (var name in assembly.GetManifestResourceNames())
                if (name.Contains(file))
                {
                    using (var stream = assembly.GetManifestResourceStream(name))
                        if (stream != null)
                            spritedata = new KeyValuePair<string, Image>(file, Image.FromStream(stream));
                    break;
                }

            return spritedata;
        }

        public static SpriteItem[,] CropSpritesheet(Image image)
        {
            try
            {
                var width = image.Width / TILE_SIZE;
                var height = image.Height / TILE_SIZE;
                var spriteitems = new SpriteItem[width, height];
                var actualindex = 0;

                for (var x = 0; x < width; x++)
                    for (var y = 0; y < height; y++)
                    {
                        spriteitems[x, y] = new SpriteItem
                        {
                            MaximumX = width,
                            MaximumY = height,
                            Index = new int[x, y],
                            ActualIndex = actualindex,
                            Image = new Bitmap(TILE_SIZE, TILE_SIZE)
                        };

                        var graphics = Graphics.FromImage(spriteitems[x, y].Image);
                        graphics.DrawImage(image, new Rectangle(0, 0, TILE_SIZE, TILE_SIZE), new Rectangle(x * TILE_SIZE, y * TILE_SIZE, TILE_SIZE, TILE_SIZE), GraphicsUnit.Pixel);
                        graphics.Dispose();

                        actualindex++;
                    }

                return spriteitems;
            }
            catch (Exception e) { App.Error(e); }

            return null;
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
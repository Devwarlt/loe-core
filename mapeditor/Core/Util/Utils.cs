using LoESoft.MapEditor.Core.Layer;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;

namespace LoESoft.MapEditor.Core.Util
{
    public static class Utils
    {
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

        public static string Save(this Map map)
            => JsonConvert.SerializeObject(new MapData()
            {
                Size = map.Size,
                UndergroundData = map.Layers[(int)MapLayer.UNDERGROUND].Chunks.Save(),
                GroundData = map.Layers[(int)MapLayer.GROUND].Chunks.Save(),
                ObjectData = map.Layers[(int)MapLayer.OBJECT].Chunks.Save(),
                SkyData = map.Layers[(int)MapLayer.SKY].Chunks.Save()
            });

        public static string Save(this List<List<ChunkData>> chunk)
        {
            try
            { return JsonConvert.SerializeObject(chunk); }
            catch { }

            return null;
        }

        public static void Load(this List<List<ChunkData>> chunk, string data)
        {
            try
            { chunk = JsonConvert.DeserializeObject<List<List<ChunkData>>>(data); }
            catch { }
        }

        public static MapData GetMapData(string data)
            => JsonConvert.DeserializeObject<MapData>(data);
    }
}
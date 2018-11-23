using LoESoft.Dlls.GZip;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LoESoft.Server.Core.World.Map.Structure
{
    public class Map
    {
        public static Dictionary<string, KeyValuePair<bool, byte[]>> BinaryMapsCache { get; set; }

        public MapSize Size { get; set; }
        public List<Layer> Layers { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public Map(MapSize size)
        {
            Size = size;
            Width = (int)Size;
            Height = (int)Size;
            Layers = new List<Layer>(5);

            for (var i = 0; i < 5; i++)
                Layers.Add(new Layer((MapLayer)i, Size));
        }

        public ChunkObject[,] GetChunksByLayer(MapLayer layer) => Layers[(int)layer].Chunks;

        public static Map GetMapByName(string name)
        {
            if (BinaryMapsCache.TryGetValue(name, out KeyValuePair<bool, byte[]> binaryData))
            {
                var map = GetMapFromBytes(binaryData.Key, binaryData.Value);

                foreach (var layer in map.Layers)
                    layer.UpdateChunksToObject();

                return map;
            }

            throw new Exception($"Map {name} not found!");
        }

        public static void LoadEmbeddedMaps() => BinaryMapsCache = App.LoEUtils.GetEmbeddedMaps<int>(Assembly.GetExecutingAssembly());

        private static Map GetMapFromBytes(bool compressed, byte[] data)
            => compressed ? JsonConvert.DeserializeObject<Map>(Encoding.UTF8.GetString(GZipCompression.UnZip(data))) :
            JsonConvert.DeserializeObject<Map>(Encoding.UTF8.GetString(data));
    }
}
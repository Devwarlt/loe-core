using System.Collections.Generic;

namespace LoESoft.Server.Core.World.Map.Structure
{
    public class Map
    {
        public static List<KeyValuePair<bool, byte[]>> BinaryMapsCache { get; set; }

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

        public static void LoadEmbeddedMaps() => BinaryMapsCache = App.LoEUtils.GetEmbeddedMaps<int>(".Embeds.Maps.");
    }
}
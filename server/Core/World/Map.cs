using LoESoft.Server.Core.World.Map;
using Newtonsoft.Json;
using System;

namespace LoESoft.Server.Core.World
{
    public class TileData
    {
        public int Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
    public class MapData
    {
        class Data // temporrary class 
        {
            public string[,] Tiles { get; set; }

            public Data()
            {
                Tiles = new string[Chunk.CHUNKSIZE, Chunk.CHUNKSIZE];
            }

            public void AssignData(TileData[,] data)
            {
                for (var x = 0; x < Chunk.CHUNKSIZE; x++)
                    for (var y = 0; y < Chunk.CHUNKSIZE; y++)
                        Tiles[x, y] = JsonConvert.SerializeObject(data[x, y]);
            }
        }

        public Chunk[,] ChunkMap;


        public MapData()
        {
            ChunkMap = new Chunk[16, 16];

            for (var x = 0; x < Chunk.CHUNKSIZE; x++)
                for (var y = 0; y < Chunk.CHUNKSIZE; y++)
                    ChunkMap[x, y] = new Chunk(x, y);

            foreach (var i in ChunkMap)
                i.LoadChunk();
        }

        public string GetData(int px, int py)
        {
            Data dat = new Data();

            var cx = px / Chunk.CHUNKSIZE;
            var cy = py / Chunk.CHUNKSIZE;

            var chunk = ChunkMap[cx, cy];

            dat.AssignData(chunk.Tiles);

            return JsonConvert.SerializeObject(dat);
        }
    }
}
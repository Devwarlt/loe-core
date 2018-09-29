using LoESoft.Server.Core.World.Map;
using Newtonsoft.Json;
using System;

namespace LoESoft.Server.Core.World
{
    public class MapData
    {
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
            TempData dat = new TempData();

            var cx = px / Chunk.CHUNKSIZE;
            var cy = py / Chunk.CHUNKSIZE;

            var chunk = ChunkMap[cx, cy];

            dat.AssignData(chunk.Tiles);

            return JsonConvert.SerializeObject(dat);
        }
    }
}
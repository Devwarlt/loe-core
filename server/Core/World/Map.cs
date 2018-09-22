using Newtonsoft.Json;

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
        class Data
        {
            public string[,] Tiles { get; set; }

            public Data()
            {
                Tiles = new string[11, 6]; //temporary
            }
        }

        public TileData[,] Tiles { get; set; }

        public MapData()
        {
            Tiles = new TileData[160, 90];

            for (var x = 0; x < 160; x++) //Temp
                for (var y = 0; y < 90; y++)
                    Tiles[x, y] = new TileData() { X = x, Y = y, Type = x % 5 };
        }

        public string GetData(int px, int py)
        {
            Data dat = new Data();

            //var data = GetChunkData(px, py);
            for (var x = 0; x < 11; x++)
                for (var y = 0; y < 6; y++)
                    dat.Tiles[x, y] = JsonConvert.SerializeObject(Tiles[px, py]);

            GameServer.Info(JsonConvert.SerializeObject(dat));

            return JsonConvert.SerializeObject(dat);
        }
    }
}

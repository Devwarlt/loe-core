using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoESoft.Client.Core.Game
{
    public class TileData
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Type { get; set; }
    }
    public class Map
    {
        class Data
        {
            public string[,] Tiles { get; set; }

            public Data()
            {
                Tiles = new string[16, 16]; //temporary
            }
        }

        public Tile[,] Tiles { get; set; }

        public Map()
        {
            Tiles = new Tile[16, 16];
        }

        protected bool initialUpdate = false;

        public void UpdateTiles(string data)
        {
            Data dat = JsonConvert.DeserializeObject<Data>(data);

            for (var x = 0; x < 16; x++)
                for (var y = 0; y < 16; y++)
                {
                    var tiledat = JsonConvert.DeserializeObject<TileData>(dat.Tiles[x, y]);

                    Tiles[x, y] = new Tile(tiledat.X, tiledat.Y, tiledat.Type);
                }
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            var tile = Tiles;
            foreach(var i in tile)
            {
                if (i != null)
                    i.Draw(spriteBatch);
            }
        }
    }
}

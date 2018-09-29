using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;

namespace LoESoft.Client.Core.Game
{
    public class Map
    {
        public Tile[,] Tiles { get; set; }

        public Map()
        {
            Tiles = new Tile[16, 16];
        }

        protected bool initialUpdate = false;

        public void UpdateTiles(string data)
        {
            TempData dat = JsonConvert.DeserializeObject<TempData>(data);

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
            foreach (var i in tile)
            {
                if (i != null)
                    i.Draw(spriteBatch);
            }
        }
    }
}
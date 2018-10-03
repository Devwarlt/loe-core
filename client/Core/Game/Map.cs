using LoESoft.Client.Core.Game.Objects;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LoESoft.Client.Core.Game
{
    public class Map
    {
        public Tile[,] Tiles { get; set; }
        public List<BasicObject> Entities { get; set; }
        public List<BasicObject> Players { get; set; }

        public Map()
        {
            Tiles = new Tile[16, 16];
            Entities = new List<BasicObject>();
            Players = new List<BasicObject>();
        }

        protected bool initialUpdate = false;

        public void Update(string data)
        {
            RawMapData dat = JsonConvert.DeserializeObject<RawMapData>(data);

            for (var x = 0; x < 16; x++)
                for (var y = 0; y < 16; y++)
                {
                    var tiledat = JsonConvert.DeserializeObject<TileData>(dat.Tiles[x, y]);

                    Tiles[x, y] = new Tile(tiledat.X, tiledat.Y, tiledat.Type);
                }
            
            foreach(var i in dat.Entitys)
            {
                var entitydat = JsonConvert.DeserializeObject<EntityData>(i);
                Entities.Add(new BasicObject() { X = entitydat.X, Y = entitydat.Y });
            }

            foreach(var i in dat.Players)
            {
                var playerdat = JsonConvert.DeserializeObject<PlayerData>(i);
                var player = new BasicObject() { X = playerdat.X, Y = playerdat.Y }; 
                if (!Players.Contains(player))
                    Players.Add(player);
                GameClient.Warn("Player Added!");
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
            foreach (var i in Entities.ToArray())
                i.Draw(spriteBatch);

            foreach (var i in Players.ToArray())
                i.Draw(spriteBatch);
        }
    }
}
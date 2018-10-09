using LoESoft.Client.Core.Game.Objects;
using Microsoft.Xna.Framework;
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

        public void Update(string mapdata, string entitydata, string playerdata)
        {
            RawMapData mdat = JsonConvert.DeserializeObject<RawMapData>(mapdata);
            RawEntityData edat = JsonConvert.DeserializeObject<RawEntityData>(entitydata);
            RawPlayerData pdat = JsonConvert.DeserializeObject<RawPlayerData>(playerdata);

            for (var x = 0; x < 16; x++)
                for (var y = 0; y < 16; y++)
                {
                    var tiledat = JsonConvert.DeserializeObject<TileData>(mdat.Tiles[x, y]);

                    Tiles[x, y] = new Tile(tiledat.X, tiledat.Y, tiledat.Type);
                }
            
            List<BasicObject> entities = new List<BasicObject>();
            List<BasicObject> players = new List<BasicObject>();
            foreach (var i in edat.Entity)
            {
                var entitydat = JsonConvert.DeserializeObject<EntityData>(i);
                entities.Add(new BasicObject(Color.Red) { X = entitydat.X, Y = entitydat.Y });
            }
            foreach (var i in pdat.Player)
            {
                var playerdat = JsonConvert.DeserializeObject<PlayerData>(i);
                players.Add(new BasicObject(Color.Green) { X = playerdat.X, Y = playerdat.Y });
            }

            if (Entities != entities)
                Entities = entities;
            if (Players != players)
                Players = players;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var i in Tiles)
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
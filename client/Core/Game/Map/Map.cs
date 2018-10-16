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

        protected bool initialUpdate = false;

        public Map()
        {
            Tiles = new Tile[16, 16];
            Entities = new List<BasicObject>();
            Players = new List<BasicObject>();
        }

        public void Update(string mapdata, string entitydata, string playerdata)
        {
            for (var x = 0; x < 16; x++)
                for (var y = 0; y < 16; y++)
                    Tiles[x, y] = new Tile(
                        JsonConvert.DeserializeObject<TileData>(JsonConvert.DeserializeObject<RawMapData>(mapdata).Tiles[x, y]).X,
                        JsonConvert.DeserializeObject<TileData>(JsonConvert.DeserializeObject<RawMapData>(mapdata).Tiles[x, y]).Y,
                        JsonConvert.DeserializeObject<TileData>(JsonConvert.DeserializeObject<RawMapData>(mapdata).Tiles[x, y]).Type);

            var entities = new List<BasicObject>();
            var players = new List<BasicObject>();

            foreach (var i in JsonConvert.DeserializeObject<RawEntityData>(entitydata).Entity)
                entities.Add(new BasicObject(Color.Red)
                {
                    X = JsonConvert.DeserializeObject<EntityData>(i).X,
                    Y = JsonConvert.DeserializeObject<EntityData>(i).Y
                });

            foreach (var i in JsonConvert.DeserializeObject<RawPlayerData>(playerdata).Player)
                players.Add(new BasicObject(Color.Green)
                {
                    X = JsonConvert.DeserializeObject<PlayerData>(i).X,
                    Y = JsonConvert.DeserializeObject<PlayerData>(i).Y
                });

            if (Entities != entities)
                Entities = entities;

            if (Players != players)
                Players = players;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var i in Tiles)
                if (i != null)
                    i.Draw(spriteBatch);

            foreach (var i in Entities.ToArray())
                i.Draw(spriteBatch);

            foreach (var i in Players.ToArray())
                i.Draw(spriteBatch);
        }
    }
}
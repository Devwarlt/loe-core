using LoESoft.Client.Core.Game.Map.Data;
using LoESoft.Client.Core.Game.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LoESoft.Client.Core.Game.Map
{
    public class Map
    {
        public List<Tile> Tiles { get; set; }
        public List<BasicObject> Entities { get; set; }
        public List<BasicObject> Players { get; set; }

        protected bool initialUpdate = false;

        public Map()
        {
            Tiles = new List<Tile>();
            Entities = new List<BasicObject>();
            Players = new List<BasicObject>();
        }

        public void Update(string mapdata, string entitydata, string playerdata)
        {
            var entities = new List<BasicObject>();
            var players = new List<BasicObject>();
            var tiles = new List<Tile>();

            foreach (var i in JsonConvert.DeserializeObject<RawMapData>(mapdata).Data)
            {
                var data = JsonConvert.DeserializeObject<TileData>(i);
                tiles.Add(new Tile(data.X, data.Y, data.Id));
            }

            foreach (var i in JsonConvert.DeserializeObject<RawEntityData>(entitydata).Data)
                entities.Add(new BasicObject(Color.Red)
                {
                    X = JsonConvert.DeserializeObject<EntityData>(i).X,
                    Y = JsonConvert.DeserializeObject<EntityData>(i).Y
                });

            foreach (var i in JsonConvert.DeserializeObject<RawPlayerData>(playerdata).Data)
                players.Add(new BasicObject(Color.Green)
                {
                    X = JsonConvert.DeserializeObject<PlayerData>(i).X,
                    Y = JsonConvert.DeserializeObject<PlayerData>(i).Y
                });

            if (Tiles != tiles)
                Tiles = tiles;

            if (Entities != entities)
                Entities = entities;

            if (Players != players)
                Players = players;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var i in Tiles.ToArray())
                i.Draw(spriteBatch);

            foreach (var i in Entities.ToArray())
                i.Draw(spriteBatch);

            foreach (var i in Players.ToArray())
                i.Draw(spriteBatch);
        }
    }
}
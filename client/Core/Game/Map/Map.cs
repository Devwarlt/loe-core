using LoESoft.Client.Core.Game.Map.Data;
using LoESoft.Client.Core.Game.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace LoESoft.Client.Core.Game.Map
{
    public class Map
    {
        public List<Tile> Tiles { get; set; }
        public ConcurrentBag<Entity> Entities { get; set; }
        public List<Player> Players { get; set; }

        protected bool initialUpdate = false;

        public Map()
        {
            Tiles = new List<Tile>();
            Entities = new ConcurrentBag<Entity>();
            Players = new List<Player>();
        }

        public void Update(string mapdata, string entitydata, string playerdata)
        {
            var tile = new List<Tile>();

            foreach (var i in JsonConvert.DeserializeObject<RawMapData>(mapdata).GetData<TileData>())
                tile.Add(new Tile(i.X, i.Y, i.Id));

            Tiles = tile;
            
            foreach(var i in JsonConvert.DeserializeObject<RawEntityData>(entitydata).GetData<EntityData>())
            {
                Entities.TryTake(out var entity);

                if (entity.UniqueId == i.UniqueId)
                {
                    entity.DistinationX = i.X;
                    entity.DistinationY = i.Y;
                    Entities.Add(entity);
                } else
                {
                    Entities.Add(new Entity(i.Id) { X = i.X, Y = i.Y, UniqueId = i.UniqueId });
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var i in Entities.ToArray())
                i.Update(gameTime);

            foreach (var i in Players.ToArray())
                i.Update(gameTime);
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
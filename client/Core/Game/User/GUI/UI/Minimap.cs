using LoESoft.Client.Core.Game.Map;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Sprites;
using LoESoft.Client.Drawing.Sprites.Forms;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LoESoft.Client.Core.Game.User.GUI.UI
{
    public class MiniMap : FilledRectangle
    {
        public MiniMap(int x, int y) : base(x, y, 220, 220, new RGBColor(0, 0, 0), 1f) => IsZeroApplicaple = true;

        public void DrawMap(SpriteBatch spriteBatch, float x, float y)
        {
            foreach (var i in GetTiles(x, y))
                i.Draw(spriteBatch);

            foreach (var i in GetEntities(x, y))
                i.Draw(spriteBatch);
        }

        private HashSet<Sprite> GetTiles(float x, float y)
        {
            var hashSet = new HashSet<Sprite>();
            var points = WorldMap.GetSightPoints((int)x, (int)y);

            foreach (var i in points)
            {
                if (WorldMap.TileMap.ContainsKey(i))
                {
                    float tx = (i.X - (x - WorldMap.SightRadius)) * 10 + 5;
                    float ty = (i.Y - (y - WorldMap.SightRadius)) * 10 + 5;

                    hashSet.Add(new Sprite(tx + X, ty + Y, 10, 10, WorldMap.TileMap[i].Texture));
                }
            }

            return hashSet;
        }

        private HashSet<Sprite> GetEntities(float x, float y)
        {
            var hashSet = new HashSet<Sprite>();
            var entities = WorldMap.GetEntitiesInSight((int)x, (int)y);

            foreach (var i in entities)
            {
                float tx = (i.X - (x - WorldMap.SightRadius)) * 10 + 5;
                float ty = (i.Y - (y - WorldMap.SightRadius)) * 10 + 5;
                
                hashSet.Add(new Sprite(tx + X, ty + Y, 10, 10, i.Texture));
            }

            return hashSet;
        }
    }
}
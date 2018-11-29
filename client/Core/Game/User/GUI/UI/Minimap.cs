using LoESoft.Client.Core.Game.Map;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Sprites;
using LoESoft.Client.Drawing.Sprites.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System.Collections.Generic;

namespace LoESoft.Client.Core.Game.User.GUI.UI
{
    public class MiniMap : FilledRectangle
    {
        public MiniMap(int x, int y) : base(x, y, 300, 300, new RGBColor(0, 0, 0), 1f) => IsZeroApplicaple = true;

        public void DrawMap(SpriteBatch spriteBatch, float x, float y)
        {
            foreach (var i in GetTiles(x, y))
                i.Draw(spriteBatch);

            foreach (var i in GetEntities(x, y))
                i.Draw(spriteBatch);

            spriteBatch.FillRectangle(new RectangleF(X + (300 / 2 - 15 / 2), Y - (300 / 2 - 15 / 2), 15, 15), Color.Green);
        }

        private HashSet<Sprite> GetTiles(float x, float y)
        {
            var hashSet = new HashSet<Sprite>();
            var tiles = WorldMap.GetTilesInSight((int)x, (int)y);
            var iX = 0;
            var iY = 0;

            foreach (var i in tiles)
            {
                float tx = (i.X - (x - 10)) * 15;
                float ty = (i.Y - (y - 10)) * 15;

                hashSet.Add(new Sprite(tx + X + iX, ty + Y + iY, 15, 15, i.Texture));
            }

            return hashSet;
        }

        private HashSet<Sprite> GetEntities(float x, float y)
        {
            var hashSet = new HashSet<Sprite>();
            var entities = WorldMap.GetEntitiesInSight((int)x, (int)y);
            var iX = 0;
            var iY = 0;

            foreach (var i in entities)
            {
                float tx = (i.X - (x - 10)) * 15;
                float ty = (i.Y - (y - 10)) * 15;
                
                hashSet.Add(new Sprite(tx + X + iX, ty + Y + iY, 15, 15, i.Texture));
            }

            return hashSet;
        }
    }
}
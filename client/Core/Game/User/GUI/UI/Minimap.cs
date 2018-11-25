﻿using LoESoft.Client.Core.Game.Map;
using LoESoft.Client.Drawing.Sprites.Forms;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LoESoft.Client.Core.Game.User.GUI.UI
{
    public class MiniMap : FilledRectangle
    {
        public MiniMap(int x, int y)
            : base(x, y, 300, 300, new Drawing.RGBColor(0, 0, 0), 0.75f)
        {
            IsZeroApplicaple = true;
        }

        public void DrawMap(SpriteBatch spriteBatch, int x, int y)
        {
            foreach (var i in getTiles(x, y))
                i.Draw(spriteBatch);

            foreach (var i in getEntities(x, y))
                i.Draw(spriteBatch);
        }

        private HashSet<Sprite> getTiles(int x, int y)
        {
            var hashSet = new HashSet<Sprite>();
            var tiles = WorldMap.GetTilesInSight(x, y);

            var iX = 0;
            var iY = 0;
            foreach(var i in tiles)
            {
                var tx = (i.X - (x - 10)) * 15;
                var ty = (i.Y - (y - 10)) * 15;
                hashSet.Add(new Sprite(tx + X + iX, ty + Y + iY, 15, 15, i.Texture));
            }

            return hashSet;
        }

        private HashSet<Sprite> getEntities(int x, int y)
        {
            var hashSet = new HashSet<Sprite>();
            var tiles = WorldMap.GetEntitiesInSight(x, y);

            var iX = 0;
            var iY = 0;
            foreach (var i in tiles)
            {
                int tx = (int)(i.X - (x - 10)) * 15;
                int ty = (int)(i.Y - (y - 10)) * 15;
                hashSet.Add(new Sprite(tx + X + iX, ty + Y + iY, 15, 15, i.Texture));
            }

            return hashSet;
        }
    }
}
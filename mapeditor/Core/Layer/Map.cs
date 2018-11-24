﻿using LoESoft.MapEditor.Core.GUI.HUD;
using LoESoft.MapEditor.Core.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace LoESoft.MapEditor.Core.Layer
{
    public class Map
    {
        public MapSize Size { get; set; }
        public List<Layer> Layers { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }
        private int WIDTH_MAGIC_NUMBER => Width - Utils.TILE_SIZE * 2 - 6;
        private int HEIGHT_MAGIC_NUMBER => Height - Utils.TILE_SIZE * 2 - 6;

        private Rectangle _bounds { get; set; }

        public Map(MapSize size)
        {
            Size = size;
            Width = (int)Size;
            Height = (int)Size;
            Layers = new List<Layer>(5);

            for (var i = 0; i < 5; i++)
                Layers.Add(new Layer((MapLayer)i, Size));

            _bounds = new Rectangle(0, 0, WIDTH_MAGIC_NUMBER, HEIGHT_MAGIC_NUMBER);
        }

        public void Update()
        {
            var keyboard = Keyboard.GetState();

            if (MEGameControl.DrawOffset.Y > _bounds.Y)
                if (keyboard.IsKeyDown(Keys.W))
                    MEGameControl.DrawOffset.Y--;

            if (MEGameControl.DrawOffset.X > _bounds.X)
                if (keyboard.IsKeyDown(Keys.A))
                    MEGameControl.DrawOffset.X--;

            if (MEGameControl.DrawOffset.Y < _bounds.Height)
                if (keyboard.IsKeyDown(Keys.S))
                    MEGameControl.DrawOffset.Y++;

            if (MEGameControl.DrawOffset.X < _bounds.Width)
                if (keyboard.IsKeyDown(Keys.D))
                    MEGameControl.DrawOffset.X++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            try
            {
                Layers.OrderBy(layer => layer.MapLayer).Select(layer =>
                {
                    for (var x = 0; x < Width; x++)
                        for (var y = 0; y < Height; y++)
                        {
                            var chunk = layer.Chunk[y, x];

                            if (chunk != null)
                                spriteBatch.Draw(MEGameControl.Textures[chunk.Group], new Vector2(
                                    (y - MEGameControl.DrawOffset.X) * Utils.TILE_SIZE,
                                    (x - MEGameControl.DrawOffset.Y) * Utils.TILE_SIZE
                                    ), Utils.JamesBounds(chunk.BoundX, chunk.BoundY), Color.White);

                            if (layer.MapLayer == MapLayer.ABSTRACT && MEGameControl.ShowGrid)
                                spriteBatch.Draw(MEGameControl.GridTexture, new Vector2(
                                    (y - MEGameControl.DrawOffset.X) * Utils.TILE_SIZE,
                                    (x - MEGameControl.DrawOffset.Y) * Utils.TILE_SIZE
                                    ), Utils.JamesBounds(0, 0), Color.White);
                        }

                    return layer;
                }).ToList();
            }
            catch { }
        }
    }
}
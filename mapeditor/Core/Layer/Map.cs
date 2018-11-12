﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace LoESoft.MapEditor.Core.Layer
{
    public class Map
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Dictionary<int, List<Rectangle>> TileSets { get; set; }
        public List<Layer> Layers { get; set; }
        public int CurrentLayer { get; set; }

        private Rectangle _bounds { get; set; }

        public Map(int width, int height) : this()
        {
            Width = width;
            Height = height;
        }

        public Map(MapSize size) : this()
        {
            Width = (int)size;
            Height = (int)size;
        }

        private Map()
        {
            Layers = new List<Layer>(5);
            CurrentLayer = 0;

            for (var i = 0; i < 5; i++)
                Layers.Add(new Layer(i, Width, Height));

            TileSets = new Dictionary<int, List<Rectangle>>(4);
        }

        public void Update()
        {
            var keyboard = Keyboard.GetState();

            if (MapEditor.DrawOffset.Y > 0)
                if (keyboard.IsKeyDown(Keys.W))
                    MapEditor.DrawOffset.Y--;

            if (MapEditor.DrawOffset.X > 0)
                if (keyboard.IsKeyDown(Keys.A))
                    MapEditor.DrawOffset.X--;

            if (MapEditor.DrawOffset.Y < Height - 1)
                if (keyboard.IsKeyDown(Keys.S))
                    MapEditor.DrawOffset.Y++;

            if (MapEditor.DrawOffset.X < Width - 1)
                if (keyboard.IsKeyDown(Keys.D))
                    MapEditor.DrawOffset.X++;
        }

        public void Draw()
        {
            try
            {
                Layers.Select(layer =>
                {
                    for (var x = 0; x < Width; x++)
                        for (var y = 0; y < Height; y++)
                        {
                            var chunk = layer.Chunk[y, x];

                            if (chunk != null)
                            {
                                _bounds = TileSets[CurrentLayer][chunk.Coordinate - 1];

                                MapEditor.SpriteBatch.Draw(MapEditor.MapSprites[CurrentLayer],
                                    new Vector2(
                                        (y - MapEditor.DrawOffset.X) * Layer.TILE_SIZE,
                                        (x - MapEditor.DrawOffset.Y) * Layer.TILE_SIZE
                                    ), _bounds, Color.White);

                                if (layer.Id == Layer.MAP_SOLID_LAYER)
                                    MapEditor.SpriteBatch.Draw(MapEditor.MapSolid,
                                        new Vector2(
                                            (y - MapEditor.DrawOffset.X) * Layer.TILE_SIZE,
                                            (x - MapEditor.DrawOffset.Y) * Layer.TILE_SIZE
                                        ),
                                        new Rectangle(0, 0, Width, Height), new Color(0xff, 0xff, 0xff, 100));
                            }
                        }

                    return layer;
                }).ToList();
            }
            catch { }
        }

        public void LoadTileSet(int layer, Texture2D texture)
        {
            var spritesx = texture.Width / Layer.TILE_SIZE;
            var spritesy = texture.Height / Layer.TILE_SIZE;

            TileSets[layer] = new List<Rectangle>(spritesx * spritesy);

            for (var x = 0; x < spritesx; x++)
                for (var y = 0; y < spritesy; y++)
                {
                    _bounds = new Rectangle(x * Layer.TILE_SIZE, y * Layer.TILE_SIZE, Layer.TILE_SIZE, Layer.TILE_SIZE);

                    TileSets[layer].Add(_bounds);
                }
        }

        public void Save(string file)
        {
            try
            {
                using (var writer = new StreamWriter($"{file}.map"))
                {
                    writer.Write(Width);
                    writer.Write(Height);

                    foreach (var layer in Layers)
                        writer.WriteLine(layer.Save());
                }
            }
            catch (Exception e) { MessageBox.Show($"Save: {e}"); }
        }

        public void Load(string file)
        {
            try
            {
                using (var reader = new StreamReader(file))
                {
                    Width = int.Parse(reader.ReadLine());
                    Height = int.Parse(reader.ReadLine());

                    foreach (var layer in Layers)
                        layer.Load(reader.ReadLine());
                }
            }
            catch (Exception e) { MessageBox.Show($"Load: {e}"); }
        }
    }
}
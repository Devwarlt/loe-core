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
        public Dictionary<MapLayer, List<Rectangle>> TileSets { get; set; }
        public MapLayer CurrentLayer { get; set; }

        private int WIDTH_MAGIC_NUMBER => Width - Layer.TILE_SIZE * 3 - 2;
        private int HEIGHT_MAGIC_NUMBER => Height - Layer.TILE_SIZE * 2 - 6;

        private Rectangle _bounds { get; set; }

        public Map(MapSize size)
        {
            Size = size;
            Width = (int)Size;
            Height = (int)Size;
            Layers = new List<Layer>(5);
            CurrentLayer = MapLayer.UNDERGROUND;

            for (var i = 0; i < 5; i++)
                Layers.Add(new Layer((MapLayer)i, Size));

            TileSets = new Dictionary<MapLayer, List<Rectangle>>(5);

            _bounds = new Rectangle(0, 0, WIDTH_MAGIC_NUMBER, HEIGHT_MAGIC_NUMBER);
        }

        public void Update()
        {
            var keyboard = Keyboard.GetState();

            if (MapEditor.DrawOffset.Y > _bounds.Y)
                if (keyboard.IsKeyDown(Keys.W))
                    MapEditor.DrawOffset.Y--;

            if (MapEditor.DrawOffset.X > _bounds.X)
                if (keyboard.IsKeyDown(Keys.A))
                    MapEditor.DrawOffset.X--;

            if (MapEditor.DrawOffset.Y < _bounds.Height)
                if (keyboard.IsKeyDown(Keys.S))
                    MapEditor.DrawOffset.Y++;

            if (MapEditor.DrawOffset.X < _bounds.Width)
                if (keyboard.IsKeyDown(Keys.D))
                    MapEditor.DrawOffset.X++;
        }

        public void Draw()
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
                            {
                                MapEditor.SpriteBatch.Draw(MapEditor.MapSprites[layer.MapLayer], new Vector2(
                                    (y - MapEditor.DrawOffset.X) * Layer.TILE_SIZE,
                                    (x - MapEditor.DrawOffset.Y) * Layer.TILE_SIZE
                                    ), TileSets[chunk.Layer][chunk.Index], Color.White);
                            }

                            if (layer.MapLayer == MapLayer.ABSTRACT && MapEditor.ShowGrid)
                                MapEditor.SpriteBatch.Draw(MapEditor.MapSprites[MapLayer.ABSTRACT], new Vector2(
                                    (y - MapEditor.DrawOffset.X) * Layer.TILE_SIZE,
                                    (x - MapEditor.DrawOffset.Y) * Layer.TILE_SIZE
                                    ), TileSets[MapLayer.ABSTRACT][0], Color.White);
                        }

                    return layer;
                }).ToList();
            }
            catch { }
        }

        public void LoadTileSet(MapLayer layer, Texture2D texture)
        {
            var spritesx = texture.Width / Layer.TILE_SIZE;
            var spritesy = texture.Height / Layer.TILE_SIZE;

            TileSets[layer] = new List<Rectangle>(spritesx * spritesy);

            for (var x = 0; x < spritesx; x++)
                for (var y = 0; y < spritesy; y++)
                    TileSets[layer].Add(new Rectangle(x * Layer.TILE_SIZE, y * Layer.TILE_SIZE, Layer.TILE_SIZE, Layer.TILE_SIZE));

            App.Info($"- Layer {layer}: {TileSets[layer].Count} sprite{(TileSets[layer].Count > 1 ? "s" : "")}");
        }
    }
}
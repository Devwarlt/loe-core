using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LoESoft.Client.Assets
{
    public class SpriteSet
    {
        public Texture2D[,] Textures { get; private set; }
        public readonly int MaxX;
        public readonly int MaxY;

        public SpriteSet(int maxX = 16, int maxY = 16)
        {
            MaxX = maxX;
            MaxY = maxY;
            Textures = new Texture2D[maxX, maxY];
        }

        public Texture2D GetSprite(int x, int y) => Textures[x, y];

        public Texture2D[] GetSpritesByWidth(int y)
        {
            List<Texture2D> textures = new List<Texture2D>();

            for (var x = 0; x < MaxX; x++)
                textures.Add(Textures[x, y]);

            return textures.ToArray();
        }

        public Texture2D[] GetSpritesByHeight(int x)
        {
            List<Texture2D> textures = new List<Texture2D>();

            for (var y = 0; y < MaxY; y++)
                textures.Add(Textures[x, y]);

            return textures.ToArray();
        }

        public void Initialize(string file)
        {
            for (var x = 0; x < AssetLoader.LoadAsset<Texture2D>($"sprites/{file}").Width / 8 && x < MaxX; x++)
                for (var y = 0; y < AssetLoader.LoadAsset<Texture2D>($"sprites/{file}").Height / 8 && y < MaxY; y++)
                {
                    AssetLoader.LoadAsset<Texture2D>($"sprites/{file}").GetData(0, new Rectangle(x * 8, y * 8, 8, 8), new Color[8 * 8], 0, 8 * 8);

                    var texture = new Texture2D(AssetLoader.LoadAsset<Texture2D>($"sprites/{file}").GraphicsDevice, 8, 8);
                    texture.SetData(new Color[8 * 8]);

                    Textures[x, y] = texture;
                }
        }
    }
}
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

            GameClient.Info(Textures.Length.ToString());

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
            string path = $"sprites/{file}";

            var baseTexture = AssetLoader.LoadAsset<Texture2D>(path);

            int width = baseTexture.Width;
            int height = baseTexture.Height;

            for (var x = 0; (x < width / 8 && x < MaxX); x++)
                for (var y = 0; (y < height / 8 && y < MaxY); y++)
                {
                    Texture2D texture = new Texture2D(baseTexture.GraphicsDevice, 8, 8);
                    Rectangle region = new Rectangle(x * 8, y * 8, 8, 8);
                    var rawData = new Color[8 * 8];

                    baseTexture.GetData(0, region, rawData, 0, 8 * 8);

                    texture.SetData(rawData);

                    Textures[x, y] = texture;
                }
        }
    }
}

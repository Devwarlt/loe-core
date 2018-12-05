using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LoESoft.Client.Assets
{
    public class SpriteSet
    {
        public const int SPRITE_SIZE = 16; // auto-scale sprite size

        public Texture2D[,] Textures { get; private set; }

        public int MaxX { get; private set; }
        public int MaxY { get; private set; }

        public int SpriteWidth { get; private set; }
        public int SpriteHeight { get; private set; }

        public SpriteSet(string fileName, int spriteWidth, int spriteHeight)
        {
            SpriteWidth = spriteWidth;
            SpriteHeight = spriteHeight;
            Initialize(fileName);
        }

        public Texture2D GetSprite(int x, int y) => Textures[x, y];

        public List<Texture2D> GetSpritesByWidth(int y)
        {
            List<Texture2D> textures = new List<Texture2D>();

            for (var x = 0; x < MaxX; x++)
                textures.Add(Textures[x, y]);

            return textures;
        }

        public List<Texture2D> GetSpritesByHeight(int x)
        {
            List<Texture2D> textures = new List<Texture2D>();

            for (var y = 0; y < MaxY; y++)
                textures.Add(Textures[x, y]);

            return textures;
        }

        private void Initialize(string fileName)
        {
            var asset = AssetLoader.LoadAsset<Texture2D>("sprites/" + fileName);

            MaxX = asset.Width / SpriteWidth;
            MaxY = asset.Height / SpriteHeight;

            Textures = new Texture2D[MaxX, MaxY];

            for (var x = 0; x < MaxX; x++)
            {
                for (var y = 0; y < MaxY; y++)
                {
                    var data = new Color[SpriteWidth * SpriteHeight];
                    asset.GetData(0, new Rectangle(x * SpriteWidth, y * SpriteHeight, SpriteWidth, SpriteHeight), data, 0, SpriteWidth * SpriteHeight);

                    var texture = new Texture2D(asset.GraphicsDevice, SpriteWidth, SpriteHeight);
                    texture.SetData(data);

                    Textures[x, y] = texture;
                }
            }
        }

        public static SpriteSet LoadSet(string assetName, int spriteWidth = 8, int spriteHeight = 8) =>
            new SpriteSet(assetName, spriteWidth, spriteHeight);
    }
}
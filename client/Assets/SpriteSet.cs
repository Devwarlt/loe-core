using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LoESoft.Client.Assets
{
    public class SpriteSet
    {
        public const int SPRITE_SIZE = 16; // auto-scale sprite size

        public Texture2D[,] Textures { get; private set; }
        public int MAXX { get; private set; }
        public int MAXY { get; private set; }

        public SpriteSet(string fileName)
        {
            Initialize(fileName);
        }

        public Texture2D GetSprite(int x, int y) => Textures[x, y];

        public List<Texture2D> GetSpritesByWidth(int y)
        {
            List<Texture2D> textures = new List<Texture2D>();

            for (var x = 0; x < MAXX; x++)
                textures.Add(Textures[x, y]);

            return textures;
        }

        public List<Texture2D> GetSpritesByHeight(int x)
        {
            List<Texture2D> textures = new List<Texture2D>();

            for (var y = 0; y < MAXY; y++)
                textures.Add(Textures[x, y]);

            return textures;
        }

        private void Initialize(string fileName)
        {
            var asset = AssetLoader.LoadAsset<Texture2D>("sprites/" + fileName);

            Textures = new Texture2D[asset.Width / 8, asset.Height / 8];
            MAXX = asset.Width / 8;
            MAXY = asset.Height / 8;

            for (var x = 0; x < asset.Width / 8 && x < MAXX; x++)
            {
                for (var y = 0; y < asset.Height / 8 && y < MAXY; y++)
                {
                    var data = new Color[64];
                    asset.GetData(0, new Rectangle(x * 8, y * 8, 8, 8), data, 0, 64);

                    var texture = new Texture2D(asset.GraphicsDevice, 8, 8);
                    texture.SetData(data);

                    Textures[x, y] = texture;
                }
            }
        }

        public static SpriteSet LoadSet(string assetName) =>
            new SpriteSet(assetName);
    }
}
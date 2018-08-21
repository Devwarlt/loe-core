using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LoESoft.Client.Assets
{
    public static class AssetReader
    {
        public static Dictionary<string, ImageSet> Images;

        static AssetReader()
        {
            Images = new Dictionary<string, ImageSet>();
        }

        public static void Load(ContentManager contentManager)
        {
            GameClient._log.Info("Loading Sprite Images...");
            //AddImageSet(contentManager, name, width of each individual sprite, height of individual sprite)
            GameClient._log.Info("Loading Sprite Images... OK!");
        }

        private static void AddImageSet(ContentManager contentManager, string filename, int w, int h)
        {
            ImageSet imageSet = new ImageSet();
            imageSet.AddFromTexture(contentManager.Load<Texture2D>($"Sprites_Assets/{filename}"), w, h);

            Images.Add(filename, imageSet);
        }

        public static Texture2D Crop(this Texture2D texture, int x, int y, int width, int height)
        {
            var cropped = new Texture2D(texture.GraphicsDevice, width, height);

            var textureData = new Color[texture.Width * texture.Height];
            texture.GetData(textureData);

            var croppedData = new Color[width * height];
            for (var xx = 0; xx < width; xx++)
                for (var yy = 0; yy < height; yy++)
                    croppedData[xx + yy * width] = textureData[(xx + x) + (yy + y) * texture.Width];
            cropped.SetData(croppedData);
            return cropped;
        }
    }

    public class ImageSet
    {
        public Dictionary<KeyValuePair<int, int>, Texture2D> Images { get; private set; }

        public ImageSet()
        {
            Images = new Dictionary<KeyValuePair<int, int>, Texture2D>();
        }

        private void AddImage(int x, int y, Texture2D image) => Images.Add(new KeyValuePair<int, int>(x, y), image);

        public void AddFromTexture(Texture2D texture, int width, int height)
        {
            for (var y = 0; y < (texture.Height / height); y++)
                for (var x = 0; x < (texture.Width / width); x++)
                    AddImage(x, y, texture.Crop(x * width, y * height, width, height));
        }
    }
}

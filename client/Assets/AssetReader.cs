using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LoESoft.Client.Assets
{
    public static class AssetReader
    {
        public static Dictionary<string, ImageSet> _images;

        static AssetReader()
        {
            _images = new Dictionary<string, ImageSet>();
        }

        public static void Load(ContentManager contentManager)
        {
            Console.WriteLine("Loading Assets...");

            //AddImageSet(contentManager, name, width of each individual sprite, height of individual sprite)

            Console.WriteLine("Finished Loading Assets...");
        }

        private static void AddImageSet(ContentManager contentManager, string filename, int w, int h)
        {
            ImageSet imageSet = new ImageSet();
            imageSet.AddFromTexture(contentManager.Load<Texture2D>($"Sprites_Assets/{filename}"), w, h);

            _images.Add(filename, imageSet);
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
        private List<Texture2D> Images;
        
        public ImageSet()
        {
            Images = new List<Texture2D>();
        }

        private void AddImage(Texture2D image) => Images.Add(image);

        public void AddFromTexture(Texture2D texture, int width, int height)
        {
            for (var y = 0; y < (texture.Height / height); y++)
                for (var x = 0; x < (texture.Width / width); x++)
                    AddImage(texture.Crop(x * width, y * height, width, height));
        }
    }
}

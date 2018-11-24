using Microsoft.Xna.Framework.Graphics;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using XnaRectangle = Microsoft.Xna.Framework.Rectangle;

namespace LoESoft.MapEditor.Core.Util
{
    public static class Utils
    {
        public static int TILE_SIZE = 16;

        public static string GetMapFolderPath => Path.Combine(MainDir, $"/{BaseDir}/");

        public static string GetPath(string fileName) => Path.Combine(GetMapFolderPath, fileName);

        public static XnaRectangle JamesBounds(int x, int y) => new XnaRectangle(x * TILE_SIZE, y * TILE_SIZE, TILE_SIZE, TILE_SIZE);

        private static string MainDir => Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private static string BaseDir => "BRMEMaps";

        public static Texture2D LoadEmbeddedTexture(GraphicsDevice graphics, string file)
        {
            var assembly = Assembly.GetExecutingAssembly();
            Texture2D texture2d = null;

            foreach (var name in assembly.GetManifestResourceNames())
                if (name.Contains(file))
                {
                    using (var stream = assembly.GetManifestResourceStream(name))
                        if (stream != null)
                            texture2d = Texture2D.FromStream(graphics, stream);
                    break;
                }

            return texture2d;
        }

        public static Texture2D LoadEmbeddedSpritesheetToTexture2D(GraphicsDevice graphics, string file)
        {
            var assembly = Assembly.GetExecutingAssembly();

            foreach (var name in assembly.GetManifestResourceNames())
                if (name.Contains(file))
                {
                    using (var stream = assembly.GetManifestResourceStream(name))
                        if (stream != null)
                            return Texture2D.FromStream(graphics, stream);
                    break;
                }

            return null;
        }

        public static Image LoadEmbeddedSpritesheetToImage(string file)
        {
            var assembly = Assembly.GetExecutingAssembly();

            foreach (var name in assembly.GetManifestResourceNames())
                if (name.Contains(file))
                {
                    using (var stream = assembly.GetManifestResourceStream(name))
                        if (stream != null)
                            return Image.FromStream(stream);
                    break;
                }

            return null;
        }

        public static Image[,] CropSpritesheet(Image image)
        {
            try
            {
                var width = image.Width / TILE_SIZE;
                var height = image.Height / TILE_SIZE;
                var spriteitems = new Image[width, height];
                var actualindex = 0;

                for (var x = 0; x < width; x++)
                    for (var y = 0; y < height; y++)
                    {
                        spriteitems[x, y] = new Bitmap(TILE_SIZE, TILE_SIZE);

                        var graphics = Graphics.FromImage(spriteitems[x, y]);
                        graphics.DrawImage(image, new Rectangle(0, 0, TILE_SIZE, TILE_SIZE), new Rectangle(x * TILE_SIZE, y * TILE_SIZE, TILE_SIZE, TILE_SIZE), GraphicsUnit.Pixel);
                        graphics.Dispose();

                        actualindex++;
                    }

                return spriteitems;
            }
            catch (Exception e) { App.Error(e); }

            return null;
        }
    }
}
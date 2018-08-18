using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoESoft.Client.Assets
{
    public static class AssetReader
    {
        public static Dictionary<string, ImageSet> _images;

        static AssetReader()
        {
            _images = new Dictionary<string, ImageSet>();
        }

        public static void Load()
        {
            Console.WriteLine("Loading Assets...");


            Console.WriteLine("Finished Loading Assets...");
        }


    }

    public class ImageSet
    {
        private List<Texture2D> Images;


        public ImageSet()
        {
            Images = new List<Texture2D>();
        }

        public void AddImage(Texture2D image) => Images.Add(image);
    }
}

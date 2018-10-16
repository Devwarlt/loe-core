using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LoESoft.Client.Assets
{
    public static class AssetLibrary
    {
        public static Dictionary<string, Texture2D> Images { get; set; }

        public static void AddImage(string name, string file)
        {
            if (Images == null)
                Images = new Dictionary<string, Texture2D>();

            Images.Add(name, AssetLoader.LoadAsset<Texture2D>(file));
        }
    }
}
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

            var asset = AssetLoader.LoadAsset<Texture2D>(file);
            Images.Add(name, asset);
        }

        public static Texture2D[] GetAnimationTexture(int objectType, int yoffset = 0, int xoffset = 0, int maxcount = 3)
        {
            return null;//TODO: Proper Sprites Loading
        }
    }
}

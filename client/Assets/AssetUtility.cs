using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LoESoft.Client.Assets
{
    public class AssetUtility
    {
        public static ImageSet GetImageSet(string name) => AssetReader.Images[name];

        public static Texture2D GetImageFromSet(string name, string position)
        {
            var set = GetImageSet(name);
            var pos = position.Substring(2);
            
            int key1 = pos[0];
            int key2 = pos[1];

            return set.Images[new KeyValuePair<int, int>(key1, key2)];
        }

        public static Texture2D GetImageFromSet(string name, int position)
        {
            var set = GetImageSet(name);

            return set.Images[new KeyValuePair<int, int>(0, position)];
        }
    }
}

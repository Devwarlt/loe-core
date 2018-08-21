using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using static LoESoft.Client.Assets.Serialization.AssetTypes.Utils.Utils;

namespace LoESoft.Client.Assets
{
    public class AssetUtility
    {
        public static ImageSet GetImageSet(string name) => AssetReader.Images[name];

        public static Texture2D GetImageFromSet(string name, int position, TextureType type)
        {
            var set = GetImageSet(name);

            if (position > (0xF) && type != TextureType.AnimatedTexture)
            {
                int pos2 = position - 0xF;

                return set.Images[new KeyValuePair<int, int>(position, pos2)];
            }
            return set.Images[new KeyValuePair<int, int>(0, position)];
        }
    }
}

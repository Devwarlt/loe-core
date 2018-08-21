using LoESoft.Client.Assets.Serialization.AssetTypes;
using Microsoft.Xna.Framework.Graphics;
using static LoESoft.Client.Assets.Serialization.AssetTypes.Utils.Utils;

namespace LoESoft.Client.Assets
{
    public class XmlUtility
    {
        public static Texture2D GetTextureFromId(int id)
        {
            var voc = Vocation._assets[id];

            return AssetUtility.GetImageFromSet(voc.AssetTexture._file, (int)voc.AssetTexture._index
                , voc.AssetTexture._textureType);
        }
    }
}

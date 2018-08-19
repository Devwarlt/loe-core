using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Assets
{
    public class XmlUtility
    {
        public static Texture2D GetTextureFromType(ushort type)
        {
            var elem = XmlReader.XmlsDictionary[type];
            Texture2D texture = null;

            foreach(var i in elem.Elements("Texture"))
            {
                string imagefile = i.Element("File").Value;
                string index = i.Element("Index").Value;

                texture = AssetUtility.GetImageFromSet(imagefile, index);
            }

            return texture;
        }


    }
}

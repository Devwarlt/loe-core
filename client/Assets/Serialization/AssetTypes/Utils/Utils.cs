using System.Globalization;
using System.Xml.Linq;

namespace LoESoft.Client.Assets.Serialization.AssetTypes.Utils
{
    public class Utils
    {
        public class AssetTexture
        {
            public TextureType _textureType { get; set; }
            public string _file { get; set; }
            public uint _index { get; set; }

            public static TextureType GetTextureType(string textureType)
            {
                switch (textureType)
                {
                    case "animated": return TextureType.AnimatedTexture;
                    default: return TextureType.Texture;
                }
            }
        }

        public enum TextureType
        {
            Texture,
            AnimatedTexture
        }

        public static T GetInheritData<T>(XElement parent, string child)
        {
            string data = !(parent.Element(child) == null) ? parent.Element(child).Value : null;

            if (typeof(T) == typeof(int))
                return (T)(object)(data == null ? 0 : int.Parse(data));
            if (typeof(T) == typeof(uint))
                return (T)(object)(data == null ? 0 : (data.Contains("0x") ? uint.Parse(data.Replace("0x", null), NumberStyles.AllowHexSpecifier) : uint.Parse(data)));
            if (typeof(T) == typeof(string))
                return (T)(object)data;
            if (typeof(T) == typeof(bool))
                return (T)(object)(data == null ? false : bool.Parse(data));
            if (typeof(T) == typeof(double))
                return (T)(object)(data == null ? 0 : double.Parse(data));

            return (T)(object)null;
        }
    }
}

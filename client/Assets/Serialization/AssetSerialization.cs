using LoESoft.Client.Assets.Serialization.AssetTypes;
using System.Xml.Linq;

namespace LoESoft.Client.Assets.Serialization
{
    public class AssetSerialization
    {
        public static void Serialize()
        {
            foreach (var asset in XmlReader._assets)
                SerializeAssets(asset.Key, XElement.Parse(asset.Value.Item1));
        }

        private static void SerializeAssets(AssetType type, XElement root)
        {
            switch (type)
            {
                case AssetType.Vocation: Vocation.Load(root); break;
                default: break;
            }
        }

        public static string GetElementByAssetType(AssetType assetType)
            => XmlReader._assets[assetType].Item2;
    }
}

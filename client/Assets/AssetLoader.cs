using Microsoft.Xna.Framework.Content;

namespace LoESoft.Client.Assets
{
    public sealed class AssetLoader
    {
        private static ContentManager Content { get; set; }

        public static void Init(ContentManager contentManager) => Content = contentManager;

        public static T LoadAsset<T>(string assetName) => Content.Load<T>(assetName);
    }
}

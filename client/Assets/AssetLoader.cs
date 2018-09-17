using Microsoft.Xna.Framework.Content;

namespace LoESoft.Client.Assets
{
    public sealed class AssetLoader
    {
        private static ContentManager Content { get; set; }

        public static void Init(ContentManager contentManager) => Content = contentManager;

        public static T LoadAsset<T>(string assetName)
        {
            T content = default(T);

            if (Content != null)
                content = Content.Load<T>(assetName);

            return content;
        }
    }
}

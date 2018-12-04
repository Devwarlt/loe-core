using LoESoft.AssetsManager.Core.Assets.Structure;
using System.Collections.Generic;
using System.Drawing;

namespace LoESoft.AssetsManager.Core.Assets
{
    public class SpriteLibrary
    {
        public static readonly Dictionary<string, KeyValuePair<string, Image>> Spritesheets = new Dictionary<string, KeyValuePair<string, Image>>();

        public static void Init(List<SpritesheetFile> spritesheets)
        {
            LoadContents(spritesheets);

            DisplayFormattedAmount(Spritesheets, "spritesheet", "spritesheets");
        }

        private static void DisplayFormattedAmount<T>(Dictionary<string, T> data, string singular, string plural)
            => App.Info($"- Loaded {data.Keys.Count} {(data.Keys.Count > 1 ? plural : singular)}.");

        private static void LoadContents(List<SpritesheetFile> spritesheets)
        {
            foreach (var spritesheet in spritesheets)
                if (!Spritesheets.ContainsKey(spritesheet.File))
                    Spritesheets.Add(spritesheet.File, new KeyValuePair<string, Image>(spritesheet.Size, spritesheet.Image));
        }
    }
}
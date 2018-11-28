using LoESoft.AssetsManager.Core.Assets.Structure;
using System.Collections.Generic;
using System.Drawing;

namespace LoESoft.AssetsManager.Core.Assets
{
    public class SpriteLibrary
    {
        public static readonly Dictionary<string, Image> Spritesheets = new Dictionary<string, Image>();

        public static void Init(List<Spritesheet> spritesheets)
        {
            LoadContents(spritesheets);

            DisplayFormattedAmount(Spritesheets, "spritesheet", "spritesheets");
        }

        private static void DisplayFormattedAmount<T>(Dictionary<string, T> data, string singular, string plural)
            => App.Info($"- Loaded {data.Keys.Count} {(data.Keys.Count > 1 ? plural : singular)}.");

        private static void LoadContents(List<Spritesheet> spritesheets)
        {
            foreach (var spritesheet in spritesheets)
                Spritesheets.Add(spritesheet.File, spritesheet.Image);
        }
    }
}
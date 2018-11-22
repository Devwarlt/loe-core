using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LoESoft.Client.Assets
{
    public static class AssetLibrary
    {
        public static Dictionary<string, Texture2D> Images { get; set; } = new Dictionary<string, Texture2D>();
        public static Dictionary<string, SpriteSet> Sprites { get; set; } = new Dictionary<string, SpriteSet>();

        public static void Init()
        {
            InitImages();
            InitSprites();
        }

        private static void InitImages()
        {
            AddImage("btnImage");
            AddImage("exitImage");
            AddImage("rectImage");
            AddImage("titleScreenBackground");
            AddImage("loeLogo");
            AddImage("characterRect");
            AddImage("panelImage");
            AddImage("titleScreenBackGround");
        }

        private static void InitSprites()
        {
            AddSprites("playersEmbed");
            AddSprites("tilesEmbed");
            AddSprites("objectsEmbed");
            AddSprites("itemsEmbed");
            AddSprites("iconSprites");
        }

        public static void AddSprites(string filename) =>
            Sprites.Add(filename, SpriteSet.LoadSet(filename));

        public static void AddImage(string file) =>
            Images.Add(file, AssetLoader.LoadAsset<Texture2D>("images/" + file));
    }
}
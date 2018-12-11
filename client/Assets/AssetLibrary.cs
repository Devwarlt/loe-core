using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LoESoft.Client.Assets
{
    public static class AssetLibrary
    {
        public static Dictionary<string, Texture2D> Images { get; set; }
        public static Dictionary<string, SpriteSet> Sprites { get; set; }

        public static void Init()
        {
            Images = new Dictionary<string, Texture2D>();
            Sprites = new Dictionary<string, SpriteSet>();

            InitImages();
            InitSprites();
        }

        private static void InitImages()
        {
            AddImage("btnImage");
            AddImage("exitImage");
            AddImage("rectImage");
            AddImage("panelImage");
            AddImage("titleScreenBackground");
            AddImage("titleScreenBackGround");
            AddImage("loeLogo");
            AddImage("characterRect");
            AddImage("characterDisplayRect");
            AddImage("itemDisplayRect");
            AddImage("titleDisplayRect");
            AddImage("statusBarRect");
        }

        private static void InitSprites()
        {
            AddSprites("iconSprites");
            AddSprites("playersEmbed", 32, 32);
            AddSprites("tilesEmbed");
            AddSprites("objectsEmbed");
            AddSprites("itemsEmbed");
            AddSprites("tileSet16x16");
        }

        public static void AddSprites(string filename, int w = 8, int h = 8) =>
            Sprites.Add(filename, SpriteSet.LoadSet(filename, w, h));

        public static void AddImage(string file) =>
            Images.Add(file, AssetLoader.LoadAsset<Texture2D>("images/" + file));
    }
}
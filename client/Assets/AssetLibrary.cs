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
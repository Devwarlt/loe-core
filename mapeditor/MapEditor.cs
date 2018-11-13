using LoESoft.MapEditor.Core.GUI.Forms;
using LoESoft.MapEditor.Core.Layer;
using LoESoft.MapEditor.Core.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Windows.Forms;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace LoESoft.MapEditor
{
    public class MapEditor : Game
    {
        public static SpriteBatch SpriteBatch { get; set; }
        public static GraphicsDeviceManager GraphicsDeviceManager { get; set; }
        public static MapState MapState { get; set; }
        public static Vector2 ClientBounds { get; set; }
        public static bool Quit { get; set; }
        public static string ActualMapName { get; set; }
        public static MapSize ActualMapSize { get; set; }
        public static string FormattedMapName { get; set; }
        public static string CurrentFileName { get; set; }
        public static string LoadFileName { get; set; }
        public static Map Map { get; set; }
        public static MapLayer CurrentLayer { get; set; }
        public static int CurrentIndex { get; set; }
        public static Dictionary<MapLayer, Texture2D> MapSprites { get; set; }
        public static Texture2D MapSolid { get; set; }

        public static Vector2 DrawOffset = Vector2.Zero;

        private static MouseState MouseState { get; set; }
        private static KeyboardState KeyboardState { get; set; }

        public MapEditor()
        {
            GraphicsDeviceManager = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = 800,
                PreferredBackBufferHeight = 600
            };

            Content.RootDirectory = "Content";

            IsMouseVisible = true;

            CurrentLayer = MapLayer.UNDERGROUND;
            CurrentIndex = 0;
        }

        protected override void Initialize()
        {
            MapState = MapState.Active;
            ClientBounds = new Vector2(Window.ClientBounds.Height, Window.ClientBounds.Width);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            App.Info("Creating a sample map...");

            Map = new Map(MapSize.SIZE_128);

            MapSolid = Utils.LoadEmbeddedTexture("solid-sprite.png");
            MapSprites = new Dictionary<MapLayer, Texture2D>(4);

            for (var i = 0; i < 4; i++)
                MapSprites.Add((MapLayer)i, new Texture2D(GraphicsDevice, 1, 1));

            MapSprites[MapLayer.UNDERGROUND] = Utils.LoadEmbeddedTexture("sample-spritesheet-0.png");
            MapSprites[MapLayer.GROUND] = Utils.LoadEmbeddedTexture("sample-spritesheet-1.png");
            MapSprites[MapLayer.OBJECT] = Utils.LoadEmbeddedTexture("sample-spritesheet-2.png");
            MapSprites[MapLayer.SKY] = Utils.LoadEmbeddedTexture("sample-spritesheet-3.png");

            ActualMapName = "sample";
            ActualMapSize = MapSize.SIZE_128;
            FormattedMapName = $"(Size: {(int)ActualMapSize} x {(int)ActualMapSize}) Map: {ActualMapName}";

            App.Info($"- Name: {ActualMapName}");
            App.Info($"- Size: {(int)ActualMapSize} x {(int)ActualMapSize}");

            LoadTileSets();

            App.Info("Creating a sample map... OK!");

            FormatWindowTitle();

            App.Info("Game Map Editor is loading... OK!\n");
        }

        private void LoadTileSets(bool loading = true)
        {
            App.Info($"{(loading ? "Loading" : "Reloading")} tile sets...");

            foreach (var mapsprite in MapSprites)
                Map.LoadTileSet(mapsprite.Key, mapsprite.Value);

            App.Info($"{(loading ? "Loading" : "Reloading")} tile sets... OK!");
        }

        private void FormatWindowTitle()
            => Window.Title = $"LoESoft - {App.Name} | (Layer: [({(int)CurrentLayer})] {CurrentLayer} / Sprite: {CurrentIndex}) | {FormattedMapName}";

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (Quit)
                Exit();

            FormatWindowTitle();

            var keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.PageUp) && !KeyboardState.IsKeyDown(Keys.PageUp))
                if ((int)CurrentLayer < (int)MapLayer.ABSTRACT - 1)
                    CurrentLayer++;

            if (keyboard.IsKeyDown(Keys.PageDown) && !KeyboardState.IsKeyDown(Keys.PageDown))
                if (CurrentLayer > (int)MapLayer.UNDERGROUND)
                    CurrentLayer--;

            if (keyboard.IsKeyDown(Keys.Up) && !KeyboardState.IsKeyDown(Keys.Up))
                if (CurrentIndex < Map.TileSets[CurrentLayer].Count - 1)
                    CurrentIndex++;

            if (keyboard.IsKeyDown(Keys.Down) && !KeyboardState.IsKeyDown(Keys.Down))
                if (CurrentIndex > 0)
                    CurrentIndex--;

            if (keyboard.IsKeyDown(Keys.N) && !KeyboardState.IsKeyDown(Keys.N))
            {
                MapState = MapState.Inactive;

                var newmap = new NewMapForm();
                newmap.ShowDialog();

                if (newmap.DialogResult == DialogResult.OK)
                {
                    App.Info("Creating new map...");

                    Map = new Map(newmap.MapSize);

                    CurrentLayer = MapLayer.UNDERGROUND;
                    CurrentIndex = 0;
                    DrawOffset = Vector2.Zero;
                    ActualMapName = newmap.MapName;
                    ActualMapSize = newmap.MapSize;
                    FormattedMapName = $"(Size: {(int)ActualMapSize} x {(int)ActualMapSize}) Map: {ActualMapName}";

                    App.Info($"- Name: {newmap.MapName}");
                    App.Info($"- Size: {(int)ActualMapSize} x {(int)ActualMapSize}");

                    LoadTileSets(false);

                    App.Info("Creating new map... OK!\n");
                }

                MapState = MapState.Active;
            }

            if (MapState == MapState.Active && MapSprites != null)
            {
                Map.CurrentLayer = CurrentLayer;

                if (CurrentLayer == MapLayer.ABSTRACT)
                    Map.Layers[(int)CurrentLayer].SetTiles(new ChunkData()
                    {
                        Coordinate = 1
                    });
                else
                    Map.Layers[(int)CurrentLayer].SetTiles(new ChunkData()
                    {
                        Coordinate = CurrentIndex
                    });
            }

            MouseState = Mouse.GetState();
            KeyboardState = keyboard;
            Map.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            SpriteBatch.Begin();
            SpriteBatch.Draw(MapSolid, new Rectangle(
                -(int)DrawOffset.X * Map.Width,
                -(int)DrawOffset.Y * Map.Height,
                Map.Width * Layer.TILE_SIZE,
                Map.Height * Layer.TILE_SIZE
                ), Color.White);

            Map.Draw();

            if (MapSprites != null && CurrentLayer != MapLayer.ABSTRACT)
                SpriteBatch.Draw(MapSprites[CurrentLayer], new Vector2(
                    MouseState.X - Layer.TILE_SIZE / 2,
                    MouseState.Y - Layer.TILE_SIZE / 2
                    ), Map.TileSets[CurrentLayer][CurrentIndex], Color.White);

            base.Draw(gameTime);

            SpriteBatch.End();
        }
    }
}
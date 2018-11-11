using LoESoft.MapEditor.Core.GUI.HUD;
using LoESoft.MapEditor.Core.Layer;
using LoESoft.MapEditor.Core.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LoESoft.MapEditor
{
    public class MapEditor : Game
    {
        public static SpriteBatch SpriteBatch { get; set; }
        public static GraphicsDeviceManager GraphicsDeviceManager { get; set; }
        public static MapState MapState { get; set; }
        public static Vector2 ClientBounds { get; set; }
        public static bool Quit { get; set; }
        public static string MapName { get; set; }
        public static string CurrentFileName { get; set; }
        public static string LoadFileName { get; set; }
        public static Map Map { get; set; }
        public static int CurrentLayer { get; set; }
        public static int CurrentIndex { get; set; }
        public static Dictionary<int, Texture2D> MapSprites { get; set; }
        public static Texture2D MapSolid { get; set; }

        public static Vector2 DrawOffset = Vector2.Zero;

        private static HUD HUD { get; set; }
        private static Texture2D MapCursor { get; set; }
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

            CurrentLayer = 0;
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
            Map = new Map(MapSize.SIZE_128);
            MapCursor = Utils.LoadEmbeddedTexture("mouse-icon.png");
            MapSolid = Utils.LoadEmbeddedTexture("solid-sprite.png");
            MapSprites = new Dictionary<int, Texture2D>(4);

            for (var i = 0; i < 4; i++)
                MapSprites.Add(i, new Texture2D(GraphicsDevice, 1, 1));

            MapSprites[0] = Utils.LoadEmbeddedTexture("sample-spritesheet-0.png");
            MapSprites[1] = Utils.LoadEmbeddedTexture("sample-spritesheet-1.png");
            MapSprites[2] = Utils.LoadEmbeddedTexture("sample-spritesheet-2.png");
            MapSprites[3] = Utils.LoadEmbeddedTexture("sample-spritesheet-3.png");

            foreach (var mapsprite in MapSprites)
                Map.LoadTileSet(mapsprite.Key, mapsprite.Value);

            HUD = new HUD();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (Quit)
                Exit();

            if (!string.IsNullOrEmpty(MapName))
                Window.Title = $"{App.Name}: {MapName}";

            var keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.PageUp) && !KeyboardState.IsKeyDown(Keys.PageUp))
                if (CurrentLayer < Layer.MAP_SOLID_LAYER)
                    CurrentLayer++;

            if (keyboard.IsKeyDown(Keys.PageDown) && !KeyboardState.IsKeyDown(Keys.PageDown))
                if (CurrentLayer > 0)
                    CurrentLayer--;

            if (keyboard.IsKeyDown(Keys.Up) && !KeyboardState.IsKeyDown(Keys.Up))
                if (CurrentIndex < Map.TileSets.Count - 1)
                    CurrentIndex++;

            if (keyboard.IsKeyDown(Keys.Down) && !KeyboardState.IsKeyDown(Keys.Down))
                if (CurrentIndex > 0)
                    CurrentIndex--;

            if (MapState == MapState.Active && MapSprites != null)
            {
                Map.CurrentLayer = CurrentLayer;

                if (CurrentLayer == Layer.MAP_SOLID_LAYER)
                    Map.Layers[Layer.MAP_SOLID_LAYER].SetTiles(new ChunkData()
                    {
                        Coordinate = 1
                    });
                else
                    Map.Layers[CurrentLayer].SetTiles(new ChunkData()
                    {
                        Coordinate = CurrentIndex
                    });
            }

            MouseState = Mouse.GetState();
            KeyboardState = keyboard;
            Map.Update();
            HUD.Update();

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
            //HUD.Draw();

            if (MapSprites != null && CurrentLayer != Layer.MAP_SOLID_LAYER)
                SpriteBatch.Draw(MapSprites[CurrentLayer], new Vector2(
                    MouseState.X - Layer.TILE_SIZE / 2,
                    MouseState.Y - Layer.TILE_SIZE / 2
                    ), Map.TileSets[CurrentLayer][CurrentIndex], Color.White);

            base.Draw(gameTime);

            SpriteBatch.End();
        }
    }
}
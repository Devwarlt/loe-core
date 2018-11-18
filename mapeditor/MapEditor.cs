using LoESoft.MapEditor.Core.GUI;
using LoESoft.MapEditor.Core.Layer;
using LoESoft.MapEditor.Core.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public static string CurrentFileName { get; set; }
        public static string LoadFileName { get; set; }
        public static Map Map { get; set; }
        public static MapLayer CurrentLayer { get; set; }
        public static int CurrentIndex { get; set; }
        public static Dictionary<MapLayer, Texture2D> MapSprites { get; set; }
        public static bool ShowGrid { get; set; }
        public static InterfaceForm InterfaceForm { get; set; }

        public static Vector2 DrawOffset = Vector2.Zero;

        private static MouseState MouseState { get; set; }
        private static KeyboardState KeyboardState { get; set; }

        public MapEditor()
        {
            GraphicsDeviceManager = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = 800,
                PreferredBackBufferHeight = 608
            };

            Content.RootDirectory = "Content";

            IsMouseVisible = true;

            CurrentLayer = MapLayer.UNDERGROUND;
            CurrentIndex = 0;

            InterfaceForm = new InterfaceForm();
            InterfaceForm.Show();
        }

        protected override void OnActivated(object sender, EventArgs args) => base.OnActivated(sender, args);

        protected override void Initialize()
        {
            MapState = MapState.Active;
            ClientBounds = new Vector2(Window.ClientBounds.Height, Window.ClientBounds.Width);

            var thisForm = (Form)Control.FromHandle(Window.Handle);
            thisForm.MinimizeBox = false;
            thisForm.Move += ThisForm_Move;
            ThisForm_Move(null, null);

            base.Initialize();
        }

        private void ThisForm_Move(object sender, EventArgs e)
            => InterfaceForm.Location = new System.Drawing.Point(Window.Position.X + GraphicsDeviceManager.DefaultBackBufferWidth + 10, Window.Position.Y);

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            App.Info("Creating a sample map...");

            ShowGrid = true;
            Map = new Map(MapSize.SIZE_128);
            MapSprites = new Dictionary<MapLayer, Texture2D>(4);

            for (var i = 0; i < 5; i++)
                MapSprites.Add((MapLayer)i, new Texture2D(GraphicsDevice, 1, 1));

            MapSprites[MapLayer.UNDERGROUND] = Utils.LoadEmbeddedTexture("sample-spritesheet-0.png");
            MapSprites[MapLayer.GROUND] = Utils.LoadEmbeddedTexture("sample-spritesheet-1.png");
            MapSprites[MapLayer.OBJECT] = Utils.LoadEmbeddedTexture("sample-spritesheet-2.png");
            MapSprites[MapLayer.SKY] = Utils.LoadEmbeddedTexture("sample-spritesheet-3.png");
            MapSprites[MapLayer.ABSTRACT] = Utils.LoadEmbeddedTexture("sample-grid.png");

            ActualMapName = "sample";
            ActualMapSize = MapSize.SIZE_128;

            App.Info($"- Name: {ActualMapName}");
            App.Info($"- Size: {(int)ActualMapSize} x {(int)ActualMapSize}");

            LoadTileSets();

            App.Info("Creating a sample map... OK!");
            App.Info("Game Map Editor is loading... OK!\n");
        }

        public static void LoadTileSets(bool loading = true)
        {
            App.Info($"{(loading ? "Loading" : "Reloading")} tile sets...");

            foreach (var mapsprite in MapSprites)
                Map.LoadTileSet(mapsprite.Key, mapsprite.Value);

            App.Info($"{(loading ? "Loading" : "Reloading")} tile sets... OK!");
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (Quit)
                Exit();

            InterfaceForm.UpdateInfo();

            if (!IsActive && Form.ActiveForm != InterfaceForm && InterfaceForm.Visible)
                InterfaceForm.Visible = false;

            if (IsActive && !InterfaceForm.Visible)
            {
                InterfaceForm.Visible = true;
                InterfaceForm.BringToFront();
            }

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

            if (MapState == MapState.Active && MapSprites != null && CurrentLayer != MapLayer.ABSTRACT)
            {
                Map.CurrentLayer = CurrentLayer;
                Map.Layers.FirstOrDefault(layer => layer.MapLayer == CurrentLayer).SetTiles(MouseState, new ChunkData()
                {
                    Layer = CurrentLayer,
                    Index = CurrentIndex
                });
            }

            MouseState = Mouse.GetState();
            KeyboardState = keyboard;
            Map.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGreen);
            SpriteBatch.Begin();

            Map.Draw();

            if (MapSprites != null && CurrentLayer != MapLayer.ABSTRACT)
                DrawSpriteOnCursor();

            base.Draw(gameTime);

            SpriteBatch.End();
        }

        private void DrawSpriteOnCursor()
            => SpriteBatch.Draw(MapSprites[CurrentLayer], new Vector2(
                MouseState.X - Utils.TILE_SIZE / 2,
                MouseState.Y - Utils.TILE_SIZE / 2
                ), Map.TileSets[CurrentLayer][CurrentIndex], Color.White);
    }
}
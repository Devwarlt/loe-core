using LoESoft.MapEditor.Core.Assets;
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
        public static Dictionary<string, Texture2D> MapSpritesheets { get; set; }
        public static bool ShowGrid { get; set; }
        public static Texture2D GridTexture { get; set; }
        public static InterfaceForm InterfaceForm { get; set; }
        public static InteractiveObject InteractiveObject { get; set; }

        public static Vector2 DrawOffset = Vector2.Zero;

        private static MouseState MouseState { get; set; }

        public MapEditor()
        {
            GraphicsDeviceManager = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = 800,
                PreferredBackBufferHeight = 608
            };

            Content.RootDirectory = "Content";
        }

        protected override void OnActivated(object sender, EventArgs args) => base.OnActivated(sender, args);

        protected override void Initialize()
        {
            MapState = MapState.Active;
            ClientBounds = new Vector2(Window.ClientBounds.Height, Window.ClientBounds.Width);

            base.Initialize();
        }

        private void ThisForm_Move(object sender, EventArgs e)
            => InterfaceForm.Location = new System.Drawing.Point(Window.Position.X + GraphicsDeviceManager.DefaultBackBufferWidth + 10, Window.Position.Y);

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            XmlLibrary.Init();

            App.Info("Creating a sample map...");

            Map = new Map(MapSize.SIZE_128);
            ShowGrid = true;
            GridTexture = Utils.LoadEmbeddedTexture("sample-grid.png");
            InteractiveObject = null;

            var spritesheets = new List<string>()
            {
                "objectsEmbed",
                "tilesEmbed"
            };

            MapSpritesheets = new Dictionary<string, Texture2D>();

            for (var i = 0; i < spritesheets.Count; i++)
            {
                var sprite = Utils.LoadEmbeddedSpritesheetToTexture2D(spritesheets[i]);

                MapSpritesheets.Add(sprite.Key, sprite.Value);
            }

            ActualMapName = "sample";
            ActualMapSize = MapSize.SIZE_128;

            App.Info($"- Name: {ActualMapName}");
            App.Info($"- Size: {(int)ActualMapSize} x {(int)ActualMapSize}");
            App.Info("Creating a sample map... OK!");

            IsMouseVisible = true;

            CurrentLayer = MapLayer.UNDERGROUND;
            CurrentIndex = 0;

            InterfaceForm = new InterfaceForm();
            InterfaceForm.Show();

            var thisForm = (Form)Control.FromHandle(Window.Handle);
            thisForm.MinimizeBox = false;
            thisForm.Move += ThisForm_Move;
            ThisForm_Move(null, null);

            App.Info("Game Map Editor is loading... OK!\n");
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

            if (MapState == MapState.Active && MapSpritesheets != null && CurrentLayer != MapLayer.ABSTRACT)
            {
                Map.CurrentLayer = CurrentLayer;
                Map.Layers.FirstOrDefault(layer => layer.MapLayer == CurrentLayer).SetTiles(MouseState, new ChunkData()
                {
                    Layer = CurrentLayer,
                    Index = CurrentIndex
                });
            }

            MouseState = Mouse.GetState();
            Map.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGreen);
            SpriteBatch.Begin();

            Map.Draw();

            // TODO!
            //if (InteractiveObject != null && MapSpritesheets != null && CurrentLayer != MapLayer.ABSTRACT)
            //    DrawSpriteOnCursor();

            base.Draw(gameTime);

            SpriteBatch.End();
        }

        // TODO!
        //private void DrawSpriteOnCursor()
        //    => SpriteBatch.Draw(MapSprites[CurrentLayer], new Vector2(
        //        MouseState.X - Utils.TILE_SIZE / 2,
        //        MouseState.Y - Utils.TILE_SIZE / 2
        //        ), Map.TileSets[CurrentLayer][CurrentIndex], Color.White);
    }
}
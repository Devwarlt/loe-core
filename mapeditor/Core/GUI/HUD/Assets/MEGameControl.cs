﻿using LoESoft.Dlls.MapEditor;
using LoESoft.MapEditor.Core.Assets;
using LoESoft.MapEditor.Core.GUI.HUD.Assets;
using LoESoft.MapEditor.Core.Layer;
using LoESoft.MapEditor.Core.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Forms.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Color = Microsoft.Xna.Framework.Color;

namespace LoESoft.MapEditor.Core.GUI.HUD
{
    public class MEGameControl : UpdateWindow
    {
        public static MapState MapState { get; set; }
        public static Vector2 ClientBounds { get; set; }
        public static bool Quit { get; set; }
        public static string ActualMapName { get; set; }
        public static MapSize ActualMapSize { get; set; }
        public static string CurrentFileName { get; set; }
        public static string LoadFileName { get; set; }
        public static Map Map { get; set; }
        public static bool ShowGrid { get; set; }
        public static bool ShowUndergroundLayer { get; set; }
        public static bool ShowGroundLayer { get; set; }
        public static bool ShowObjectLayer { get; set; }
        public static bool ShowSkyLayer { get; set; }
        public static Texture2D GridTexture { get; set; }
        public static InteractiveObject InteractiveObject { get; set; }
        public static Dictionary<string, List<InteractiveObject>> InteractiveObjects { get; set; }
        public static Dictionary<string, Texture2D> Textures { get; set; }
        public static Dictionary<string, Image> Images { get; set; }
        public static LoEMapper<Map> Mapper { get; set; }
        public static HUD HUD { get; set; }

        public static Vector2 DrawOffset = Vector2.Zero;

        private static MouseState MouseState { get; set; }

        protected LoECamera Camera { get; set; }

        protected override void Initialize()
        {
            MapState = MapState.Active;
            ClientBounds = new Vector2(608, 600);

            XmlLibrary.Init();

            Mapper = new LoEMapper<Map>("BRMEMaps", (message) => App.Warn(message));
            Mapper.CreateMainDirectory();

            InteractiveObjects = new Dictionary<string, List<InteractiveObject>>();
            Textures = new Dictionary<string, Texture2D>();
            Images = new Dictionary<string, Image>();

            foreach (var interactiveobject in XmlLibrary.AllXmls.Values.Where(content => content.LayerData != null))
            {
                var group = interactiveobject.LayerData.Group;

                if (!InteractiveObjects.ContainsKey(group))
                {
                    App.Info($"- Added group: '{group}'.");

                    InteractiveObjects.Add(group, new List<InteractiveObject>() { interactiveobject });
                }
                else
                    InteractiveObjects[group].Add(interactiveobject);
            }

            InteractiveObjects.Values.Select(interactiveobjects => interactiveobjects.OrderBy(interactiveobject => interactiveobject.Name)).ToList();

            var spritesheets = new Dictionary<string, string>();

            foreach (var interactiveobjects in InteractiveObjects.Values)
                foreach (var interactiveobject in interactiveobjects)
                {
                    var group = interactiveobject.LayerData.Group;

                    if (!spritesheets.ContainsKey(interactiveobject.LayerData.Group))
                        spritesheets.Add(interactiveobject.LayerData.Group, interactiveobject.TextureData.File);
                }

            foreach (var spritesheet in spritesheets)
            {
                Texture2D texture = null;
                Image image = null;

                try
                {
                    texture = Utils.LoadEmbeddedSpritesheetToTexture2D(GraphicsDevice, spritesheet.Value);
                    image = Utils.LoadEmbeddedSpritesheetToImage(spritesheet.Value);
                }
                catch { App.Warn($"Missing texture: {spritesheet.Value}.png"); }

                if (texture != null && image != null)
                {
                    App.Info($"- Added spritsheet '{spritesheet.Value}' to group '{spritesheet.Key}'.");

                    Textures.Add(spritesheet.Key, texture);
                    Images.Add(spritesheet.Key, image);
                }
            }

            App.Info("Creating a sample map...");

            Map = new Map(MapSize.SIZE_128);
            ShowUndergroundLayer = true;
            ShowGroundLayer = true;
            ShowObjectLayer = true;
            ShowSkyLayer = true;
            GridTexture = Utils.LoadEmbeddedTexture(GraphicsDevice, "sample-grid.png");
            InteractiveObject = null;
            HUD.UpdatePalleteComboBox(InteractiveObjects.Keys.OrderBy(group => group).ToArray());
            ActualMapName = "sample";
            ActualMapSize = MapSize.SIZE_128;

            App.Info($"- Name: {ActualMapName}");
            App.Info($"- Size: {(int)ActualMapSize} x {(int)ActualMapSize}");
            App.Info("Creating a sample map... OK!");

            App.Info("Game Map Editor is loading... OK!\n");

            base.Initialize();

            Editor.Content.RootDirectory = "Content";

            Editor.ShowFPS = true;
            
            
            Camera = new LoECamera(609, 600);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Quit)
                Environment.Exit(0);

            HUD.Update(Editor.GetFrameRate, InteractiveObject?.Name);

            MouseState = Mouse.GetState();

            float scrollValue = ((MouseState.ScrollWheelValue) / 1000f) + 1;

            if (scrollValue != Camera.Zoom && scrollValue >= 1)
                Camera.SetZoomToPosition(scrollValue, new Vector2(MouseState.X, MouseState.Y));
            else if (scrollValue < 1)
            {
                scrollValue = 1;
                Camera.Position = Vector2.Zero;
            }
            
            if (MapState == MapState.Active && InteractiveObject != null && InteractiveObjects != null)
                if (InteractiveObject.LayerData.Type != MapLayer.ABSTRACT && Focused)
                {
                    var vector = Camera.ScreenToWorld(new Vector2((MouseState.X) + DrawOffset.X, (MouseState.Y) + DrawOffset.Y));
                    var mx = vector.X / Utils.TILE_SIZE;
                    var my = vector.Y / Utils.TILE_SIZE;

                    if (MouseState.X < App.MapControl.Width && MouseState.X >= 0
                        && MouseState.Y < App.MapControl.Height && MouseState.Y >= 0)
                    {
                        if (MouseState.LeftButton == ButtonState.Pressed)
                        {
                            Map.Layers[(int)InteractiveObject.LayerData.Type].SetTiles(mx, my, new ChunkData()
                            {
                                ContentType = InteractiveObject.Type,
                                Id = InteractiveObject.Id,
                                Group = InteractiveObject.LayerData.Group,
                                BoundX = InteractiveObject.TextureData.X,
                                BoundY = InteractiveObject.TextureData.Y,
                                GridX = (int)mx,
                                GridY = (int)my,
                                Vector = new Vector2(((int)mx - DrawOffset.X) * Utils.TILE_SIZE, ((int)my - DrawOffset.Y) * Utils.TILE_SIZE)
                            });
                        }
                        else if (MouseState.RightButton == ButtonState.Pressed)
                            Map.Layers[(int)InteractiveObject.LayerData.Type].RemoveTiles(mx, my);
                    }
                }
            
            Map.Update();

            base.Update(gameTime);
        }

        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.DarkGreen);
            Editor.spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: Camera.GetViewMatrix());

            Map.Draw(Editor.spriteBatch);

            if (MapState == MapState.Active && InteractiveObject != null && InteractiveObjects != null)
                if (InteractiveObject.LayerData.Type != MapLayer.ABSTRACT)
                    DrawSpriteOnCursor();

            base.Draw();

            Editor.spriteBatch.End();
        }

        private void DrawSpriteOnCursor()
        {
            var vector = Camera.ScreenToWorld(new Vector2(
                MouseState.X - Utils.TILE_SIZE / 2,
                MouseState.Y - Utils.TILE_SIZE / 2
                ));
            Editor.spriteBatch.Draw(Textures[InteractiveObject.LayerData.Group], vector, Utils.JamesBounds(InteractiveObject.TextureData.X, InteractiveObject.TextureData.Y), Color.White);
        }
    }
}
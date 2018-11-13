using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;

namespace LoESoft.MapEditor.Core.Layer
{
    public class Layer
    {
        public const int TILE_SIZE = 16;

        public MapLayer MapLayer { get; set; }
        public ChunkData[,] Chunk { get; set; }

        private int _width { get; set; }
        private int _height { get; set; }

        public Layer(MapLayer layer, int width, int height)
        {
            _width = width;
            _height = height;

            MapLayer = layer;
            Chunk = new ChunkData[_width, _height];
        }

        public void SetTiles(MouseState mouse, ChunkData data)
        {
            Vector2 mouseposition;
            double mousemapx;
            double mousemapy;

            var leftbutton = mouse.LeftButton;
            var rightbutton = mouse.RightButton;

            try
            {
                if (leftbutton == ButtonState.Pressed)
                {
                    mouseposition = new Vector2(mouse.X, mouse.Y);
                    mousemapx = ((int)mouseposition.X / TILE_SIZE) + MapEditor.DrawOffset.X;
                    mousemapy = ((int)mouseposition.Y / TILE_SIZE) + MapEditor.DrawOffset.Y;

                    if (mouseposition.X < MapEditor.GraphicsDeviceManager.PreferredBackBufferWidth && mouseposition.X >= 0
                        && mouseposition.Y < MapEditor.GraphicsDeviceManager.PreferredBackBufferHeight && mouseposition.Y >= 0
                        && mousemapx < _width && mousemapx >= 0
                        && mousemapy < _height && mousemapy >= 0
                        && App.MapEditor.IsActive)
                        Chunk[(int)mousemapx, (int)mousemapy] = data;
                }

                if (rightbutton == ButtonState.Pressed)
                {
                    mouseposition = new Vector2(mouse.X, mouse.Y);
                    mousemapx = ((int)mouseposition.X / TILE_SIZE) + MapEditor.DrawOffset.X;
                    mousemapy = ((int)mouseposition.Y / TILE_SIZE) + MapEditor.DrawOffset.Y;

                    if (mouseposition.X < MapEditor.GraphicsDeviceManager.PreferredBackBufferWidth && mouseposition.X >= 0
                        && mouseposition.Y < MapEditor.GraphicsDeviceManager.PreferredBackBufferHeight && mouseposition.Y >= 0
                        && mousemapx < _width && mousemapx >= 0
                        && mousemapy < _height && mousemapy >= 0
                        && App.MapEditor.IsActive)
                        Chunk[(int)mousemapx, (int)mousemapy] = null;
                }
            }
            catch { }
        }

        public string Save()
        {
            try
            { return JsonConvert.SerializeObject(Chunk); }
            catch (Exception e) { MessageBox.Show($"Save: {e}"); }

            return null;
        }

        public void Load(string data)
        {
            try
            { Chunk = JsonConvert.DeserializeObject<ChunkData[,]>(data); }
            catch (Exception e) { MessageBox.Show($"Load: {e}"); }
        }
    }
}
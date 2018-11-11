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
        public const int MAP_TILE_LAYER = 0;
        public const int MAP_TILE_BORDER_LAYER = 1;
        public const int MAP_OBJECTS_LAYER = 2;
        public const int MAP_ENVIRONMENTS_LAYER = 3;
        public const int MAP_SOLID_LAYER = 4;

        public int Id { get; set; }
        public ChunkData[,] Chunk { get; set; }

        private int _width { get; set; }
        private int _height { get; set; }

        public Layer(int layer, int width, int height)
        {
            _width = width;
            _height = height;

            Id = layer;
            Chunk = new ChunkData[_width, _height];
        }

        public void SetTiles(ChunkData data)
        {
            Vector2 mouse;
            double mousemapx;
            double mousemapy;

            var currentmousestate = Mouse.GetState();
            var leftbutton = currentmousestate.LeftButton;
            var rightbutton = currentmousestate.RightButton;

            try
            {
                if (leftbutton == ButtonState.Pressed || leftbutton == ButtonState.Pressed)
                {
                    mouse = new Vector2(currentmousestate.X, currentmousestate.Y);
                    mousemapx = ((int)mouse.X / TILE_SIZE) + MapEditor.DrawOffset.X;
                    mousemapy = ((int)mouse.Y / TILE_SIZE) + MapEditor.DrawOffset.Y;

                    if (mousemapx < _width && mousemapy < _height && mousemapx >= 0 && mousemapy >= 0)
                        Chunk[(int)mousemapx, (int)mousemapy] = leftbutton == ButtonState.Pressed ? data : null;
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
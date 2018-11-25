using LoESoft.MapEditor.Core.GUI.HUD;
using LoESoft.MapEditor.Core.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;

namespace LoESoft.MapEditor.Core.Layer
{
    public class Layer
    {
        public MapLayer MapLayer { get; set; }
        public MapSize MapSize { get; set; }
        public ChunkData[,] Chunk { get; set; }

        public Layer(MapLayer layer, MapSize size)
        {
            MapLayer = layer;
            MapSize = size;
            Chunk = new ChunkData[(int)MapSize, (int)MapSize];
        }

        public void SetTiles(double mx, double my, ChunkData data)
        {
            double mousemapx = mx;
            double mousemapy = my;

            if (mousemapx < (int)MapSize && mousemapx >= 0 && mousemapy < (int)MapSize && mousemapy >= 0
                        && App.MapControl.Focused)
                Chunk[(int)mousemapx, (int)mousemapy] = data;
        }

        public void RemoveTiles(double mx, double my)
        {
            double mousemapx = mx;
            double mousemapy = my;
            
            if (mousemapx < (int)MapSize && mousemapx >= 0
                && mousemapy < (int)MapSize && mousemapy >= 0
                && App.MapControl.Focused)
                Chunk[(int)mousemapx, (int)mousemapy] = null;
        }
    }
}
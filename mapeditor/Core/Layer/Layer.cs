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
            var mousemapx = mx;
            var mousemapy = my;

            if (mousemapx < (int)MapSize && mousemapx >= 0 && mousemapy < (int)MapSize && mousemapy >= 0 && App.MapControl.Focused)
                Chunk[(int)mousemapx, (int)mousemapy] = data;
        }

        public void RemoveTiles(double mx, double my)
        {
            var mousemapx = mx;
            var mousemapy = my;

            if (mousemapx < (int)MapSize && mousemapx >= 0 && mousemapy < (int)MapSize && mousemapy >= 0 && App.MapControl.Focused)
                Chunk[(int)mousemapx, (int)mousemapy] = null;
        }
    }
}
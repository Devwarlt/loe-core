using System.Drawing;

namespace LoESoft.MapEditor.Core.Util
{
    public class SpriteItem
    {
        public int MaximumX { get; set; }
        public int MaximumY { get; set; }
        public int[,] Index { get; set; }
        public int ActualIndex { get; set; }
        public Image Image { get; set; }
    }
}
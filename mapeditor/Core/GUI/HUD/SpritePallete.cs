using LoESoft.MapEditor.Core.Layer;
using LoESoft.MapEditor.Core.Util;
using System.Windows.Forms;

namespace LoESoft.MapEditor.Core.GUI.HUD
{
    public partial class SpritePallete : UserControl
    {
        public SpriteItem SpriteItem { get; set; }

        public SpritePallete() => InitializeComponent();

        public void SetImage()
        {
            SpriteBox.Image = SpriteItem.Image;
            SpriteBox.SizeMode = PictureBoxSizeMode.StretchImage;
            SpriteBox.Refresh();
        }

        private void SpriteBox_Click(object sender, System.EventArgs e)
        {
            MapEditor.CurrentLayer = MapLayer.UNDERGROUND;
            MapEditor.CurrentIndex = SpriteItem.ActualIndex;
        }
    }
}
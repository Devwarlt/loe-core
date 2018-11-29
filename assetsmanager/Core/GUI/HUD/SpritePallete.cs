using System;
using System.Drawing;
using System.Windows.Forms;

namespace LoESoft.AssetsManager.Core.GUI.HUD
{
    public partial class SpritePallete : UserControl
    {
        public ItemControl ItemControl { get; set; }
        public Action Action { get; set; }

        public SpritePallete() => InitializeComponent();

        public void SetImage(Image image)
        {
            SpriteBox.Image = image;
            SpriteBox.SizeMode = PictureBoxSizeMode.StretchImage;
            SpriteBox.Refresh();
        }

        private void SpriteBox_Click(object sender, EventArgs e) => Action?.Invoke();
    }
}
using LoESoft.MapEditor.Core.Util;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LoESoft.MapEditor.Core.GUI.HUD
{
    public partial class SpritePallete : UserControl
    {
        public Image Image { get; set; }
        public InteractiveObject InteractiveObject { get; set; }

        public SpritePallete() => InitializeComponent();

        public void SetImage()
        {
            SpriteBox.Image = Image;
            SpriteBox.SizeMode = PictureBoxSizeMode.StretchImage;
            SpriteBox.Refresh();
        }

        private void SpriteBox_Click(object sender, EventArgs e) => MEGameControl.InteractiveObject = InteractiveObject;
    }
}
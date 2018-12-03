using System;
using System.Drawing;
using System.Windows.Forms;
using static LoESoft.AssetsManager.Core.Assets.Structure.XmlContent;

namespace LoESoft.AssetsManager.Core.GUI.HUD
{
    public partial class SpritePallete : UserControl
    {
        public string Origin { get; set; }
        public ContentType Type { get; set; }
        public int ParentId { get; set; }
        public int Id { get; set; }
        public ItemControl ItemControl { get; set; }
        public Action Action { get; set; }

        public Image Image
        {
            get => SpriteBox.Image;
            set
            {
                SpriteBox.Image = value;
                SpriteBox.SizeMode = PictureBoxSizeMode.StretchImage;
                SpriteBox.Refresh();
            }
        }

        public SpritePallete() => InitializeComponent();

        private void SpriteBox_Click(object sender, EventArgs e) => Action?.Invoke();
    }
}
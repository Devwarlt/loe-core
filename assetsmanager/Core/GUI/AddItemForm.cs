using LoESoft.AssetsManager.Core.Assets;
using System;
using System.Linq;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace LoESoft.AssetsManager.Core.GUI
{
    public partial class AddItemForm : Form
    {
        public Manager Manager { get; set; }

        private Timer _clock { get; set; }

        public AddItemForm()
        {
            InitializeComponent();

            _clock = new Timer(300) { AutoReset = true };
            _clock.Elapsed += delegate
            {
                try
                {
                    Invoke((MethodInvoker)delegate ()
                    {
                        var enable = (ObjectsButton.Checked || ItemsButton.Checked || TilesButton.Checked) && ItemXml.SelectedIndex != -1;

                        ItemId.Enabled = enable;
                        ItemName.Enabled = enable;
                        ItemFile.Enabled = enable;
                        ItemX.Enabled = enable;
                        ItemY.Enabled = enable;
                        ItemBlocked.Enabled = enable;
                        ItemWalkable.Enabled = enable;

                        var saveable = ItemId.Value >= 0 && ItemId.Value <= int.MaxValue && string.IsNullOrWhiteSpace(ItemName.Text) &&
                        ItemFile.SelectedIndex != -1 && ItemX.Value >= 0 && ItemX.Value <= int.MaxValue && ItemY.Value >= 0 &&
                        ItemY.Value <= int.MaxValue;

                        SaveButton.Enabled = saveable;
                        SaveButton.Image = saveable ? Properties.Resources.hud_check : Properties.Resources.hud_check_inactive;
                    });
                }
                catch { }
            };
        }

        private void AddItemForm_Load(object sender, EventArgs e)
        {
            ItemXml.Items.AddRange(XmlLibrary.Xmls.Keys.OrderBy(name => name).ToArray());
            ItemXml.SelectedIndex = -1;
            ItemFile.Items.AddRange(Manager.Spritesheets.Keys.OrderBy(name => name).ToArray());
            ItemFile.SelectedIndex = -1;
            ItemX.Minimum = ItemX.Maximum = 0;
            ItemY.Minimum = ItemY.Maximum = 0;
        }

        private void ItemFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            var spritesheet = Manager.Spritesheets[(string)ItemFile.SelectedItem];
            ItemX.Maximum = spritesheet.Width;
            ItemX.Value = 0;
            ItemY.Maximum = spritesheet.Height;
            ItemY.Value = 0;
            ItemSprite.Image = spritesheet.Image[0, 0];
        }

        private void ItemX_ValueChanged(object sender, EventArgs e) => UpdateSprite();

        private void ItemY_ValueChanged(object sender, EventArgs e) => UpdateSprite();

        private void UpdateSprite() => ItemSprite.Image = Manager.Spritesheets[(string)ItemFile.SelectedItem].Image[(int)ItemX.Value, (int)ItemY.Value];
    }
}
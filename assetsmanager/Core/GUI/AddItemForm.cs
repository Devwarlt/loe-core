using LoESoft.AssetsManager.Core.Assets;
using LoESoft.AssetsManager.Core.Assets.Structure;
using LoESoft.AssetsManager.Core.Assets.Structure.Exclusive;
using System;
using System.Linq;
using System.Windows.Forms;
using static LoESoft.AssetsManager.Core.Assets.Structure.Exclusive.LayerData;
using static LoESoft.AssetsManager.Core.Assets.Structure.XmlContent;
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

            ItemBlocked.Enabled = false;
            ItemWalkable.Enabled = false;

            _clock = new Timer(300) { AutoReset = true };
            _clock.Elapsed += delegate
            {
                try
                {
                    Invoke((MethodInvoker)delegate ()
                    {
                        var enable = ItemXml.SelectedIndex != -1;

                        ObjectsButton.Enabled = enable;
                        ItemsButton.Enabled = enable;
                        TilesButton.Enabled = enable;
                        ItemId.Enabled = enable;
                        ItemName.Enabled = enable;
                        ItemFile.Enabled = enable;
                        ItemX.Enabled = enable;
                        ItemY.Enabled = enable;
                        ItemSprite.Enabled = enable;

                        var saveable = ItemId.Value >= 0 && ItemId.Value <= int.MaxValue && !string.IsNullOrWhiteSpace(ItemName.Text) &&
                        ItemFile.SelectedIndex != -1 && ItemX.Value >= 0 && ItemX.Value <= int.MaxValue && ItemY.Value >= 0 &&
                        ItemY.Value <= int.MaxValue;

                        if ((ObjectsButton.Checked || TilesButton.Checked) && saveable)
                            saveable = (UndergroundButton.Checked || GroundButton.Checked || ObjectButton.Checked || SkyButton.Checked)
                            && !string.IsNullOrWhiteSpace(ItemGroup.Text);

                        SaveButton.Enabled = saveable;
                        SaveButton.Image = saveable ? Properties.Resources.hud_check : Properties.Resources.hud_check_inactive;
                    });
                }
                catch { }
            };
        }

        private void AddItemForm_Load(object sender, EventArgs e)
        {
            _clock.Start();

            ItemXml.Items.AddRange(XmlLibrary.Xmls.Keys.OrderBy(name => name).ToArray());
            ItemXml.SelectedIndex = -1;
            ItemFile.Items.AddRange(Manager.Spritesheets.Keys.OrderBy(name => name).ToArray());
            ItemFile.SelectedIndex = -1;
            ItemX.Minimum = ItemX.Maximum = 0;
            ItemY.Minimum = ItemY.Maximum = 0;
        }

        private void ObjectsButton_CheckedChanged(object sender, EventArgs e)
        {
            UndergroundButton.Enabled = true;
            UndergroundButton.Checked = false;
            GroundButton.Enabled = true;
            GroundButton.Checked = false;
            ObjectButton.Enabled = true;
            ObjectButton.Checked = false;
            SkyButton.Enabled = true;
            SkyButton.Checked = false;
            ItemGroup.Enabled = true;
            ItemGroup.Text = string.Empty;
            ItemAnimated.Enabled = true;
            ItemAnimated.Checked = false;
            ItemBlocked.Enabled = true;
            ItemBlocked.Checked = false;
            ItemWalkable.Enabled = false;
            ItemWalkable.Checked = false;
        }

        private void ItemsButton_CheckedChanged(object sender, EventArgs e)
        {
            UndergroundButton.Enabled = false;
            UndergroundButton.Checked = false;
            GroundButton.Enabled = false;
            GroundButton.Checked = false;
            ObjectButton.Enabled = false;
            ObjectButton.Checked = false;
            SkyButton.Enabled = false;
            SkyButton.Checked = false;
            ItemGroup.Enabled = false;
            ItemGroup.Text = string.Empty;
            ItemAnimated.Enabled = false;
            ItemAnimated.Checked = false;
            ItemBlocked.Enabled = false;
            ItemBlocked.Checked = false;
            ItemWalkable.Enabled = false;
            ItemWalkable.Checked = false;
        }

        private void TilesButton_CheckedChanged(object sender, EventArgs e)
        {
            UndergroundButton.Enabled = true;
            UndergroundButton.Checked = false;
            GroundButton.Enabled = true;
            GroundButton.Checked = false;
            ObjectButton.Enabled = true;
            ObjectButton.Checked = false;
            SkyButton.Enabled = true;
            SkyButton.Checked = false;
            ItemGroup.Enabled = true;
            ItemGroup.Text = string.Empty;
            ItemAnimated.Enabled = false;
            ItemAnimated.Checked = false;
            ItemBlocked.Enabled = false;
            ItemBlocked.Checked = false;
            ItemWalkable.Enabled = true;
            ItemWalkable.Checked = false;
        }

        private void ItemFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            var spritesheet = Manager.Spritesheets[(string)ItemFile.SelectedItem];
            ItemX.Maximum = spritesheet.Width;
            ItemX.Value = 0;
            ItemY.Maximum = spritesheet.Height;
            ItemY.Value = 0;

            ItemSpriteUpdate();
        }

        private void ItemX_ValueChanged(object sender, EventArgs e) => ItemSpriteUpdate();

        private void ItemY_ValueChanged(object sender, EventArgs e) => ItemSpriteUpdate();

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var type = default(ContentType);

            if (ObjectsButton.Checked)
                type = ContentType.Objects;

            if (ItemsButton.Checked)
                type = ContentType.Items;

            if (TilesButton.Checked)
                type = ContentType.Tiles;

            var id = (int)ItemId.Value;
            var name = ItemName.Text;
            var maptype = default(MapLayer);

            if (UndergroundButton.Checked)
                maptype = MapLayer.UNDERGROUND;

            if (GroundButton.Checked)
                maptype = MapLayer.GROUND;

            if (ObjectButton.Checked)
                maptype = MapLayer.OBJECT;

            if (SkyButton.Checked)
                maptype = MapLayer.SKY;

            var layerdata = new LayerData()
            {
                Type = maptype,
                Group = ItemGroup.Text
            };
            var texturedata = new TextureData()
            {
                File = (string)ItemFile.SelectedItem,
                X = (int)ItemX.Value,
                Y = (int)ItemY.Value,
                Animated = ItemAnimated.Checked
            };
            var blocked = ItemBlocked.Checked;
            var walkable = ItemWalkable.Checked;

            ObjectsContent sampleobject = null;
            ItemsContent sampleitem = null;
            TilesContent sampletile = null;

            foreach (var samples in Manager.XmlObjects.Values.Select(values => values).ToList())
                foreach (var sample in samples)
                    if (sample.Id == id)
                    {
                        sampleobject = sample;
                        break;
                    }

            foreach (var samples in Manager.XmlItems.Values.Select(values => values).ToList())
                foreach (var sample in samples)
                    if (sample.Id == id)
                    {
                        sampleitem = sample;
                        break;
                    }

            foreach (var samples in Manager.XmlTiles.Values.Select(values => values).ToList())
                foreach (var sample in samples)
                    if (sample.Id == id)
                    {
                        sampletile = sample;
                        break;
                    }

            if (sampleobject != null)
            {
                MessageBox.Show($"Object '{sampleobject.Name}' has same ID '{sampleobject.Id}', consider to change.", "Error!");
                return;
            }

            if (sampleitem != null)
            {
                MessageBox.Show($"Item '{sampleitem.Name}' has same ID '{sampleitem.Id}', consider to change.", "Error!");
                return;
            }

            if (sampletile != null)
            {
                MessageBox.Show($"Tile '{sampletile.Name}' has same ID '{sampletile.Id}', consider to change.", "Error!");
                return;
            }

            switch (type)
            {
                case ContentType.Objects:
                    Manager.XmlObjects[(string)ItemXml.SelectedItem].Add(new ObjectsContent()
                    {
                        Type = type,
                        Id = id,
                        Name = name,
                        LayerData = layerdata,
                        TextureData = texturedata,
                        Blocked = blocked
                    });
                    break;

                case ContentType.Items:
                    Manager.XmlItems[(string)ItemXml.SelectedItem].Add(new ItemsContent()
                    {
                        Type = type,
                        Id = id,
                        Name = name,
                        TextureData = texturedata
                    });
                    break;

                case ContentType.Tiles:
                    Manager.XmlTiles[(string)ItemXml.SelectedItem].Add(new TilesContent()
                    {
                        Type = type,
                        Id = id,
                        Name = name,
                        LayerData = layerdata,
                        TextureData = texturedata,
                        Walkable = walkable
                    });
                    break;
            }

            Manager.RefreshXmls();

            DialogResult = DialogResult.OK;
        }

        private void ItemSpriteUpdate()
        {
            ItemSprite.Action = () => Invoke((MethodInvoker)delegate ()
            {
                var spritesheetform = new SpritesheetForm() { File = (string)ItemFile.SelectedItem };
                spritesheetform.ShowDialog();

                if (spritesheetform.DialogResult == DialogResult.OK)
                {
                    ItemX.Value = spritesheetform.X;
                    ItemY.Value = spritesheetform.Y;
                    ItemSprite.Image = spritesheetform.Image;
                }
            });
            ItemSprite.Image = Manager.Spritesheets[(string)ItemFile.SelectedItem].Image[(int)ItemX.Value, (int)ItemY.Value];
        }
    }
}
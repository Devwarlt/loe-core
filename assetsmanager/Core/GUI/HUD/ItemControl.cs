using LoESoft.AssetsManager.Core.Assets.Structure;
using LoESoft.AssetsManager.Core.Assets.Structure.Exclusive;
using System;
using System.Linq;
using System.Windows.Forms;
using static LoESoft.AssetsManager.Core.Assets.Structure.XmlContent;
using Timer = System.Timers.Timer;

namespace LoESoft.AssetsManager.Core.GUI.HUD
{
    public partial class ItemControl : UserControl
    {
        private ControlState _state { get; set; }
        private Timer _clock { get; set; }
        private SpritePallete _spritePallete { get; set; }
        private string _origin { get; set; }
        private ContentType[] _type { get; set; }
        private int[] _id { get; set; }
        private string[] _name { get; set; }
        private string[] _file { get; set; }
        private int[] _x { get; set; }
        private int[] _y { get; set; }
        private bool[] _blocked { get; set; }
        private bool[] _walkable { get; set; }

        public ItemControl(SpritePallete spritePallete, string origin, ObjectsContent objectsContent)
            : this(spritePallete, origin, ContentType.Objects, objectsContent.Id, objectsContent.Name,
                  objectsContent.TextureData.File, objectsContent.TextureData.X, objectsContent.TextureData.Y, objectsContent.Blocked, false)
        {
        }

        public ItemControl(SpritePallete spritePallete, string origin, ItemsContent itemsContent)
            : this(spritePallete, origin, ContentType.Items, itemsContent.Id, itemsContent.Name,
                  itemsContent.TextureData.File, itemsContent.TextureData.X, itemsContent.TextureData.Y, false, false)
        {
        }

        public ItemControl(SpritePallete spritePallete, string origin, TilesContent tilesContent)
            : this(spritePallete, origin, ContentType.Tiles, tilesContent.Id, tilesContent.Name,
                  tilesContent.TextureData.File, tilesContent.TextureData.X, tilesContent.TextureData.Y, false, tilesContent.Walkable)
        {
        }

        private ItemControl(SpritePallete spritePallete, string origin, ContentType type, int id, string name,
            string file, int x, int y, bool blocked, bool walkable)
        {
            _state = ControlState.Normal;
            _spritePallete = spritePallete;
            _origin = origin;
            _type = new ContentType[] { type, type };
            _id = new int[] { id, id };
            _name = new string[] { name, name };
            _file = new string[] { file, file };
            _x = new int[] { x, x };
            _y = new int[] { y, y };
            _blocked = new bool[] { blocked, blocked };
            _walkable = new bool[] { walkable, walkable };

            InitializeComponent();

            switch (_type[0])
            {
                case ContentType.Objects:
                    {
                        ObjectsButton.Checked = true;
                        ItemBlocked.Enabled = true;
                    }
                    break;

                case ContentType.Items: ItemsButton.Checked = true; break;
                case ContentType.Tiles:
                    {
                        TilesButton.Checked = true;
                        ItemWalkable.Enabled = true;
                    }
                    break;
            }

            ItemId.Value = id;
            ItemName.Text = name;
            ItemFile.Items.AddRange(Manager.Spritesheets.Keys.Select(key => key).ToArray());
            ItemFile.SelectedItem = file;
            ItemX.Minimum = 0;
            ItemX.Maximum = Manager.Spritesheets[file].Width - 1;
            ItemX.Value = x;
            ItemY.Minimum = 0;
            ItemY.Maximum = Manager.Spritesheets[file].Height - 1;
            ItemY.Value = y;
            ItemSprite.Action = () => Invoke((MethodInvoker)delegate ()
            {
                _state = ControlState.Updating;

                var spritesheetform = new SpritesheetForm() { File = file };
                spritesheetform.ShowDialog();

                if (spritesheetform.DialogResult == DialogResult.OK)
                {
                    _x[1] = spritesheetform.X;
                    _y[1] = spritesheetform.Y;
                    ItemSprite.SetImage(spritesheetform.Image);
                }

                ItemX.Value = _x[1];
                ItemY.Value = _y[1];

                _state = ControlState.Normal;
            });
            ItemSprite.SetImage(Manager.Spritesheets[file].Image[_x[1], _y[1]]);
            ItemBlocked.Checked = blocked;
            ItemWalkable.Checked = walkable;

            LostFocus += ItemControl_LostFocus;

            _clock = new Timer(300) { AutoReset = true };
            _clock.Elapsed += delegate
            {
                try
                {
                    Invoke((MethodInvoker)delegate ()
                    {
                        var changes = _type[0] != _type[1] || _id[0] != _id[1] || _name[0] != _name[1]
                        || _file[0] != _file[1] || _x[0] != _x[1] || _y[0] != _y[1] || _blocked[0] != _blocked[1]
                        || _walkable[0] != _walkable[1];

                        if (changes)
                        {
                            DefaultButton.Enabled = true;
                            DefaultButton.Image = Properties.Resources.hud_cross;
                            SaveButton.Enabled = true;
                            SaveButton.Image = Properties.Resources.hud_check;
                        }
                        else
                        {
                            DefaultButton.Enabled = false;
                            DefaultButton.Image = Properties.Resources.hud_cross_inactive;
                            SaveButton.Enabled = false;
                            SaveButton.Image = Properties.Resources.hud_check_inactive;
                        }
                    });
                }
                catch { }
            };
        }

        private void ItemControl_LostFocus(object sender, EventArgs e)
        {
            if (_state == ControlState.Normal)
            {
                ItemId.Value = _id[0];
                ItemName.Text = _name[0];
                ItemFile.SelectedItem = _file[0];
                ItemX.Value = _x[0];
                ItemY.Value = _y[0];
                ItemSprite.SetImage(Manager.Spritesheets[_file[0]].Image[_x[0], _y[0]]);
                ItemBlocked.Checked = _blocked[0];
                ItemWalkable.Checked = _walkable[0];
            }
        }

        private void ItemControl_Load(object sender, EventArgs e) => _clock.Start();

        private void DefaultButton_Click(object sender, EventArgs e)
        {
            var box = MessageBox.Show("Do you want to restore to default values?", "Default", MessageBoxButtons.YesNo);

            _state = ControlState.Updating;

            if (box == DialogResult.Yes)
            {
                _state = ControlState.Normal;

                ItemControl_LostFocus(sender, e);
            }
            else
                _state = ControlState.Normal;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            ObjectsContent sampleobject = null;
            ItemsContent sampleitem = null;
            TilesContent sampletile = null;

            foreach (var samples in Manager.XmlObjects.Values.Select(values => values).ToList())
                foreach (var sample in samples)
                    if (sample.Id == _id[1])
                    {
                        sampleobject = sample;
                        break;
                    }

            foreach (var samples in Manager.XmlItems.Values.Select(values => values).ToList())
                foreach (var sample in samples)
                    if (sample.Id == _id[1])
                    {
                        sampleitem = sample;
                        break;
                    }

            foreach (var samples in Manager.XmlTiles.Values.Select(values => values).ToList())
                foreach (var sample in samples)
                    if (sample.Id == _id[1])
                    {
                        sampletile = sample;
                        break;
                    }

            if (_id[1] <= 0 || _id[1] >= int.MaxValue)
            {
                MessageBox.Show("Invalid ID, consider to change.", "Error!");
                return;
            }

            if (string.IsNullOrEmpty(_name[1]))
            {
                MessageBox.Show("Name must be not null or empty, consider to change.", "Error!");
                return;
            }

            if (string.IsNullOrEmpty(_file[1]))
            {
                MessageBox.Show("Invalid File, consider to change.", "Error!");
                return;
            }

            if (_x[1] <= 0 || _x[1] >= int.MaxValue)
            {
                MessageBox.Show("Invalid X coordinate, consider to change.", "Error!");
                return;
            }

            if (_y[1] <= 0 || _y[1] >= int.MaxValue)
            {
                MessageBox.Show("Invalid Y coordinate, consider to change.", "Error!");
                return;
            }

            if (sampleobject != null)
            {
                if (sampleobject.Name != _name[1])
                {
                    MessageBox.Show($"Object '{sampleobject.Name}' has same ID '{sampleobject.Id}', consider to change.", "Error!");
                    return;
                }
            }

            if (sampleitem != null)
            {
                if (sampleitem.Name != _name[1])
                {
                    MessageBox.Show($"Item '{sampleitem.Name}' has same ID '{sampleitem.Id}', consider to change.", "Error!");
                    return;
                }
            }

            if (sampletile != null)
            {
                if (sampletile.Name != _name[1])
                {
                    MessageBox.Show($"Tile '{sampletile.Name}' has same ID '{sampletile.Id}', consider to change.", "Error!");
                    return;
                }
            }

            var texturedata = new TextureData()
            {
                File = _file[1],
                X = _x[1],
                Y = _y[1]
            };

            switch (_type[0])
            {
                case ContentType.Objects:
                    {
                        var xmlobject = Manager.XmlObjects[_origin].FirstOrDefault(sample => sample.Id == _id[0]);

                        switch (_type[1])
                        {
                            case ContentType.Objects:
                                {
                                    xmlobject.Id = _id[1];
                                    xmlobject.Name = _name[1];
                                    xmlobject.Blocked = _blocked[1];
                                }
                                return;

                            case ContentType.Items:
                                Manager.XmlItems[_origin].Add(new ItemsContent()
                                {
                                    Type = _type[1],
                                    Id = _id[1],
                                    Name = _name[1],
                                    TextureData = texturedata
                                });
                                break;

                            case ContentType.Tiles:
                                Manager.XmlTiles[_origin].Add(new TilesContent()
                                {
                                    Type = _type[1],
                                    Id = _id[1],
                                    Name = _name[1],
                                    TextureData = texturedata,
                                    Walkable = _walkable[1],
                                });
                                break;
                        }

                        Manager.XmlObjects[_origin].Remove(xmlobject);
                    }
                    break;

                case ContentType.Items:
                    {
                        var xmlitem = Manager.XmlItems[_origin].FirstOrDefault(sample => sample.Id == _id[0]);

                        switch (_type[1])
                        {
                            case ContentType.Objects:
                                Manager.XmlObjects[_origin].Add(new ObjectsContent()
                                {
                                    Type = _type[1],
                                    Id = _id[1],
                                    Name = _name[1],
                                    TextureData = texturedata,
                                    Blocked = _blocked[1]
                                });
                                break;

                            case ContentType.Items:
                                {
                                    xmlitem.Id = _id[1];
                                    xmlitem.Name = _name[1];
                                }
                                return;

                            case ContentType.Tiles:
                                Manager.XmlTiles[_origin].Add(new TilesContent()
                                {
                                    Type = _type[1],
                                    Id = _id[1],
                                    Name = _name[1],
                                    TextureData = texturedata,
                                    Walkable = _walkable[1]
                                });
                                break;
                        }

                        Manager.XmlItems[_origin].Remove(xmlitem);
                    }
                    break;

                case ContentType.Tiles:
                    {
                        var xmltile = Manager.XmlTiles[_origin].FirstOrDefault(sample => sample.Id == _id[0]);

                        switch (_type[1])
                        {
                            case ContentType.Objects:
                                Manager.XmlObjects[_origin].Add(new ObjectsContent()
                                {
                                    Type = _type[1],
                                    Id = _id[1],
                                    Name = _name[1],
                                    TextureData = texturedata,
                                    Blocked = _blocked[1]
                                });
                                break;

                            case ContentType.Items:
                                Manager.XmlItems[_origin].Add(new ItemsContent()
                                {
                                    Type = _type[1],
                                    Id = _id[1],
                                    Name = _name[1],
                                    TextureData = texturedata
                                });
                                break;

                            case ContentType.Tiles:
                                {
                                    xmltile.Id = _id[1];
                                    xmltile.Name = _name[1];
                                    xmltile.Walkable = _walkable[1];
                                }
                                return;
                        }

                        Manager.XmlTiles[_origin].Remove(xmltile);
                    }
                    break;
            }

            _type[0] = _type[1];
            _id[0] = _id[1];
            _name[0] = _name[1];
            _blocked[0] = _blocked[1];
            _walkable[0] = _walkable[1];
            _spritePallete.ItemControl = this;

            MessageBox.Show("You have been saved your progress!", "Success!");
        }

        private void ObjectsButton_CheckedChanged(object sender, EventArgs e)
        {
            _type[1] = ContentType.Objects;

            ItemBlocked.Enabled = true;
            ItemWalkable.Enabled = false;
        }

        private void ItemsButton_CheckedChanged(object sender, EventArgs e)
        {
            _type[1] = ContentType.Items;

            ItemBlocked.Enabled = false;
            ItemWalkable.Enabled = false;
        }

        private void TilesButton_CheckedChanged(object sender, EventArgs e)
        {
            _type[1] = ContentType.Tiles;

            ItemBlocked.Enabled = false;
            ItemWalkable.Enabled = true;
        }

        private void ItemId_ValueChanged(object sender, EventArgs e) => _id[1] = (int)ItemId.Value;

        private void ItemName_TextChanged(object sender, EventArgs e) => _name[1] = ItemName.Text;

        private void ItemFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            _file[1] = (string)ItemFile.SelectedItem;
            _x[1] = 0;
            _y[1] = 0;

            ItemX.Minimum = 0;
            ItemX.Maximum = Manager.Spritesheets[_file[1]].Width - 1;
            ItemX.Value = 0;
            ItemY.Minimum = 0;
            ItemY.Maximum = Manager.Spritesheets[_file[1]].Height - 1;
            ItemY.Value = 0;

            ItemSpriteUpdate();
        }

        private void ItemX_ValueChanged(object sender, EventArgs e)
        {
            _x[1] = (int)ItemX.Value;

            ItemSpriteUpdate();
        }

        private void ItemY_ValueChanged(object sender, EventArgs e)
        {
            _y[1] = (int)ItemY.Value;

            ItemSpriteUpdate();
        }

        private void ItemBlocked_CheckedChanged(object sender, EventArgs e) => _blocked[1] = ItemBlocked.Checked;

        private void ItemWalkable_CheckedChanged(object sender, EventArgs e) => _walkable[1] = ItemWalkable.Checked;

        private void ItemSpriteUpdate()
        {
            ItemSprite.Action = () => Invoke((MethodInvoker)delegate ()
            {
                _state = ControlState.Updating;

                var spritesheetform = new SpritesheetForm() { File = _file[1] };
                spritesheetform.ShowDialog();

                if (spritesheetform.DialogResult == DialogResult.OK)
                {
                    _x[1] = spritesheetform.X;
                    _y[1] = spritesheetform.Y;
                    ItemSprite.SetImage(spritesheetform.Image);
                }

                ItemX.Value = _x[1];
                ItemY.Value = _y[1];

                _state = ControlState.Normal;
            });
            ItemSprite.SetImage(Manager.Spritesheets[_file[1]].Image[_x[1], _y[1]]);
        }

        private void DefaultIcon_Click(object sender, EventArgs e)
        {
        }
    }
}
using LoESoft.AssetsManager.Core.Assets.Structure;
using LoESoft.AssetsManager.Core.Assets.Structure.Exclusive;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static LoESoft.AssetsManager.Core.Assets.Structure.Exclusive.LayerData;
using static LoESoft.AssetsManager.Core.Assets.Structure.XmlContent;
using Timer = System.Timers.Timer;

namespace LoESoft.AssetsManager.Core.GUI.HUD
{
    public partial class ItemControl : UserControl
    {
        public ObjectsContent ObjectsContent { get; }
        public ItemsContent ItemsContent { get; }
        public TilesContent TilesContent { get; }

        private ControlState _state { get; set; }
        private Timer _clock { get; set; }
        private SpritePallete _spritePallete { get; set; }
        private int _uid { get; set; }
        private string _origin { get; set; }
        private ContentType[] _type { get; set; }
        private MapLayer[] _layer { get; set; }
        private string[] _group { get; set; }
        private int[] _id { get; set; }
        private string[] _name { get; set; }
        private string[] _file { get; set; }
        private int[] _x { get; set; }
        private int[] _y { get; set; }
        private bool[] _animated { get; set; }
        private bool[] _blocked { get; set; }
        private bool[] _walkable { get; set; }

        public ItemControl(SpritePallete spritePallete, string origin, ObjectsContent objectsContent)
            : this(spritePallete, origin, objectsContent.Uid, ContentType.Objects, objectsContent.LayerData?.Type ?? MapLayer.ABSTRACT,
                  objectsContent.LayerData?.Group ?? string.Empty, objectsContent.Id, objectsContent.Name,
                  objectsContent.TextureData.File, objectsContent.TextureData.X, objectsContent.TextureData.Y,
                  objectsContent.TextureData?.Animated ?? false, objectsContent.Blocked, false)
            => ObjectsContent = objectsContent;

        public ItemControl(SpritePallete spritePallete, string origin, ItemsContent itemsContent)
            : this(spritePallete, origin, itemsContent.Uid, ContentType.Items, MapLayer.ABSTRACT,
                  string.Empty, itemsContent.Id, itemsContent.Name,
                  itemsContent.TextureData.File, itemsContent.TextureData.X, itemsContent.TextureData.Y,
                  false, false, false)
            => ItemsContent = ItemsContent;

        public ItemControl(SpritePallete spritePallete, string origin, TilesContent tilesContent)
            : this(spritePallete, origin, tilesContent.Uid, ContentType.Tiles, tilesContent.LayerData?.Type ?? MapLayer.ABSTRACT,
                  tilesContent.LayerData?.Group ?? string.Empty, tilesContent.Id, tilesContent.Name,
                  tilesContent.TextureData.File, tilesContent.TextureData.X, tilesContent.TextureData.Y,
                  false, false, tilesContent.Walkable)
            => TilesContent = tilesContent;

        private ItemControl(SpritePallete spritePallete, string origin, int uid, ContentType type, MapLayer layer, string group, int id, string name,
            string file, int x, int y, bool animated, bool blocked, bool walkable)
        {
            _state = ControlState.Normal;
            _spritePallete = spritePallete;
            _uid = uid;
            _origin = origin;
            _type = new ContentType[] { type, type };
            _layer = new MapLayer[] { layer, layer };
            _group = new string[] { group, group };
            _id = new int[] { id, id };
            _name = new string[] { name, name };
            _file = new string[] { file, file };
            _x = new int[] { x, x };
            _y = new int[] { y, y };
            _animated = new bool[] { animated, animated };
            _blocked = new bool[] { blocked, blocked };
            _walkable = new bool[] { walkable, walkable };

            InitializeComponent();

            switch (type)
            {
                case ContentType.Objects:
                    {
                        ObjectsButton.Checked = true;
                        ItemAnimated.Enabled = true;
                        ItemAnimated.Checked = animated;
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

            switch (layer)
            {
                case MapLayer.UNDERGROUND: UndergroundButton.Checked = true; break;
                case MapLayer.GROUND: GroundButton.Checked = true; break;
                case MapLayer.OBJECT: ObjectButton.Checked = true; break;
                case MapLayer.SKY: SkyButton.Checked = true; break;
                default: break;
            }

            if (layer != MapLayer.ABSTRACT)
                ItemGroup.Text = group;
            else
                ItemGroup.Enabled = false;

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
                    ItemSprite.Image = spritesheetform.Image;
                }

                ItemX.Value = _x[1];
                ItemY.Value = _y[1];

                _state = ControlState.Normal;
            });
            ItemSprite.Image = Manager.Spritesheets[file].Image[x, y];
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
                        if ((UndergroundButton.Checked || GroundButton.Checked || ObjectButton.Checked || SkyButton.Checked) && !ItemGroup.Enabled)
                        {
                            ItemGroup.Enabled = true;
                            ItemGroup.Text = string.Empty;
                        }

                        var changes = _type[0] != _type[1] || _layer[0] != _layer[1] || _group[0] != _group[1] ||
                        _id[0] != _id[1] || _name[0] != _name[1] || _file[0] != _file[1] || _x[0] != _x[1] ||
                        _y[0] != _y[1] || _animated[0] != _animated[1] || _blocked[0] != _blocked[1] ||
                        _walkable[0] != _walkable[1];

                        DefaultButton.Enabled = changes;
                        DefaultButton.Image = changes ? Properties.Resources.hud_cross : Properties.Resources.hud_cross_inactive;

                        if (changes)
                            changes = _id[1] >= 0 && _id[1] <= int.MaxValue && !string.IsNullOrWhiteSpace(_name[1]) &&
                            ItemFile.SelectedIndex != -1 && _x[1] >= 0 && _x[1] <= int.MaxValue && _y[1] >= 0 &&
                            _y[1] <= int.MaxValue;

                        SaveButton.Enabled = changes;
                        SaveButton.Image = changes ? Properties.Resources.hud_check : Properties.Resources.hud_check_inactive;
                    });
                }
                catch { }
            };
        }

        private void ItemControl_LostFocus(object sender, EventArgs e)
        {
            if (_state == ControlState.Normal)
            {
                ObjectsButton.Checked = false;
                ItemsButton.Checked = false;
                TilesButton.Checked = false;

                switch (_type[0])
                {
                    case ContentType.Objects:
                        {
                            ObjectsButton.Checked = true;
                            ItemAnimated.Enabled = true;
                            ItemAnimated.Checked = _animated[0];
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

                UndergroundButton.Checked = false;
                GroundButton.Checked = false;
                ObjectButton.Checked = false;
                SkyButton.Checked = false;

                switch (_layer[0])
                {
                    case MapLayer.UNDERGROUND: UndergroundButton.Checked = true; break;
                    case MapLayer.GROUND: GroundButton.Checked = true; break;
                    case MapLayer.OBJECT: ObjectButton.Checked = true; break;
                    case MapLayer.SKY: SkyButton.Checked = true; break;
                    default: break;
                }

                if (_layer[0] != MapLayer.ABSTRACT)
                    ItemGroup.Text = _group[0];
                else
                    ItemGroup.Enabled = false;

                ItemId.Value = _id[0];
                ItemName.Text = _name[0];
                ItemFile.SelectedItem = _file[0];
                ItemX.Value = _x[0];
                ItemY.Value = _y[0];
                ItemSprite.Image = Manager.Spritesheets[_file[0]].Image[_x[0], _y[0]];
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
            var type = _type[1];
            var group = _group[1];
            var id = _id[1];
            var name = _name[1];
            var layerdata = new LayerData()
            {
                Type = _layer[1],
                Group = _group[1]
            };
            var texturedata = new TextureData()
            {
                File = _file[1],
                X = _x[1],
                Y = _y[1],
                Animated = _animated[1]
            };
            var blocked = _blocked[1];
            var walkable = _walkable[1];

            ObjectsContent sampleobject = null;
            ItemsContent sampleitem = null;
            TilesContent sampletile = null;

            foreach (var samples in Manager.XmlObjects.Values.Select(values => values).ToList())
                foreach (var sample in samples)
                    if (sample.Id == id && sample.Uid != _uid)
                    {
                        sampleobject = sample;
                        break;
                    }

            foreach (var samples in Manager.XmlItems.Values.Select(values => values).ToList())
                foreach (var sample in samples)
                    if (sample.Id == id && sample.Uid != _uid)
                    {
                        sampleitem = sample;
                        break;
                    }

            foreach (var samples in Manager.XmlTiles.Values.Select(values => values).ToList())
                foreach (var sample in samples)
                    if (sample.Id == id && sample.Uid != _uid)
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

            switch (_type[0])
            {
                case ContentType.Objects:
                    {
                        var xmlobject = Manager.XmlObjects[_origin].FirstOrDefault(sample => sample.Id == id);

                        switch (type)
                        {
                            case ContentType.Objects:
                                {
                                    xmlobject.Id = id;
                                    xmlobject.Name = name;

                                    if (layerdata.Type != MapLayer.ABSTRACT)
                                        xmlobject.LayerData = layerdata;

                                    xmlobject.TextureData = texturedata;
                                    xmlobject.Blocked = blocked;
                                }
                                break;

                            case ContentType.Items:
                                Manager.XmlItems[_origin].Add(new ItemsContent()
                                {
                                    Type = type,
                                    Id = id,
                                    Name = name,
                                    TextureData = texturedata
                                });
                                break;

                            case ContentType.Tiles:
                                {
                                    var xmltile = new TilesContent()
                                    {
                                        Type = type,
                                        Id = id,
                                        Name = name,
                                        TextureData = texturedata,
                                        Walkable = walkable,
                                    };

                                    if (layerdata.Type != MapLayer.ABSTRACT)
                                        xmltile.LayerData = layerdata;

                                    Manager.XmlTiles[_origin].Add(xmltile);
                                }
                                break;
                        }

                        if (type != ContentType.Objects)
                            Manager.XmlObjects[_origin].Remove(xmlobject);
                    }
                    break;

                case ContentType.Items:
                    {
                        var xmlitem = Manager.XmlItems[_origin].FirstOrDefault(sample => sample.Id == id);

                        switch (type)
                        {
                            case ContentType.Objects:
                                {
                                    var xmlobject = new ObjectsContent()
                                    {
                                        Type = type,
                                        Id = id,
                                        Name = name,
                                        TextureData = texturedata,
                                        Blocked = blocked
                                    };

                                    if (layerdata.Type != MapLayer.ABSTRACT)
                                        xmlobject.LayerData = layerdata;

                                    Manager.XmlObjects[_origin].Add(xmlobject);
                                }
                                break;

                            case ContentType.Items:
                                {
                                    xmlitem.Id = id;
                                    xmlitem.Name = name;
                                    xmlitem.TextureData = texturedata;
                                }
                                break;

                            case ContentType.Tiles:
                                {
                                    var xmltile = new TilesContent()
                                    {
                                        Type = type,
                                        Id = id,
                                        Name = name,
                                        TextureData = texturedata,
                                        Walkable = walkable,
                                    };

                                    if (layerdata.Type != MapLayer.ABSTRACT)
                                        xmltile.LayerData = layerdata;

                                    Manager.XmlTiles[_origin].Add(xmltile);
                                }
                                break;
                        }

                        if (type != ContentType.Items)
                            Manager.XmlItems[_origin].Remove(xmlitem);
                    }
                    break;

                case ContentType.Tiles:
                    {
                        var xmltile = Manager.XmlTiles[_origin].FirstOrDefault(sample => sample.Id == _id[0]);

                        switch (type)
                        {
                            case ContentType.Objects:
                                {
                                    var xmlobject = new ObjectsContent()
                                    {
                                        Type = type,
                                        Id = id,
                                        Name = name,
                                        TextureData = texturedata,
                                        Blocked = blocked
                                    };

                                    if (layerdata.Type != MapLayer.ABSTRACT)
                                        xmlobject.LayerData = layerdata;

                                    Manager.XmlObjects[_origin].Add(xmlobject);
                                }
                                break;

                            case ContentType.Items:
                                Manager.XmlItems[_origin].Add(new ItemsContent()
                                {
                                    Type = type,
                                    Id = id,
                                    Name = name,
                                    TextureData = texturedata
                                });
                                break;

                            case ContentType.Tiles:
                                {
                                    xmltile.Id = id;
                                    xmltile.Name = name;

                                    if (layerdata.Type != MapLayer.ABSTRACT)
                                        xmltile.LayerData = layerdata;

                                    xmltile.TextureData = texturedata;
                                    xmltile.Walkable = walkable;
                                }
                                break;
                        }

                        if (type != ContentType.Tiles)
                            Manager.XmlTiles[_origin].Remove(xmltile);
                    }
                    break;
            }

            _type[0] = type;
            _layer[0] = layerdata.Type;
            _group[0] = layerdata.Group;
            _id[0] = id;
            _name[0] = name;
            _file[0] = texturedata.File;
            _x[0] = texturedata.X;
            _y[0] = texturedata.Y;
            _animated[0] = texturedata.Animated;
            _blocked[0] = blocked;
            _walkable[0] = walkable;
            _spritePallete.Image = Manager.Spritesheets[texturedata.File].Image[texturedata.X, texturedata.Y];
            _spritePallete.ItemControl = this;

            MessageBox.Show("You have been saved your progress!", "Success!");
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var box = MessageBox.Show("Do you want to delete this item?", "Delete", MessageBoxButtons.YesNo);

            if (box == DialogResult.Yes)
                ((Manager)Parent.Parent.Parent.Parent.Parent.Parent).RemoveFromXml(_spritePallete.ParentId, _spritePallete.Id);
        }

        private void ObjectsButton_CheckedChanged(object sender, EventArgs e)
        {
            _type[1] = ContentType.Objects;

            ItemAnimated.Enabled = true;
            ItemAnimated.Checked = false;
            ItemBlocked.Enabled = true;
            ItemBlocked.Checked = false;
            ItemWalkable.Enabled = false;
            ItemWalkable.Checked = false;
        }

        private void ItemsButton_CheckedChanged(object sender, EventArgs e)
        {
            _type[1] = ContentType.Items;

            ItemAnimated.Enabled = false;
            ItemAnimated.Checked = false;
            ItemBlocked.Enabled = false;
            ItemBlocked.Checked = false;
            ItemWalkable.Enabled = false;
            ItemWalkable.Checked = false;
        }

        private void TilesButton_CheckedChanged(object sender, EventArgs e)
        {
            _type[1] = ContentType.Tiles;

            ItemAnimated.Enabled = false;
            ItemAnimated.Checked = false;
            ItemBlocked.Enabled = false;
            ItemBlocked.Checked = false;
            ItemWalkable.Enabled = true;
            ItemWalkable.Checked = false;
        }

        private void UndergroundButton_CheckedChanged(object sender, EventArgs e) => _layer[1] = MapLayer.UNDERGROUND;

        private void GroundButton_CheckedChanged(object sender, EventArgs e) => _layer[1] = MapLayer.GROUND;

        private void ObjectButton_CheckedChanged(object sender, EventArgs e) => _layer[1] = MapLayer.OBJECT;

        private void SkyButton_CheckedChanged(object sender, EventArgs e) => _layer[1] = MapLayer.SKY;

        private void ItemGroup_TextChanged(object sender, EventArgs e) => _group[1] = ItemGroup.Text;

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

        private void ItemFile_DrawItem(object sender, DrawItemEventArgs e) => CenterComboBoxItems(sender, e);

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

        private void ItemAnimated_CheckedChanged(object sender, EventArgs e) => _animated[1] = ItemAnimated.Checked;

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
                    ItemSprite.Image = spritesheetform.Image;
                }

                ItemX.Value = _x[1];
                ItemY.Value = _y[1];

                _state = ControlState.Normal;
            });
            ItemSprite.Image = Manager.Spritesheets[_file[1]].Image[_x[1], _y[1]];
        }

        public static void CenterComboBoxItems(object sender, DrawItemEventArgs e)
        {
            if (sender is ComboBox cbx)
            {
                e.DrawBackground();

                if (e.Index >= 0)
                {
                    var sf = new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Center
                    };

                    var brush = new SolidBrush(cbx.ForeColor);

                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                        brush = (SolidBrush)SystemBrushes.HighlightText;

                    e.Graphics.DrawString(cbx.Items[e.Index].ToString(), cbx.Font, brush, e.Bounds, sf);
                }
            }
        }
    }
}
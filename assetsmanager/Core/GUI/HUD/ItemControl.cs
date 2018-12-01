using LoESoft.AssetsManager.Core.Assets.Structure;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using static LoESoft.AssetsManager.Core.Assets.Structure.XmlContent;
using Timer = System.Timers.Timer;

namespace LoESoft.AssetsManager.Core.GUI.HUD
{
    public partial class ItemControl : UserControl
    {
        private Timer _clock { get; set; }
        private SpritePallete _spritePallete { get; set; }
        private string _origin { get; set; }
        private ContentType _contentType { get; set; }
        private int _id { get; set; }
        private string _name { get; set; }

        private SaveButtonVisibilityDelegate SaveButtonVisibility;
        private IDNumericValueDelegate IDNumericValue;
        private NameTextValueDelegate NameTextValue;

        private delegate void SaveButtonVisibilityDelegate(bool id, bool name);

        private delegate int IDNumericValueDelegate();

        private delegate string NameTextValueDelegate();

        public ItemControl(SpritePallete spritePallete, string origin, ContentType type, int id, string name)
        {
            _spritePallete = spritePallete;
            _origin = origin;
            _contentType = type;
            _id = id;
            _name = name;
            _clock = new Timer(1000) { AutoReset = true };
            _clock.Elapsed += delegate
            { SaveButtonVisibility(ItemId.Value != _id, ItemName.Text != _name); };

            InitializeComponent();

            switch (_contentType)
            {
                case ContentType.Objects: ObjectsButton.Checked = true; break;
                case ContentType.Items: ItemsButton.Checked = true; break;
                case ContentType.Tiles: TilesButton.Checked = true; break;
            }

            ItemId.Value = id;
            ItemName.Text = name;

            SaveButtonVisibility += OnSaveButtonVisibility;
            IDNumericValue += OnIDNumericValue;
            NameTextValue += OnNameTextValue;
            LostFocus += ItemControl_LostFocus;
        }

        private void ItemControl_LostFocus(object sender, EventArgs e)
        {
            ItemId.Value = _id;
            ItemName.Text = _name;
        }

        private void OnSaveButtonVisibility(bool id, bool name)
        {
            if (SaveButton.InvokeRequired)
                Invoke(SaveButtonVisibility, new object[] { id, name });
            else
                SaveButton.Visible = id || name;
        }

        private int OnIDNumericValue()
        {
            if (ItemId.InvokeRequired)
                Invoke(IDNumericValue);
            else
                return (int)ItemId.Value;

            return -1;
        }

        private string OnNameTextValue()
        {
            if (ItemName.InvokeRequired)
                Invoke(NameTextValue);
            else
                return ItemName.Text;

            return null;
        }

        private void ItemControl_Load(object sender, EventArgs e) => _clock.Start();

        private void SaveButton_Click(object sender, EventArgs e)
        {
            ObjectsContent sampleobject = null;
            ItemsContent sampleitem = null;
            TilesContent sampletile = null;

            var id = (int)ItemId.Value;
            var name = ItemName.Text;

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

            if (id <= 0 || id >= int.MaxValue)
            {
                MessageBox.Show("Invalid ID, consider to change.", "Error!");
                return;
            }

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Name must be not null or empty, consider to change.", "Error!");
                return;
            }

            if (sampleobject != null)
            {
                if (sampleobject.Name != _name)
                {
                    MessageBox.Show($"Object '{sampleobject.Name}' has same ID '{sampleobject.Id}', consider to change.", "Error!");
                    return;
                }
            }

            if (sampleitem != null)
            {
                if (sampleitem.Name != _name)
                {
                    MessageBox.Show($"Item '{sampleitem.Name}' has same ID '{sampleitem.Id}', consider to change.", "Error!");
                    return;
                }
            }

            if (sampletile != null)
            {
                if (sampletile.Name != _name)
                {
                    MessageBox.Show($"Tile '{sampletile.Name}' has same ID '{sampletile.Id}', consider to change.", "Error!");
                    return;
                }
            }

            switch (_contentType)
            {
                case ContentType.Objects:
                    {
                        var xmlobject = Manager.XmlObjects[_origin].FirstOrDefault(sample => sample.Id == _id);
                        xmlobject.Id = id;
                        xmlobject.Name = name;
                    }
                    break;

                case ContentType.Items:
                    {
                        var xmlitem = Manager.XmlItems[_origin].FirstOrDefault(sample => sample.Id == _id);
                        xmlitem.Id = id;
                        xmlitem.Name = name;
                    }
                    break;

                case ContentType.Tiles:
                    {
                        var xmltile = Manager.XmlTiles[_origin].FirstOrDefault(sample => sample.Id == _id);
                        xmltile.Id = id;
                        xmltile.Name = name;
                    }
                    break;
            }

            _id = id;
            _name = name;
            _spritePallete.ItemControl = this;

            MessageBox.Show("You have been saved your progress!", "Success!");
        }

        private void IDNumeric_Validating(object sender, CancelEventArgs e)
        {
            SaveButton.Enabled = false;

            SetStatus("...updating ID value.");
            ToggleProgressLabels();
        }

        private void IDNumeric_Validated(object sender, EventArgs e)
        {
            SaveButton.Enabled = true;

            ToggleProgressLabels();
        }

        private void ToggleProgressLabels()
        {
            ProgressMainLabel.Visible = !ProgressMainLabel.Visible;
            ProgressStatusLabel.Visible = !ProgressStatusLabel.Visible;
        }

        private void SetStatus(string text) => ProgressStatusLabel.Text = text;
    }
}
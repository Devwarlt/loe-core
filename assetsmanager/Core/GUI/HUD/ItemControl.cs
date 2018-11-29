using System;
using System.Linq;
using System.Windows.Forms;
using static LoESoft.AssetsManager.Core.Assets.Structure.XmlContent;

namespace LoESoft.AssetsManager.Core.GUI.HUD
{
    public partial class ItemControl : UserControl
    {
        private string _origin { get; set; }
        private ContentType _contentType { get; set; }
        private int _firstId { get; set; }
        private int _id { get; set; }
        private string _firstName { get; set; }
        private string _name { get; set; }

        public ItemControl(string origin, ContentType type, int id, string name)
        {
            _origin = origin;
            _contentType = type;
            _firstId = id;
            _firstName = name;

            InitializeComponent();

            switch (_contentType)
            {
                case ContentType.Objects: ObjectsButton.Checked = true; break;
                case ContentType.Items: ItemsButton.Checked = true; break;
                case ContentType.Tiles: TilesButton.Checked = true; break;
            }

            IDNumeric.Value = id;
            NameTextBox.Text = name;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var sampleobject = Manager.XmlObjects[_origin].FirstOrDefault(sample => sample.Id == _id);
            var sampleitem = Manager.XmlItems[_origin].FirstOrDefault(sample => sample.Id == _id);
            var sampletile = Manager.XmlTiles[_origin].FirstOrDefault(sample => sample.Id == _id);

            if (sampleobject != null)
            {
                MessageBox.Show($"Object '{sampleobject.Name}' has same ID, consider to change.", "Error!");
                return;
            }

            if (sampleitem != null)
            {
                MessageBox.Show($"Item '{sampleitem.Name}' has same ID, consider to change.", "Error!");
                return;
            }

            if (sampletile != null)
            {
                MessageBox.Show($"Tile '{sampletile.Name}' has same ID, consider to change.", "Error!");
                return;
            }

            // TODO: issue with save method, require review
            switch (_contentType)
            {
                case ContentType.Objects:
                    {
                        var index = Manager.XmlObjects[_origin].FindIndex(sample => sample.Id == _firstId);
                        var xmlobject = Manager.XmlObjects[_origin][index];
                        xmlobject.Id = _id;
                        xmlobject.Name = _name;
                    }
                    break;

                case ContentType.Items:
                    {
                        var index = Manager.XmlItems[_origin].FindIndex(sample => sample.Id == _firstId);
                        var xmlitem = Manager.XmlItems[_origin][index];
                        xmlitem.Id = _id;
                        xmlitem.Name = _name;
                    }
                    break;

                case ContentType.Tiles:
                    {
                        var index = Manager.XmlTiles[_origin].FindIndex(sample => sample.Id == _firstId);
                        var xmltile = Manager.XmlTiles[_origin][index];
                        xmltile.Id = _id;
                        xmltile.Name = _name;
                    }
                    break;
            }

            MessageBox.Show("You have been saved your progress!", "Success!");
        }
    }
}
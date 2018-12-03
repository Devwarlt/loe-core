using LoESoft.AssetsManager.Core.Assets.Structure;
using LoESoft.AssetsManager.Core.GUI.HUD;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LoESoft.AssetsManager.Core.GUI
{
    public partial class SpritesheetForm : Form
    {
        private const int X_MAGIC_NUMBER = 3;
        private const int Y_MAGIC_NUMBER = 33 / 2 + 3;
        private const int MAX_SIZE = 400;

        public string File { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Image Image { get; set; }

        private Dictionary<int, SpriteData> _spritedatas { get; set; }
        private SpritesContent _sprites { get; set; }

        public SpritesheetForm() => InitializeComponent();

        private void SpritesheetForm_Load(object sender, EventArgs e)
        {
            _spritedatas = new Dictionary<int, SpriteData>();
            _sprites = Manager.Spritesheets[File];

            Width = _sprites.Width * 17 * 2 + X_MAGIC_NUMBER;
            Height = _sprites.Height * 17 * 2 + Y_MAGIC_NUMBER;

            if (Width >= MAX_SIZE)
                Width = MAX_SIZE;
            if (Height >= MAX_SIZE)
                Height = MAX_SIZE;

            var id = 0;

            for (var x = 0; x < _sprites.Width; x++)
                for (var y = 0; y < _sprites.Height; y++)
                {
                    var image = _sprites.Image[x, y];
                    var spritepallete = new SpritePallete()
                    {
                        Id = id,
                        Location = new Point(2 + x * 33, 2 + y * 33),
                        Name = "spritepallete",
                        Size = new Size(33, 33),
                        TabIndex = 2
                    };
                    spritepallete.Action = () => Invoke((MethodInvoker)delegate ()
                        {
                            var spritedata = _spritedatas[spritepallete.Id];
                            X = spritedata.X;
                            Y = spritedata.Y;
                            Image = spritedata.Image;

                            DialogResult = DialogResult.OK;
                        });
                    spritepallete.SetImage(image);

                    _spritedatas.Add(id, new SpriteData()
                    {
                        X = x,
                        Y = y,
                        Image = image
                    });

                    Controls.Add(spritepallete);

                    id++;
                }

            Text = $"Spritesheet: '{File}'.";

            CenterToScreen();
        }
    }
}
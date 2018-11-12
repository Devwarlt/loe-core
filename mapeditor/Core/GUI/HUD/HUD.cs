﻿using LoESoft.MapEditor.Core.GUI.Button;
using LoESoft.MapEditor.Core.GUI.Button.Buttons;
using LoESoft.MapEditor.Core.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LoESoft.MapEditor.Core.GUI.HUD
{
    public class HUD
    {
        private Texture2D _leftPanel { get; set; }
        private Texture2D _newMapIcon { get; set; }
        private Texture2D _saveMapIcon { get; set; }
        private Texture2D _loadMapIcon { get; set; }
        private Vector2 _position { get; set; }
        private List<EditorButton> _buttons { get; set; }

        public HUD()
        {
            _leftPanel = new Texture2D(MapEditor.GraphicsDeviceManager.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            _leftPanel.SetData(new Color[] { Color.Gainsboro });
            _newMapIcon = Utils.LoadEmbeddedTexture("new-file.png");
            _saveMapIcon = Utils.LoadEmbeddedTexture("save-file.png");
            _loadMapIcon = Utils.LoadEmbeddedTexture("load-file.png");
            _position = new Vector2(0, 0);

            var position = _position;
            var spritesize = _newMapIcon.Width;
            var offset = 8;

            _buttons = new List<EditorButton>();
            position += new Vector2(offset, offset);
            _buttons.Add(new NewMapButton(_newMapIcon, position));
            position.X += 2;
            position.Y += spritesize + offset;
            _buttons.Add(new SaveMapButton(_saveMapIcon, position));
            position.X -= 2;
            position.Y += spritesize + offset;
            _buttons.Add(new LoadMapButton(_loadMapIcon, position));
        }

        public void Update()
        {
            foreach (var button in _buttons)
            {
                button.Update();

                if (button.Clicked)
                    button.Effect();
            }
        }

        public void Draw()
        {
            MapEditor.SpriteBatch.Draw(_leftPanel, new Rectangle(0, 0, 200, 600), Color.DimGray);

            foreach (var button in _buttons)
                button.Draw();
        }
    }
}
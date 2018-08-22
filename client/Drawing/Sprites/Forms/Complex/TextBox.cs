using LoESoft.Client.Drawing.Events;
using LoESoft.Client.Drawing.Sprites.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoESoft.Client.Drawing.Sprites.Forms.Complex
{
    public class TextBox : FilledRectangle
    {
        public static List<Keys> ValidKeys = new List<Keys>() // for keys that are length > 2 and valid
        {
            Keys.OemPeriod,
            Keys.NumPad1,
            Keys.NumPad2,
            Keys.NumPad3,
            Keys.NumPad4,
            Keys.NumPad5,
            Keys.NumPad6,
            Keys.NumPad7,
            Keys.NumPad8,
            Keys.NumPad9,
        };

        public bool Selected { get; set; }
        public bool Encoded { get; set; }
        public int Limit { get; set; }

        public StringBuilder Text { get; private set; }
        public TextDisplay TitleText { get; private set; }
        public TextDisplay TextField { get; private set; }

        FilledRectangle _selectedMarket;

        protected EventsHandler _keyEvents;

        public TextBox(int x, int y, int width = 100, string name = "", int limit = 16, bool encoded = false)
            : base(x, y, width, TextDisplay.GetHeight(12) + 4, new RGBColor(255, 255, 255))
        {
            Limit = limit;
            Selected = false;
            Encoded = encoded;

            _keyEvents = new EventsHandler();
            Text = new StringBuilder();
            TitleText = new TextDisplay(2, -20, name, color: new RGBColor(10, 10, 10));
            TextField = new TextDisplay(2, 2, "", color: new RGBColor(10, 10, 10));

            _selectedMarket = new FilledRectangle(1, 1, 2, Height - 2, new RGBColor(0, 0, 0));

            AddChild(_selectedMarket);
            AddChild(TitleText);
            AddChild(TextField);
        }

        float _timer = 0f;
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            char[] pressedKeys = _keyEvents.HandleKeyBoard(Event.GETPRESSEDKEYS).ToArray();

            foreach (var i in pressedKeys)
            {
                if (Text.Length <= Limit && Selected)
                {
                    Text.Append((Encoded) ? "*" : i.ToString());

                    TextField.Text = Text.ToString();
                }
            }

            if (Selected && _timer > 0.5f)
            {
                _selectedMarket.Visible = !_selectedMarket.Visible;
                _timer = 0f;
            } 
            else
                _selectedMarket.Visible = (Selected);

            _selectedMarket.X = (int)TextDisplay.MeasureString(TextField.Text).X + 3;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}

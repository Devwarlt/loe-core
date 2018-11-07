﻿using LoESoft.Client.Drawing.Events;
using LoESoft.Client.Drawing.Sprites.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        private FilledRectangle SelectedMarket;

        protected EventsHandler KeyEvents;

        public TextBox(int x, int y, int width = 100, string name = "", int tsize = 12, int limit = 16, bool encoded = false)
            : base(x, y, width, TextDisplay.GetHeight(12) + 4, new RGBColor(255, 255, 255))
        {
            Limit = limit;
            Selected = false;
            Encoded = encoded;

            KeyEvents = new EventsHandler();
            Text = new StringBuilder();
            TitleText = new TextDisplay(2, -20, name, color: new RGBColor(10, 10, 10));
            TextField = new TextDisplay(2, 2, "", size: tsize, color: new RGBColor(10, 10, 10));

            SelectedMarket = new FilledRectangle(1, 1, 2, Height - 2, new RGBColor(0, 0, 0))
            {
                Visible = false
            };

            AddChild(SelectedMarket);
            AddChild(TitleText);
            AddChild(TextField);
        }

        public string GetText => TextField.Text;

        private float Timer = 0f;

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (!Selected)
            {
                SelectedMarket.Visible = false;
                return;
            }

            Timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (KeyEvents.HandleBackSpace(gameTime))
            {
                if (Text.Length > 0)
                    Text.Length--;
            }
            else
            {
                KeyEvents.HandleKeyBoard(Event.GETPRESSEDKEYS).Where(_ => (Text.Length <= Limit && Selected)).Select(_ =>
                {
                    Text.Append(_.ToString());

                    return _;
                }).ToList();
            }

            TextField.Text = Encoded ? GetEncodedString(Text.ToString()) : Text.ToString();

            if (Selected && Timer > 0.5f)
            {
                SelectedMarket.Visible = !SelectedMarket.Visible;
                Timer = 0f;
            }

            SelectedMarket.X = TextField.Width + 3;
        }

        private string GetEncodedString(string value)
        {
            var text = new StringBuilder();

            for (var i = 0; i < value.Length; i++)
                text.Append("*");

            return text.ToString();
        }

        public void Clear()
        {
            Text.Clear();
            TextField.Text = string.Empty;
        }
    }
}
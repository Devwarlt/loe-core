using LoESoft.Client.Drawing.Events;
using LoESoft.Client.Drawing.Sprites.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoESoft.Client.Drawing.Sprites.Forms.Complex
{
    public class TextBox : FilledRectangle
    {
        public bool Encoded { get; set; }
        public int Limit { get; set; }

        public StringBuilder Text { get; private set; }

        public TextDisplay TextField { get; private set; }

        protected EventsHandler _keyEvents;

        public TextBox(int x, int y, int width = 100, int limit = 16, bool encoded = false)
            : base(x, y, width, TextDisplay.GetHeight(12) + 4, new RGBColor(255, 255, 255))
        {
            Limit = limit;
            Encoded = encoded;

            _keyEvents = new EventsHandler();
            Text = new StringBuilder();
            TextField = new TextDisplay(2, 2, "");

            AddChild(TextField);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var i in _keyEvents.HandleKeyBoard(Event.GETPRESSEDKEYS).ToArray())
            {
                if (Limit <= Text.Length)
                {
                    Text.Append(i);

                    TextField.Text = Text.ToString();
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}

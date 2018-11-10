using System;
using LoESoft.Client.Assets;
using LoESoft.Client.Assets.Xml.Structure;
using LoESoft.Client.Drawing.Events;
using LoESoft.Client.Drawing.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LoESoft.Client.Drawing;

namespace LoESoft.Client.Core.Screens.TitleScreen.CharacterSelection
{
    public class CharacterRect : Sprite
    {
        public Sprite CharacterView { get; private set; }
        
        public CharacterRect(int x, int y) :
            base(x, y, 250, 250, AssetLibrary.Images["characterRect"])
        {
            AddEventListener(Event.CLICKLEFT, onSelected);
            AddEventListener(Event.MOUSEOUT, delegate
            {
                SpriteColor = Color.White;
            });
            AddEventListener(Event.MOUSEOVER, delegate
            {
                SpriteColor = Color.DarkGray;
            });
        }

        public void Init(ObjectsContent content)
        {
            var texture = XmlLibrary.GetSpriteFromContent(content);

            CharacterView = new Sprite(50, 15, 150, 150, texture);
            CharacterView.IsEventApplicable = false;

            AddChild(CharacterView);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.StartClamp();
            base.Draw(spriteBatch);
            spriteBatch.EndClamp();
        }

        private void onSelected(object sender, EventArgs e)
        {

        }
    }
}

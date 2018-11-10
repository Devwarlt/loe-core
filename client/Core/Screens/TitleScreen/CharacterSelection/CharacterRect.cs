using System;
using LoESoft.Client.Assets;
using LoESoft.Client.Assets.Xml.Structure;
using LoESoft.Client.Drawing.Events;
using LoESoft.Client.Drawing.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Core.Screens.TitleScreen.CharacterSelection
{
    public class CharacterRect : Sprite
    {
        public Sprite CharacterView { get; private set; }
        
        public CharacterRect(int x, int y) :
            base(x, y, 40, 40, AssetLibrary.Images["characterRect"])
        {
            AddEventListener(Event.CLICKLEFT, onSelected);
            AddEventListener(Event.MOUSEOUT, delegate
            {
                SpriteColor = Color.White;
            });
            AddEventListener(Event.MOUSEOVER, delegate
            {
                SpriteColor = Color.LightGray;
            });
        }

        public void Init(ObjectsContent content)
        {
            var texture = XmlLibrary.GetSpriteFromContent(content);

            CharacterView = new Sprite(10, 10, 30, 30, texture);
            CharacterView.IsEventApplicable = false;

            AddChild(CharacterView);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        private void onSelected(object sender, EventArgs e)
        {

        }
    }
}

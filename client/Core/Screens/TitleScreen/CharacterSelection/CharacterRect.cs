using System;
using LoESoft.Client.Assets;
using LoESoft.Client.Assets.Xml.Structure;
using LoESoft.Client.Drawing.Events;
using LoESoft.Client.Drawing.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LoESoft.Client.Drawing;
using LoESoft.Client.Core.Screens.TitleScreen.CharacterSelection.ChooseView;
using LoESoft.Client.Drawing.Sprites.Forms;

namespace LoESoft.Client.Core.Screens.TitleScreen.CharacterSelection
{
    public class CharacterRect : Sprite
    {
        public Sprite CharacterView { get; private set; }
        public ObjectsContent Content { get; private set; }
        public int ClassIndex { get; private set; }

        private ChooseCharacterBar _chooseCharacterBar;
        
        public CharacterRect(int x, int y) :
            base(x, y, 250, 250, AssetLibrary.Images["characterRect"])
        {
            _chooseCharacterBar = new ChooseCharacterBar();

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

        public void Init(int idx)
        {
            ClassIndex = idx;

            if (ClassIndex != -1)
            {
                Content = XmlLibrary.ObjectsXml[ClassIndex];
                AddCharacterView();
            } 
        }

        private void AddCharacterView()
        {
            CharacterView = new Sprite(50, 15, 150, 150, XmlLibrary.GetSpriteFromContent(Content));
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
            if (ClassIndex == -1)
            {
                //Make Choose Character Bar
                _chooseCharacterBar.Init();

                ParentSprite.AddChild(_chooseCharacterBar);
            }
        }
    }
}

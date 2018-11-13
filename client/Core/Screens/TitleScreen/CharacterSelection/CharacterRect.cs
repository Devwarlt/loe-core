using LoESoft.Client.Assets;
using LoESoft.Client.Assets.Xml;
using LoESoft.Client.Assets.Xml.Structure;
using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Screens.TitleScreen.CharacterSelection.ChooseView;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Events;
using LoESoft.Client.Drawing.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LoESoft.Client.Core.Screens.TitleScreen.CharacterSelection
{
    public class CharacterRect : Sprite
    {
        public Sprite CharacterView { get; private set; }
        public ObjectsContent Content { get; private set; }

        private ChooseCharacterBar _chooseCharacterBar;

        public int ClassIndex { get; private set; }
        public int CharacterIndex { get; set; }
        public bool Selected { get; set; }

        public CharacterRect(int x, int y) :
            base(x, y, 250, 250, AssetLibrary.Images["characterRect"])
        {
            _chooseCharacterBar = new ChooseCharacterBar();
            _chooseCharacterBar.IsZeroApplicaple = true;

            Selected = false;

            AddEventListener(Event.CLICKLEFT, onSelected);
            AddEventListener(Event.MOUSEOUT, delegate
            {
                if (!Selected)
                    SpriteColor = Color.White;
            });
            AddEventListener(Event.MOUSEOVER, delegate
            {
                SpriteColor = Color.RoyalBlue;
            });
        }

        private GameUser _gameUser;

        public void Init(GameUser user, int idx, int cidx)
        {
            _gameUser = user;
            ClassIndex = idx;
            CharacterIndex = cidx;

            if (ClassIndex != -1)
            {
                Content = XmlLibrary.ObjectsXml[ClassIndex];
                AddCharacterView();
            }
        }

        private void AddCharacterView()
        {
            RemoveChild(CharacterView);

            CharacterView = new Sprite(50, 15, 150, 150, XmlLibrary.GetSpriteFromContent(Content));
            CharacterView.IsEventApplicable = false;

            AddChild(CharacterView);
        }

        public override void Update(GameTime gameTime)
        {
            if ((Selected = (CharacterSettings.CurrentCharacterId == CharacterIndex)))
                SpriteColor = Color.RoyalBlue;

            base.Update(gameTime);
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
                _chooseCharacterBar.Init(_gameUser, this);

                ParentSprite.AddChild(_chooseCharacterBar);
            }
            else
            {
                CharacterSettings.CurrentCharacterId = CharacterIndex;
            }
        }
    }
}
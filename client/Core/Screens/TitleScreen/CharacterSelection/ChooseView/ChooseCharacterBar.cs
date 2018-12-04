using LoESoft.Client.Assets.Xml;
using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Networking.Packets.Outgoing;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Events;
using LoESoft.Client.Drawing.Sprites;
using LoESoft.Client.Drawing.Sprites.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Core.Screens.TitleScreen.CharacterSelection.ChooseView
{
    public class ChooseCharacterBar : Sprite
    {
        private Mask _mask;

        private Sprite _meleeClass;
        private Sprite _rangeClass;
        private Sprite _defenseClass;

        public ChooseCharacterBar() : base(DrawHelper.CenteredPosition(GameApplication.WIDTH, 400), 250, 400, 200)
        {
            _mask = new Mask(new RGBColor(26, 13, 2), 0.75f);
        }

        private GameUser _gameUser;
        private CharacterRect _parent;

        public void Init(GameUser user, CharacterRect parent)
        {
            _gameUser = user;
            _parent = parent;

            int spriteX = 10;

            _meleeClass = new Sprite(spriteX, 10, 120, 120, XmlLibrary.GetSpriteFromContent(XmlLibrary.ObjectsXml[5], 0, 1));
            spriteX += 130;
            _rangeClass = new Sprite(spriteX, 10, 120, 120, XmlLibrary.GetSpriteFromContent(XmlLibrary.ObjectsXml[6], 0, 1));
            spriteX += 130;
            _defenseClass = new Sprite(spriteX, 10, 120, 120, XmlLibrary.GetSpriteFromContent(XmlLibrary.ObjectsXml[7], 0, 1));

            _meleeClass.AddEventListener(Event.CLICKLEFT, delegate
            {
                CreateCharacter(5);
                ParentSprite.RemoveChild(this);
            });
            _meleeClass.AddEventListener(Event.MOUSEOUT, delegate { _meleeClass.SpriteColor = Color.White; });
            _meleeClass.AddEventListener(Event.MOUSEOVER, delegate { _meleeClass.SpriteColor = Color.DarkSlateGray; });

            _rangeClass.AddEventListener(Event.CLICKLEFT, delegate
            {
                CreateCharacter(6);
                ParentSprite.RemoveChild(this);
            });
            _rangeClass.AddEventListener(Event.MOUSEOUT, delegate { _rangeClass.SpriteColor = Color.White; });
            _rangeClass.AddEventListener(Event.MOUSEOVER, delegate { _rangeClass.SpriteColor = Color.DarkSlateGray; });

            _defenseClass.AddEventListener(Event.CLICKLEFT, delegate
            {
                CreateCharacter(7);
                ParentSprite.RemoveChild(this);
            });
            _defenseClass.AddEventListener(Event.MOUSEOUT, delegate { _defenseClass.SpriteColor = Color.White; });
            _defenseClass.AddEventListener(Event.MOUSEOVER, delegate { _defenseClass.SpriteColor = Color.DarkSlateGray; });

            AddChild(_mask);
            AddChild(_meleeClass);
            AddChild(_rangeClass);
            AddChild(_defenseClass);
        }

        private void CreateCharacter(int classType)
        {
            _gameUser.SendPacket(new CreateNewCharacter()
            {
                World = 0,
                ClassType = classType,
                CharacterIndex = _parent.CharacterIndex
            });
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.StartClamp();
            base.Draw(spriteBatch);
            spriteBatch.EndClamp();
        }
    }
}
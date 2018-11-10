using LoESoft.Client.Assets.Xml;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Events;
using LoESoft.Client.Drawing.Sprites;
using LoESoft.Client.Drawing.Sprites.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LoESoft.Client.Core.Screens.TitleScreen.CharacterSelection.ChooseView
{
    public class ChooseCharacterBar : Sprite
    {
        public int[] ClassIds;

        private Mask _mask;

        public ChooseCharacterBar() : base(0, 0, 400, 200)
        {
            _mask = new Mask(new RGBColor(26, 13, 2), 0.75f);
            ClassIds = new int[] { 5, 6, 7 }; //All the classes
        }

        public void Init()
        {
            X = DrawHelper.CenteredPosition(GameApplication.WIDTH, 400);
            Y = DrawHelper.CenteredPosition(GameApplication.HEIGHT, 200);

            int spriteX = 0;

            var spriteList = new List<Sprite>();
            foreach (var i in ClassIds)
            {
                var texture = XmlLibrary.GetSpriteFromContent(XmlLibrary.ObjectsXml[i]);
                var classSprite = new Sprite(spriteX + 10, 10, 120, 120, texture);

                spriteList.Add(classSprite);

                spriteX += 120;
            }

            spriteList[0].AddEventListener(Event.MOUSEOUT, delegate
            {
                spriteList[0].SpriteColor = Color.White;
            });
            spriteList[0].AddEventListener(Event.MOUSEOVER, delegate
            {
                spriteList[0].SpriteColor = Color.SlateGray;
            });
            spriteList[0].AddEventListener(Event.CLICKLEFT, delegate
            {
                Remove();
                //Send Packet
            });
            spriteList[1].AddEventListener(Event.MOUSEOUT, delegate
            {
                spriteList[1].SpriteColor = Color.White;
            });
            spriteList[1].AddEventListener(Event.MOUSEOVER, delegate
            {
                spriteList[1].SpriteColor = Color.SlateGray;
            });
            spriteList[1].AddEventListener(Event.CLICKLEFT, delegate
            {
                Remove();
                //Send Packet
            });
            spriteList[2].AddEventListener(Event.MOUSEOUT, delegate
            {
                spriteList[2].SpriteColor = Color.White;
            });
            spriteList[2].AddEventListener(Event.MOUSEOVER, delegate
            {
                spriteList[2].SpriteColor = Color.SlateGray;
            });
            spriteList[2].AddEventListener(Event.CLICKLEFT, delegate
            {
                App.Warn("WTF!");
                ParentSprite.RemoveChild(this);
                //Send Packet
            });

            AddChild(_mask);
            AddChild(spriteList[0]);
            AddChild(spriteList[1]);
            AddChild(spriteList[2]);
        }

        private void Remove()
        {
            App.Warn("TEST!");
            try
            {
                ParentSprite.RemoveChild(this);
            }
            catch (Exception ex)
            {
                App.Warn(ex.ToString());
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.StartClamp();
            base.Draw(spriteBatch);
            spriteBatch.EndClamp();
        }
    }
}
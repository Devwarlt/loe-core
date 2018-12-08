using LoESoft.Client.Assets;
using LoESoft.Client.Assets.Xml;
using LoESoft.Client.Assets.Xml.Structure;
using LoESoft.Client.Core.Game.User.GUI.UI.Elements.UI;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Events;
using LoESoft.Client.Drawing.Sprites;
using LoESoft.Client.Drawing.Sprites.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace LoESoft.Client.Core.Game.User.GUI.UI.Elements
{
    public class ItemCell : Sprite
    {
        public static bool Dragging = false;
        public static int DraggedIndex = -1;

        public Sprite ItemSprite { get; set; }
        public ItemsContent XmlContent { get; set; }

        protected DescriptionPanel DescriptionBox { get; set; }
        protected ActiveDescriptionBox ActiveDescription { get; set; }

        public int Id { get; set; }
        public int ItemIndex { get; set; }
        public bool Selected { get; set; }

        public Action OnDropped { get; set; }

        public ItemCell(int id, int itemidx, int x, int y)
            : base(x, y, 50, 50, AssetLibrary.Images["itemDisplayRect"])
        {
            Id = id;
            ItemIndex = itemidx;
            if (Id != -1)
                XmlContent = XmlLibrary.ItemsXml[Id];

            ItemSprite = new Sprite(10, 10, 30, 30, (XmlContent == null) ? null : XmlLibrary.GetSpriteFromContent(XmlContent));

            //DescriptionBox = new DescriptionPanel(DrawHelper.CenteredToScreenWidth(300), DrawHelper.CenteredToScreenHeight(400), XmlContent.Name);
            //DescriptionBox.IsZeroApplicaple = true;

            ActiveDescription = new ActiveDescriptionBox(0, 0);
            ActiveDescription.Reload((XmlContent == null) ? null : XmlContent);
            ActiveDescription.Visible = false;
            ActiveDescription.IsZeroApplicaple = true;
            ActiveDescription.IsEventApplicable = false;
            
            AddChild(ItemSprite);

            AddEventListener(Event.MOUSEOVER, delegate
            {
                SpriteColor = Color.Yellow;
                Selected = true;

                if (!Dragging && Id != -1)
                {
                    if (!ParentSprite.Contains(ActiveDescription))
                        ParentSprite.AddChild(ActiveDescription);

                    ActiveDescription.Visible = true;
                    ActiveDescription.X = EventsHandler.MouseRectangle.X;
                    ActiveDescription.Y = EventsHandler.MouseRectangle.Y;
                }
            });

            AddEventListener(Event.MOUSEOUT, delegate
            {
                SpriteColor = Color.Gray;

                Selected = false;
                ActiveDescription.Visible = false;
            });
        }

        public void Reload(int id)
        {
            Id = id;
            XmlContent = XmlLibrary.ItemsXml[Id];

            if (Contains(ItemSprite))
            {
                RemoveChild(ItemSprite);
                ItemSprite.SpriteTexture = XmlLibrary.GetSpriteFromContent(XmlContent);
                AddChild(ItemSprite);
            } else
            {
                ItemSprite = new Sprite(5, 5, 30, 30, XmlLibrary.GetSpriteFromContent(XmlContent));
                AddChild(ItemSprite);
            }

            ActiveDescription.Reload(XmlContent);
        }

        private MouseState _curMouse;
        private MouseState _preMouse;
        private Stopwatch _dragTimer = new Stopwatch();
        
        public override void Update(GameTime gameTime)
        {
            _preMouse = _curMouse;
            _curMouse = Mouse.GetState();
            
            if (_preMouse.LeftButton == ButtonState.Pressed && _curMouse.LeftButton == ButtonState.Pressed)
            {
                if (!_dragTimer.IsRunning && EventsHandler.MouseRectangle.Intersects(SpriteRectangle) && !Dragging)
                    _dragTimer.Start();

                if (_dragTimer.ElapsedMilliseconds > 50)
                {
                    if (!ParentSprite.Contains(ItemSprite) && !Dragging)
                    { 
                        RemoveChild(ItemSprite);
                        ParentSprite.AddChild(ItemSprite);

                        ActiveDescription.Visible = false;
                        
                        DraggedIndex = ItemIndex;
                    }

                    Dragging = true;
                    ItemSprite.IsZeroApplicaple = true;
                    ItemSprite.X = EventsHandler.MouseRectangle.X;
                    ItemSprite.Y = EventsHandler.MouseRectangle.Y;
                }
            } else
            {
                if (Dragging)
                {
                    ParentSprite.RemoveLastChild();
                    
                    OnDropped?.Invoke();

                    Dragging = false;
                }

                if (_dragTimer.IsRunning)
                {
                    _dragTimer.Reset();
                    _dragTimer.Stop();
                }
            }
            
            base.Update(gameTime);
        }
    }
}
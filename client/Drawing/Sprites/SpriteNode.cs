using LoESoft.Client.Drawing.Events;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoESoft.Client.Drawing.Sprites
{
    public class SpriteNode
    {
        public bool Visible = true;

        public bool IsZeroApplicaple { get; set; } = false;
        public int Index { get; set; } = 0;

        public List<SpriteNode> ChildList { get; set; }
        public Dictionary<Event, EventHandler> EventDictionary { get; set; }
        public SpriteNode ParentSprite { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public int StageX => (ParentSprite != null && !IsZeroApplicaple) ? ParentSprite.StageX + X : X;
        public int StageY => (ParentSprite != null && !IsZeroApplicaple) ? ParentSprite.StageY + Y : Y;
        public Rectangle SpriteRectangle => new Rectangle(StageX, StageY, Width, Height);
        public int SpriteLevel => ParentSprite != null ? ParentSprite.SpriteLevel + 1 : 0;

        protected EventsHandler _eventsHandler;

        public SpriteNode(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;

            ChildList = new List<SpriteNode>();
            EventDictionary = new Dictionary<Event, EventHandler>();
            _eventsHandler = new EventsHandler();
        }

        public virtual void Update(GameTime gameTime)
        {
            ChildList.OrderBy(_ => _.Index).Reverse().Select(_ => { _?.Update(gameTime); return _; }).ToList();
            EventDictionary.Select(_ => { if (_eventsHandler.HandleMouse(this, _.Key)) _.Value.Invoke(this, new EventArgs()); return _; }).ToList();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (Visible) ChildList.Select(_ => { _.Draw(spriteBatch); return _; }).ToList();
        }

        #region "Child events"

        public void AddChild(SpriteNode child)
        {
            child.ParentSprite = this;
            child.Index = ChildList.Count;
            ChildList.Add(child);
        }

        public void RemoveChild(SpriteNode child) => ChildList.Remove(child);

        public void RemoveAllChild() => ChildList.Clear();

        #endregion "Child events"

        #region Event listener

        public void AddEventListener(Event e, EventHandler handler)
        {
            if (!EventDictionary.ContainsKey(e))
                EventDictionary.Add(e, handler);
        }

        public void RemoveEventListener(Event e)
        {
            if (EventDictionary.ContainsKey(e))
                EventDictionary.Remove(e);
        }

        public void RemoveAllEvent() => EventDictionary.Clear();

        #endregion Event listener
    }
}
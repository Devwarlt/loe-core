using LoESoft.Client.Drawing.Events;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LoESoft.Client.Drawing.Sprites
{
    public class SpriteNode
    {
        public List<SpriteNode> ChildList { get; private set; }
        public Dictionary<Event, EventHandler> EventDictionary { get; private set; }
        
        public SpriteNode ParentSprite { get; set; }

        public Rectangle SpriteRectangle
        {
            get { return new Rectangle(StageX, StageY, Width, Height); }
        }

        public int X { get;  set; }
        public int Y { get;  set; }
        public int StageX
        {
            get { return (ParentSprite != null) ? ParentSprite.X + X : X; }
        }
        public int StageY
        {
            get { return (ParentSprite != null) ?ParentSprite.Y + Y : Y; }
        }

        public int Width { get;  set; }
        public int Height { get; set; }

        public int Index { get; set; }

        public bool Visible = true;
        public bool IsInvokable = true;

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

        protected EventsHandler _eventsHandler;

        public virtual void Update(GameTime gameTime)
        {
            foreach (var i in ChildList.ToArray())
                i.Update(gameTime);

            foreach(var i in EventDictionary)
            {
                if (_eventsHandler.Handle(this, i.Key) && IsInvokable)
                {
                    i.Value?.Invoke(this, new EventArgs());
                    SetInvokables(false);
                } else
                {
                    SetInvokables(true);
                }
            }
        }

        protected void SetInvokables(bool val)
        {
            if (ParentSprite != null && ParentSprite.IsInvokable != val)
                ParentSprite.IsInvokable = val;

            foreach (var i in ParentSprite.ChildList)
                if (i.Index < Index)
                    i.IsInvokable = val;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (!Visible)
                return;

            foreach (var i in ChildList.ToArray())
                i.Draw(spriteBatch);
        }

        #region ChildEvents
        public void AddChild(SpriteNode child)
        {
            child.ParentSprite = this;
            child.Index = ChildList.Count + 1;
            ChildList.Add(child);
        }

        public void RemoveChild(SpriteNode child) => ChildList.Remove(child);

        public void RemoveAllChild() => ChildList.Clear();
        #endregion

        #region EventListener
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
        #endregion
    }
}

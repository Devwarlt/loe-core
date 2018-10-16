using LoESoft.Client.Drawing.Events;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Threading;

namespace LoESoft.Client.Drawing.Sprites
{
    public class SpriteNode
    {
        public List<SpriteNode> ChildList { get; set; }
        public Dictionary<Event, EventHandler> EventDictionary { get; set; }
        public SpriteNode ParentSprite { get; set; }

        public Rectangle SpriteRectangle => new Rectangle(StageX, StageY, Width, Height);
        public int StageX => (ParentSprite != null && !IsZeroApplicaple) ? ParentSprite.StageX + X : X;
        public int StageY => (ParentSprite != null && !IsZeroApplicaple) ? ParentSprite.StageY + Y : Y;

        public bool Visible = true;
        public bool IsInvoked = false;

        public bool IsZeroApplicaple { get; set; } = false;
        
        private int _x { get; set; }
        public int X { get => _x; set => _x = value; }
        private int _y { get; set; }
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }

        public int _x { get; set; }
        public int _y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public int Index { get; set; } = 0;
        public int SpriteLevel
        {
            get
            {
                if (ParentSprite != null)
                    return ParentSprite.SpriteLevel + 1;
                return 0;
            }
        }
        public int Index { get; set; }

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
        
        protected EventsHandler _eventsHandler;
        
        public virtual void Update(GameTime gameTime)
        {
            foreach (var i in ChildList.ToArray())
                i.Update(gameTime);

            foreach (var i in EventDictionary)
            {
                if (_eventsHandler.HandleMouse(this, i.Key))
                    i.Value?.Invoke(this, new EventArgs());
            }
                if (_eventsHandler.HandleMouse(this, i.Key) &&
                    !EventsManager.ActiveNode.IsActive && EventsManager.ActiveNode.Node != this)
                {
                    if (i.Key != Event.MOUSEOUT)
                    {
                        EventsManager.ActiveNode.IsActive = true;
                        EventsManager.ActiveNode.Node = this;
                    }

                    i.Value?.Invoke(this, new EventArgs());

                    EventsManager.SetUnactive();
                }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (Visible)
                foreach (var i in ChildList.ToArray())
                    i.Draw(spriteBatch);
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
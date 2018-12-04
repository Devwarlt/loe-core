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
        public bool IsZeroApplicaple = false;

        public int Index { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public float X { get; set; }
        public float Y { get; set; }
        public float StageX => (ParentSprite != null && !IsZeroApplicaple) ? ParentSprite.StageX + X : X;
        public float StageY => (ParentSprite != null && !IsZeroApplicaple) ? ParentSprite.StageY + Y : Y;
        public int SpriteLevel => ParentSprite != null ? ParentSprite.SpriteLevel + 1 : 0;

        public HashSet<SpriteNode> ChildList { get; set; }
        public Dictionary<Event, EventHandler> EventDictionary { get; set; }

        public Rectangle SpriteRectangle => new Rectangle((int)StageX, (int)StageY, Width, Height);
        public SpriteNode ParentSprite { get; set; }

        protected EventsHandler EventsHandler;

        #region Constructors
        public SpriteNode(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Index = 0;

            ChildList = new HashSet<SpriteNode>();
            EventDictionary = new Dictionary<Event, EventHandler>();
            EventsHandler = new EventsHandler();
        }

        public SpriteNode(float x, float y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Index = 0;

            ChildList = new HashSet<SpriteNode>();
            EventDictionary = new Dictionary<Event, EventHandler>();
            EventsHandler = new EventsHandler();
        }
        #endregion Constructors

        public bool IsEventApplicable { get; set; } = true;

        public virtual void Update(GameTime gameTime)
        {
            foreach (var i in ChildList.OrderBy(_ => _.Index).Reverse())
                i.Update(gameTime);

            if (IsEventApplicable)
                EventsManager.TrySet(this);

            foreach(var i in EventDictionary.Where(_ => EventsHandler.HandleMouse(this, _.Key)))
                if (i.Key == Event.CLICKOUTLEFT|| i.Key == Event.MOUSEOVER 
                    || i.Key == Event.MOUSEOUT || EventsManager.IsValid(this))
                    i.Value?.Invoke(this, new EventArgs());
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (Visible)
                foreach (var i in ChildList.OrderBy(_ => _.Index))
                    i.Draw(spriteBatch);
        }

        #region "Child events"

        public void AddChild(SpriteNode child)
        {
            child.ParentSprite = this;
            child.Index = ChildList.Count + 1;
            ChildList.Add(child);
        }

        public void RemoveChild(SpriteNode child) => ChildList.RemoveWhere(_ => _ == child);

        public bool Contains(SpriteNode child) => ChildList.Contains(child);
        public bool Contains(int index) => (ChildList.Where(_ => _.Index == index).FirstOrDefault() != null);

        public void RemoveLastChild()=> ChildList.Remove(ChildList.Last());
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
using LoESoft.Client.Drawing.Events;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

        public bool IsZeroApplicaple = false;

        public int X { get; set; }
        public int Y { get; set; }
        public int StageX
        {
            get { return (ParentSprite != null && !IsZeroApplicaple) ? ParentSprite.StageX + X : X; }
        }
        public int StageY
        {
            get { return (ParentSprite != null && !IsZeroApplicaple) ? ParentSprite.StageY + Y : Y; }
        }

        public int Width { get; set; }
        public int Height { get; set; }

        public int Index { get; set; }

        public bool Visible = true;

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
        public bool IsInvoked = false;

        public virtual void Update(GameTime gameTime)
        {
            for (var i = (ChildList.ToArray().Length - 1); i >= 0; i--)
                ChildList[i].Update(gameTime);


            foreach (var i in EventDictionary)
                if (_eventsHandler.HandleMouse(this, i.Key) && !EventsManager.IsEventActive)
                {
                    EventsManager.IsEventActive = true;
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

        #region ChildEvents
        public void AddChild(SpriteNode child)
        {
            child.ParentSprite = this;
            child.Index = ChildList.Count;
            ChildList.Add(child);
        }

        public void RemoveChild(SpriteNode child)
        {
            ChildList.Remove(child);
        }

        public void RemoveAllChild()
        {
            ChildList.Clear();
        }
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

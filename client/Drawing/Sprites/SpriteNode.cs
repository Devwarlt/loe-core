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

        public List<SpriteNode> ChildList { get; set; } = new List<SpriteNode>();
        public Dictionary<Event, EventHandler> EventDictionary { get; set; } = new Dictionary<Event, EventHandler>();
        public SpriteNode ParentSprite { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public int StageX => (ParentSprite != null && !IsZeroApplicaple) ? ParentSprite.StageX + X : X;
        public int StageY => (ParentSprite != null && !IsZeroApplicaple) ? ParentSprite.StageY + Y : Y;
        public Rectangle SpriteRectangle => new Rectangle(StageX, StageY, Width, Height);
        public int SpriteLevel => ParentSprite != null ? ParentSprite.SpriteLevel + 1 : 0;
 
        public SpriteNode(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (var i in ChildList.OrderBy(_ => _.Index).Reverse().ToArray())
                i.Update(gameTime);

            foreach (var i in EventDictionary)
                if (EventsHandler.HandleMouse(this, i.Key))
                    i.Value?.Invoke(this, new EventArgs());
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
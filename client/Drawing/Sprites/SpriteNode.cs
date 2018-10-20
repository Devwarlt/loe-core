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
        public SpriteNode ParentSprite { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public List<EventListener> Events { get; set; } // new event listener method
        public EventHandler<MouseEvent> OnClick { get; set; } // handle click events

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
            Events = new List<EventListener>();
            OnClick = new EventHandler<MouseEvent>() += delegate(object sender, MouseEvent e) { Events.FirstOrDefault(_ => _.MouseEvent == e)?.Invoke(); };
        }

        public virtual void Update(GameTime gameTime)
        {
            ChildList.OrderBy(_ => _.Index).Reverse().Select(_ => { _?.Update(gameTime); return _; }).ToList();
            // if (EventsHandler.HandleMouse(this ))

            EventDictionary.Select(_ => { if (EventsHandler.HandleMouse(this, _.Key)) _.Value?.Invoke(this, new EventArgs()); return _; }).ToList();
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

        public void AddEventListener(MouseEvent e, Action action)
        {
            if (Events.FirstOrDefault(_ => _.MouseEvent != e) == null) Events.Add(new EventListener(e, action));
            else Events.FirstOrDefault(_ => _.MouseEvent == e) = new EventListener(e, action); // overrided method if already declared
        }

        public void RemoveEventListener(MouseEvent e)
            => Events.FirstOrDefault(_ => _.MouseEvent == e)?.Select(_ => { Events.Remove(_); return _; }).ToList();

        public void RemoveAllEvents() => Events.Clear();

        #endregion Event listener
    }
}
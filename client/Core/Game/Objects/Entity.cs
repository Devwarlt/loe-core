﻿using LoESoft.Client.Assets;
using LoESoft.Client.Assets.Xml.Structure;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace LoESoft.Client.Core.Game.Objects
{
    public class Entity
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float DrawX => X * 8;
        public float DrawY => Y * 8;

        public int Size = 8;
        public int ObjectId { get; set; }
        public int UniqueId { get; set; }

        public Texture2D Texture { get; set; }
        public ObjectsContent Content { get; set; }
        public Color Color;

        public Entity(int id)
        {
            ObjectId = id;
            Content = XmlLibrary.ObjectsXml[ObjectId];
        }
        
        public virtual void Update(GameTime gameTime)
        {
            HandleMovement(1f / gameTime.ElapsedGameTime.Milliseconds);
        }

        public bool IsMoving
        {
            get { return (X != DistinationX || Y != DistinationY); }
        }

        public int DistinationX { get; set; }
        public int DistinationY { get; set; }

        public void HandleMovement(float dt)
        {
            if (DistinationX != X)
            {
                if (DistinationX > X)
                    X += dt;
                else if (DistinationX < X)
                    X -= dt;
            }
            if (DistinationY != Y)
            {
                if (DistinationY > Y)
                    Y += dt;
                else if (DistinationY < Y)
                    Y -= dt;
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch) => spriteBatch.DrawRectangle(new Rectangle((int) DrawX, (int) DrawY, Size, Size), Color, 4);
    }
}
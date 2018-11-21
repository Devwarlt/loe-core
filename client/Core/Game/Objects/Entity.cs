using LoESoft.Client.Assets.Xml;
using LoESoft.Client.Assets.Xml.Structure;
using LoESoft.Client.Core.Game.Objects.Stats;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LoESoft.Client.Core.Game.Objects
{
    public class Entity
    {
        public int DistinationX { get; set; }
        public int DistinationY { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float DrawX => X * 8;
        public float DrawY => Y * 8;

        public bool IsMoving
        {
            get { return (X != DistinationX || Y != DistinationY); }
        }

        public Texture2D Texture { get; set; }
        public ObjectsContent Content { get; set; }
        public Color Color { get; set; }
        public int Id { get; set; }
        public int ObjectId { get; set; }

        //Stats
        public int Size = 8;

        public int Health { get; set; }

        public Entity(int id)
        {
            Id = id;
            if (Id != -1)
                Content = XmlLibrary.ObjectsXml[Id];
        }

        public virtual void Update(GameTime gameTime)
        {
            HandleMovement(1f / gameTime.ElapsedGameTime.Milliseconds);
        }

        public virtual void ImportStat(string export)
        {
            var stats = JsonConvert.DeserializeObject<List<string>>(export);

            foreach (var i in stats)
            {
                var stat = JsonConvert.DeserializeObject<Stat>(i);
                ChangeStat(stat.StatType, stat.Value);
            }
        }

        private void ChangeStat(int type, object value)
        {
            var val = value.ToString();
            switch (type)
            {
                case StatType.HEALTH: Health = int.Parse(val); return;
                case StatType.SIZE: Size = int.Parse(val); return;
            }
        }

        public virtual void HandleMovement(float dt)
        {
            //TODO: Pathfinding
            if (DistinationX != X)
            {
                if (DistinationX > X)
                    X += dt;
                else if (DistinationX < X)
                    X -= dt;
            }
            else if (DistinationY != Y)
            {
                if (DistinationY > Y)
                    Y += dt;
                else if (DistinationY < Y)
                    Y -= dt;
            }
        }

        public virtual void SetDistination(int x, int y)
        {
            DistinationX = x;
            DistinationY = y;
        }

        public virtual void Draw(SpriteBatch spriteBatch) => spriteBatch.DrawRectangle(new Rectangle((int)DrawX, (int)DrawY, Size, Size), Color, 4);
    }
}
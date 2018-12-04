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
    public class GameObject
    {
        public int DistinationX { get; set; }
        public int DistinationY { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float DrawX => X * 8;
        public float DrawY => Y * 8;

        public bool IsMoving
        {
            get { return X != DistinationX || Y != DistinationY; }
        }
        
        public ObjectsContent Content { get; set; }
        public Color Color { get; set; }
        public Texture2D Texture { get; set; }

        public int Id { get; set; }
        public int ObjectId { get; set; }

        //Stats
        public int Size { get; set; }

        public GameObject(int id)
        {
            Id = id;
            if (Id != -1)
                Content = XmlLibrary.ObjectsXml[Id];
            Size = 8;
        }

        public virtual void Init()
        {
            Texture = XmlLibrary.GetSpriteFromContent(Content);
        }

        public virtual void Update(GameTime gameTime)
        {
            HandleMovement(1f / gameTime.ElapsedGameTime.Milliseconds);
        }

        public virtual void ImportStat(string export)
        {
            var stats = JsonConvert.DeserializeObject<IEnumerable<KeyValuePair<int, object>>>(export);

            foreach (var i in stats)
                ChangeStat(i.Key, i.Value);
        }

        public virtual void ChangeStat(int type, object value)
        {
            switch (type)
            {
                case StatType.SIZE: Size = int.Parse(value.ToString()); break;
            }
        }

        public virtual void HandleMovement(float dt)
        {
            if (DistinationY != Y)
            {
                if (DistinationY > Y)
                    Y += dt;
                else if (DistinationY < Y)
                    Y -= dt;
            }
            else if (DistinationX != X)
            {
                if (DistinationX > X)
                    X += dt;
                else if (DistinationX < X)
                    X -= dt;
            }
        }

        public virtual void SetDistination(int x, int y)
        {
            DistinationX = x;
            DistinationY = y;
        }

        public virtual void Draw(SpriteBatch spriteBatch) => spriteBatch.Draw(Texture, new Rectangle((int)DrawX, (int)DrawY, Size, Size), Color.White);
    }
}
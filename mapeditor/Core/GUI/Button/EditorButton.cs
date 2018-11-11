using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LoESoft.MapEditor.Core.GUI.Button
{
    public abstract class EditorButton
    {
        public bool Clicked { get; set; }
        public bool PreviousClicked { get; set; }
        public Vector2 Position { get; set; }

        protected bool _hover { get; set; }
        protected Texture2D _texture { get; set; }
        protected Rectangle _collisionRectangle { get; set; }

        public EditorButton(Texture2D texture, Vector2 position)
        {
            _texture = texture;

            Position = position;
        }

        public virtual void Update()
        {
            _collisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);

            var mouse = Mouse.GetState();
            var mouseposition = new Rectangle(mouse.X, mouse.Y, 1, 1);

            _hover = mouseposition.Intersects(_collisionRectangle);

            Clicked = mouseposition.Intersects(_collisionRectangle) && mouse.LeftButton == ButtonState.Pressed && !PreviousClicked;
            PreviousClicked = Clicked || PreviousClicked;
        }

        public virtual void Effect()
        {
        }

        public void Draw()
        {
            if (_hover)
            {
                MapEditor.SpriteBatch.Draw(_texture, Position, Color.White);
                MapEditor.SpriteBatch.Draw(_texture, Position, new Color(0xff, 0, 0, 180));
            }
            else
                MapEditor.SpriteBatch.Draw(_texture, Position, Color.White);
        }
    }
}
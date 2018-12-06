using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Sprites.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Concurrent;
using System.Timers;

namespace LoESoft.Client.Core.Screens
{
    public class LoadingScreen : Screen
    {
        private string _loadingText;

        public string LoadingText
        {
            get => _loadingText;
            set
            {
                _loadingText = value;

                var bounds = TextDisplay.MeasureString(value, 16);

                var x = DrawHelper.CenteredPosition(GameApplication.WIDTH, (int)bounds.X);
                var y = DrawHelper.CenteredPosition(GameApplication.HEIGHT, (int)bounds.Y);

                Display = new TextDisplay(x, y, value, 16, new RGBColor(255, 255, 255));
            }
        }

        public int TotalLoadCount { get; set; }
        
        protected bool StaticLoadingText { get; set; }

        public TextDisplay Display { get; set; }

        public ConcurrentQueue<Action> LoadFunctions { get; set; }
        public Screen ToLoadScreen { get; set; }

        public LoadingScreen(ConcurrentQueue<Action> toDo, Screen changeScreen, string initText = "", bool staticText = false)
        {
            TotalLoadCount = toDo.Count;
            LoadingText = initText;
            LoadFunctions = toDo;
            ToLoadScreen = changeScreen;
            StaticLoadingText = staticText;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.FillRectangle(new RectangleF(0, 0, GameApplication.WIDTH, GameApplication.HEIGHT), Color.Black);
            Display.Draw(spriteBatch);
            spriteBatch.End();
        }

        private int _amount;

        protected int Amount
        {
            get => _amount;
            set
            {
                if (!StaticLoadingText)
                    LoadingText = $"Loading:[{value}/{TotalLoadCount}]";
                
                _amount = value;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (LoadFunctions.Count > 0)
            {
                if (LoadFunctions.TryDequeue(out var action))
                {
                    action?.Invoke();
                    Amount++;
                }
            }
            else if (ToLoadScreen != null)
                ScreenManager.DispatchScreen(ToLoadScreen);
        }

        public override void OnScreenCreate()
        {
        }

        public override void OnScreenDispatch()
        {
        }
    }
}
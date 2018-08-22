using LoESoft.Client.Core.game.screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LoESoft.Client.Core.game
{
    public enum ScreenType : int
    {
        TitleScreen = 0,
        WorldScreen = 1
    }

    public interface IScreen
    {
        ScreenType ScreenType { get; }

        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
    public static class ScreenManager
    {
        public static List<IScreen> Screens { get; private set; }

        public static int CurrentScreenType { get; private set; }

        public static void Init()
        {
            CurrentScreenType = 0;

            Screens = new List<IScreen>()
            {
                new TitleScreen(),
                new WorldScreen()
            };
        }

        public static void Update(GameTime gameTime)
        {
            Screens[CurrentScreenType].Update(gameTime);
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            Screens[CurrentScreenType].Draw(spriteBatch);
        }

        public static void ChangeScreen(ScreenType type) => CurrentScreenType = (int)type;

        private static Action onGameClose;
        public static void CloseGame() => onGameClose?.Invoke();

        public static event Action OnGameClose
        {
            add { onGameClose += value; }
            remove { onGameClose -= value; }
        }
    }
}

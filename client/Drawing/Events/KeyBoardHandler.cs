using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace LoESoft.Client.Drawing.Events
{
    public class KeyBoardHandler
    {
        public struct LoEKey
        {
            public int MsKeyHold { get; set; }
            public Keys Key { get; set; }
            public Action Event { get; set; }

            public void Handle(GameTime gameTime, KeyboardState oldState, KeyboardState newState)
            {
                if (oldState.IsKeyDown(Key))
                {
                    if (newState.IsKeyUp(Key))
                    {
                        Event?.Invoke();
                        MsKeyHold = 0;
                        return;
                    }

                    MsKeyHold += gameTime.TotalGameTime.Milliseconds;

                    if (MsKeyHold > 1000)
                        Event?.Invoke();
                }
            }
        }

        public List<LoEKey> BindedKeys { get; set; }

        public KeyBoardHandler()
        {
            BindedKeys = new List<LoEKey>();
        }

        public void BindKey(LoEKey key) => BindedKeys.Add(key);

        public void UnBindKey(LoEKey key) => BindedKeys.Remove(key);

        public bool Contains(LoEKey key) => BindedKeys.Contains(key);

        public bool ContainsKey(Keys key) => BindedKeys.Exists(_ => _.Key == key);

        private KeyboardState _newState;
        private KeyboardState _oldState;

        public void Update(GameTime gameTime)
        {
            _oldState = _newState;
            _newState = Keyboard.GetState();

            foreach (var i in BindedKeys)
                i.Handle(gameTime, _oldState, _newState);
        }
    }
}
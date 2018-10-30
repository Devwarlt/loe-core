using LoESoft.Client.Drawing.Sprites.Forms.Complex;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LoESoft.Client.Drawing.Events
{
    public partial class EventsHandler
    {
        protected List<char> GetPressedKeys()
        {
            var oldPressedKeys = previousKeyBoard.GetPressedKeys();
            var keys = new List<char>();

            for (var i = 0; i < oldPressedKeys.Length; i++)
            {
                if (currentKeyBoard.IsKeyUp(oldPressedKeys[i]) && previousKeyBoard.IsKeyDown(oldPressedKeys[i]))
                {
                    var key = oldPressedKeys[i];
                    if (key.ToString().Length <= 2 || TextBox.ValidKeys.Contains(key))
                        keys.Add(KeysToChar(key, DetectCaps));
                }
            }

            return keys;
        }

        protected bool DetectCaps
            => currentKeyBoard.CapsLock
            || (previousKeyBoard.IsKeyDown(Keys.LeftShift) && currentKeyBoard.IsKeyDown(Keys.LeftShift))
            || (previousKeyBoard.IsKeyDown(Keys.RightShift) && currentKeyBoard.IsKeyDown(Keys.RightShift));

        #region "Keys table"

        private readonly Dictionary<Keys, KeyValuePair<char, char>> _keysTable = new Dictionary<Keys, KeyValuePair<char, char>>()
        {
            { Keys.A, new KeyValuePair<char, char>('a', 'A') },
            { Keys.B, new KeyValuePair<char, char>('b', 'B') },
            { Keys.C, new KeyValuePair<char, char>('c', 'C') },
            { Keys.D, new KeyValuePair<char, char>('d', 'D') },
            { Keys.E, new KeyValuePair<char, char>('e', 'E') },
            { Keys.F, new KeyValuePair<char, char>('f', 'F') },
            { Keys.G, new KeyValuePair<char, char>('g', 'G') },
            { Keys.H, new KeyValuePair<char, char>('h', 'H') },
            { Keys.I, new KeyValuePair<char, char>('i', 'I') },
            { Keys.J, new KeyValuePair<char, char>('j', 'J') },
            { Keys.K, new KeyValuePair<char, char>('k', 'K') },
            { Keys.L, new KeyValuePair<char, char>('l', 'L') },
            { Keys.M, new KeyValuePair<char, char>('m', 'M') },
            { Keys.N, new KeyValuePair<char, char>('n', 'N') },
            { Keys.O, new KeyValuePair<char, char>('o', 'O') },
            { Keys.P, new KeyValuePair<char, char>('p', 'P') },
            { Keys.Q, new KeyValuePair<char, char>('q', 'Q') },
            { Keys.R, new KeyValuePair<char, char>('r', 'R') },
            { Keys.S, new KeyValuePair<char, char>('s', 'S') },
            { Keys.T, new KeyValuePair<char, char>('t', 'T') },
            { Keys.U, new KeyValuePair<char, char>('u', 'U') },
            { Keys.V, new KeyValuePair<char, char>('v', 'V') },
            { Keys.W, new KeyValuePair<char, char>('w', 'W') },
            { Keys.X, new KeyValuePair<char, char>('x', 'X') },
            { Keys.Y, new KeyValuePair<char, char>('y', 'Y') },
            { Keys.Z, new KeyValuePair<char, char>('z', 'Z') },
            { Keys.D0, new KeyValuePair<char, char>('0', ')') },
            { Keys.D1, new KeyValuePair<char, char>('1', '!') },
            { Keys.D2, new KeyValuePair<char, char>('2', '@') },
            { Keys.D3, new KeyValuePair<char, char>('3', '#') },
            { Keys.D4, new KeyValuePair<char, char>('4', '$') },
            { Keys.D5, new KeyValuePair<char, char>('5', '%') },
            { Keys.D6, new KeyValuePair<char, char>('6', '^') },
            { Keys.D7, new KeyValuePair<char, char>('7', '&') },
            { Keys.D8, new KeyValuePair<char, char>('8', '*') },
            { Keys.D9, new KeyValuePair<char, char>('9', '(') },
            { Keys.NumPad0, new KeyValuePair<char, char>('0', '0') },
            { Keys.NumPad1, new KeyValuePair<char, char>('1', '1') },
            { Keys.NumPad2, new KeyValuePair<char, char>('2', '2') },
            { Keys.NumPad3, new KeyValuePair<char, char>('3', '3') },
            { Keys.NumPad4, new KeyValuePair<char, char>('4', '4') },
            { Keys.NumPad5, new KeyValuePair<char, char>('5', '5') },
            { Keys.NumPad6, new KeyValuePair<char, char>('6', '6') },
            { Keys.NumPad7, new KeyValuePair<char, char>('7', '7') },
            { Keys.NumPad8, new KeyValuePair<char, char>('8', '8') },
            { Keys.NumPad9, new KeyValuePair<char, char>('9', '9') },
            { Keys.OemTilde, new KeyValuePair<char, char>('`', '~') },
            { Keys.OemSemicolon, new KeyValuePair<char, char>(';', ':') },
            { Keys.OemQuotes, new KeyValuePair<char, char>('\'', '"') },
            { Keys.OemQuestion, new KeyValuePair<char, char>('/', '?') },
            { Keys.OemPlus, new KeyValuePair<char, char>('=', '+') },
            { Keys.OemPipe, new KeyValuePair<char, char>('\\', '|') },
            { Keys.OemPeriod, new KeyValuePair<char, char>('.', '>') },
            { Keys.OemOpenBrackets, new KeyValuePair<char, char>('[', '{') },
            { Keys.OemCloseBrackets, new KeyValuePair<char, char>(']', '}') },
            { Keys.OemMinus, new KeyValuePair<char, char>('-', '_') },
            { Keys.OemComma, new KeyValuePair<char, char>(',', '<') },
            { Keys.Space, new KeyValuePair<char, char>(' ', ' ') }
        };

        #endregion "Keys table"

        public char KeysToChar(Keys key, bool shift)
            => _keysTable.TryGetValue(key, out KeyValuePair<char, char> data) ? shift ? data.Value : data.Key : '\0';
    }
}
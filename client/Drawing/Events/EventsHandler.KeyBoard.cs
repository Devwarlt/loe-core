using LoESoft.Client.Drawing.Sprites.Forms.Complex;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LoESoft.Client.Drawing.Events
{
    public partial class EventsHandler
    {
        protected List<char> GetPressedKeys()
        {
            List<KeyValuePair<bool, Keys>> pressedKeys = new List<KeyValuePair<bool, Keys>>();

            Keys[] oldPressedKeys = previousKeyBoard.GetPressedKeys();

            for (var i = 0; i < oldPressedKeys.Length; i++)
                if (currentKeyBoard.IsKeyUp(oldPressedKeys[i]))
                    pressedKeys.Add(new KeyValuePair<bool, Keys>((DetectCaps()), oldPressedKeys[i]));

            List<char> keys = new List<char>();

            foreach (var i in pressedKeys)
                if (i.Value.ToString().Length <= 2 || TextBox.ValidKeys.Contains(i.Value))
                    keys.Add(KeysToChar(i.Value, i.Key));

            return keys;
        }

        protected bool DetectCaps()
        {
            if (currentKeyBoard.CapsLock || ((previousKeyBoard.IsKeyDown(Keys.LeftShift)
                && currentKeyBoard.IsKeyDown(Keys.LeftShift)) ||
                (previousKeyBoard.IsKeyDown(Keys.RightShift) && currentKeyBoard.IsKeyDown(Keys.RightShift))))
                return true;

            return false;
        }

        //protected List<char> GetPressedKeysHoldable()
        //{

        //}
        #region KeysTable
        public char KeysToChar(Keys key, bool shift)
        {
            switch (key)
            {
                case Keys.A: if (shift) { return 'A'; } else { return 'a'; }
                case Keys.B: if (shift) { return 'B'; } else { return 'b'; }
                case Keys.C: if (shift) { return 'C'; } else { return 'c'; }
                case Keys.D: if (shift) { return 'D'; } else { return 'd'; }
                case Keys.E: if (shift) { return 'E'; } else { return 'e'; }
                case Keys.F: if (shift) { return 'F'; } else { return 'f'; }
                case Keys.G: if (shift) { return 'G'; } else { return 'g'; }
                case Keys.H: if (shift) { return 'H'; } else { return 'h'; }
                case Keys.I: if (shift) { return 'I'; } else { return 'i'; }
                case Keys.J: if (shift) { return 'J'; } else { return 'j'; }
                case Keys.K: if (shift) { return 'K'; } else { return 'k'; }
                case Keys.L: if (shift) { return 'L'; } else { return 'l'; }
                case Keys.M: if (shift) { return 'M'; } else { return 'm'; }
                case Keys.N: if (shift) { return 'N'; } else { return 'n'; }
                case Keys.O: if (shift) { return 'O'; } else { return 'o'; }
                case Keys.P: if (shift) { return 'P'; } else { return 'p'; }
                case Keys.Q: if (shift) { return 'Q'; } else { return 'q'; }
                case Keys.R: if (shift) { return 'R'; } else { return 'r'; }
                case Keys.S: if (shift) { return 'S'; } else { return 's'; }
                case Keys.T: if (shift) { return 'T'; } else { return 't'; }
                case Keys.U: if (shift) { return 'U'; } else { return 'u'; }
                case Keys.V: if (shift) { return 'V'; } else { return 'v'; }
                case Keys.W: if (shift) { return 'W'; } else { return 'w'; }
                case Keys.X: if (shift) { return 'X'; } else { return 'x'; }
                case Keys.Y: if (shift) { return 'Y'; } else { return 'y'; }
                case Keys.Z: if (shift) { return 'Z'; } else { return 'z'; }

                //Decimal keys
                case Keys.D0: if (shift) { return ')'; } else { return '0'; }
                case Keys.D1: if (shift) { return '!'; } else { return '1'; }
                case Keys.D2: if (shift) { return '@'; } else { return '2'; }
                case Keys.D3: if (shift) { return '#'; } else { return '3'; }
                case Keys.D4: if (shift) { return '$'; } else { return '4'; }
                case Keys.D5: if (shift) { return '%'; } else { return '5'; }
                case Keys.D6: if (shift) { return '^'; } else { return '6'; }
                case Keys.D7: if (shift) { return '&'; } else { return '7'; }
                case Keys.D8: if (shift) { return '*'; } else { return '8'; }
                case Keys.D9: if (shift) { return '('; } else { return '9'; }

                //Decimal numpad keys
                case Keys.NumPad0: return '0';
                case Keys.NumPad1: return '1';
                case Keys.NumPad2: return '2';
                case Keys.NumPad3: return '3';
                case Keys.NumPad4: return '4';
                case Keys.NumPad5: return '5';
                case Keys.NumPad6: return '6';
                case Keys.NumPad7: return '7';
                case Keys.NumPad8: return '8';
                case Keys.NumPad9: return '9';

                //Special keys
                case Keys.OemTilde: if (shift) { return '~'; } else { return '`'; }
                case Keys.OemSemicolon: if (shift) { return ':'; } else { return ';'; }
                case Keys.OemQuotes: if (shift) { return '"'; } else { return '\''; }
                case Keys.OemQuestion: if (shift) { return '?'; } else { return '/'; }
                case Keys.OemPlus: if (shift) { return '+'; } else { return '='; }
                case Keys.OemPipe: if (shift) { return '|'; } else { return '\\'; }
                case Keys.OemPeriod: if (shift) { return '>'; } else { return '.'; }
                case Keys.OemOpenBrackets: if (shift) { return '{'; } else { return '['; }
                case Keys.OemCloseBrackets: if (shift) { return '}'; } else { return ']'; }
                case Keys.OemMinus: if (shift) { return '_'; } else { return '-'; }
                case Keys.OemComma: if (shift) { return '<'; } else { return ','; }
                case Keys.Space: return ' ';
            }
            return '\0';
        }
        #endregion
    }
}

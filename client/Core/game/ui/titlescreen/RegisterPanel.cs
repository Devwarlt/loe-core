using LoESoft.Client.Drawing.Sprites.Forms;
using LoESoft.Client.Drawing.Sprites.Forms.Complex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoESoft.Client.Core.game.ui.titlescreen
{
    class RegisterPanel : Panel
    {
        TextBox mailTextBox;
        
        public RegisterPanel(int x, int y)
            : base(x, y, "Login", color: new Drawing.RGBColor(85, 85, 88))
        {
            mailTextBox = new TextBox(10, 30);

            AddChild(mailTextBox);
        }
    }
}

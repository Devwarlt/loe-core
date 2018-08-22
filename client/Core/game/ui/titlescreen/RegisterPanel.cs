using LoESoft.Client.Drawing.Events;
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
        TextBox userTextBox;
        TextBox passTextBox;
        
        public RegisterPanel(int x, int y)
            : base(x, y, "Register", color: new Drawing.RGBColor(85, 85, 88))
        {
            mailTextBox = new TextBox(10, 50, 380, "Email:");
            userTextBox = new TextBox(10, 100, 380, "Name:");
            passTextBox = new TextBox(10, 150, 380, "Password:", encoded: true);

            AddChild(mailTextBox);
            AddChild(userTextBox);
            AddChild(passTextBox);

            AddEventListener(Event.CLICKLEFT, onClick);
            mailTextBox.AddEventListener(Event.CLICKLEFT, onMailClick);
            userTextBox.AddEventListener(Event.CLICKLEFT, onUserClick);
            passTextBox.AddEventListener(Event.CLICKLEFT, onPassClick);
        }

        private void onPassClick(object sender, EventArgs e)
        {
            mailTextBox.Selected = false;
            userTextBox.Selected = false;
            passTextBox.Selected = true;
        }

        private void onUserClick(object sender, EventArgs e)
        {
            mailTextBox.Selected = false;
            userTextBox.Selected = true;
            passTextBox.Selected = false;
        }

        private void onMailClick(object sender, EventArgs e)
        {
            mailTextBox.Selected = true;
            userTextBox.Selected = false;
            passTextBox.Selected = false;
        }

        private void onClick(object sender, EventArgs e)
        {
            mailTextBox.Selected = false;
            userTextBox.Selected = false;
            passTextBox.Selected = false;
        }
    }
}

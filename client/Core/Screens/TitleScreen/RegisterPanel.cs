using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Events;
using LoESoft.Client.Drawing.Sprites.Forms;
using LoESoft.Client.Drawing.Sprites.Forms.Complex;
using System;

namespace LoESoft.Client.Core.Screens
{
    class RegisterPanel : Panel
    {
        TextBox mailTextBox;
        TextBox userTextBox;
        TextBox passTextBox;

        Button btnRegister;

        public RegisterPanel(int x, int y)
            : base(x, y, "Register", color: new RGBColor(85, 85, 88), height: 250)
        {
            mailTextBox = new TextBox(10, 50, 380, "Email:");
            userTextBox = new TextBox(10, 100, 380, "Name:");
            passTextBox = new TextBox(10, 150, 380, "Password:", encoded: true);

            btnRegister = new Button(0, 190, "Register", new RGBColor(255, 0, 0));
            btnRegister.X = (Width / 2 - btnRegister.Width / 2);

            AddChild(mailTextBox);
            AddChild(userTextBox);
            AddChild(passTextBox);
            AddChild(btnRegister);

            AddEventListener(Event.CLICKLEFT, onClick);
            mailTextBox.AddEventListener(Event.CLICKLEFT, onMailClick);
            userTextBox.AddEventListener(Event.CLICKLEFT, onUserClick);
            passTextBox.AddEventListener(Event.CLICKLEFT, onPassClick);
            btnRegister.AddEventListener(Event.CLICKLEFT, onRegister);
            _exitBtn.Exit += OnExit;
        }

        private void onRegister(object sender, EventArgs e)
        {
            GameClient._log.Info($"Mail: {mailTextBox.Text.ToString()},Username: {userTextBox.Text.ToString()}, Password: {passTextBox.Text.ToString()}");
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

        public override void OnExit()
        {
            base.OnExit();
            mailTextBox.Clear();
            userTextBox.Clear();
            passTextBox.Clear();
            mailTextBox.Selected = false;
            userTextBox.Selected = false;
            passTextBox.Selected = false;
        }
    }
}

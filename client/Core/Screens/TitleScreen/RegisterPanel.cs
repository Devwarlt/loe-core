using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Events;
using LoESoft.Client.Drawing.Sprites.Forms;
using LoESoft.Client.Drawing.Sprites.Forms.Complex;
using System;

namespace LoESoft.Client.Core.Screens
{
    internal class RegisterPanel : Panel
    {
        private TextBox mailTextBox;
        private TextBox userTextBox;
        private TextBox passTextBox;

        private Button btnRegister;

        public RegisterPanel(int x, int y)
            : base(x, y, "Register", color: new RGBColor(85, 85, 88), height: 250)
        {
            mailTextBox = new TextBox(10, 50, 380, "Email:");
            userTextBox = new TextBox(10, 100, 380, "Name:");
            passTextBox = new TextBox(10, 150, 380, "Password:", encoded: true);

            btnRegister = new Button(0, 190, "Register", new RGBColor(255, 0, 0));
            btnRegister.X = (Width / 2) - (btnRegister.Width / 2);

            AddChild(mailTextBox);
            AddChild(userTextBox);
            AddChild(passTextBox);
            AddChild(btnRegister);

            mailTextBox.AddEventListener(Event.CLICKLEFT, OnMailClick);
            userTextBox.AddEventListener(Event.CLICKLEFT, OnUserClick);
            passTextBox.AddEventListener(Event.CLICKLEFT, OnPassClick);
            btnRegister.AddEventListener(Event.CLICKLEFT, OnRegister);

            AddEventListener(Event.CLICKLEFT, OnClick);
        }

        private void OnRegister(object sender, EventArgs e)
        {
            GameClient.Info($"Mail: {mailTextBox.Text.ToString()},Username: {userTextBox.Text.ToString()}, Password: {passTextBox.Text.ToString()}");
        }

        private void OnPassClick(object sender, EventArgs e)
        {
            mailTextBox.Selected = false;
            userTextBox.Selected = false;
            passTextBox.Selected = true;
        }

        private void OnUserClick(object sender, EventArgs e)
        {
            mailTextBox.Selected = false;
            userTextBox.Selected = true;
            passTextBox.Selected = false;
        }

        private void OnMailClick(object sender, EventArgs e)
        {
            mailTextBox.Selected = true;
            userTextBox.Selected = false;
            passTextBox.Selected = false;
        }

        private void OnClick(object sender, EventArgs e)
        {
            mailTextBox.Selected = false;
            userTextBox.Selected = false;
            passTextBox.Selected = false;
        }

        public override void OnExit()
        {
            mailTextBox.Clear();
            userTextBox.Clear();
            passTextBox.Clear();
            mailTextBox.Selected = false;
            userTextBox.Selected = false;
            passTextBox.Selected = false;
        }
    }
}
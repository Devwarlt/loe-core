using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Events;
using LoESoft.Client.Drawing.Sprites.Forms;
using LoESoft.Client.Drawing.Sprites.Forms.Complex;
using System;

namespace LoESoft.Client.Core.Screens
{
    public class LoginPanel : Panel
    {
        private TextBox mailTextBox;
        private TextBox passTextBox;
        private Button btnLogin;

        public LoginPanel(int x, int y)
            : base(x, y, "Login", color: new RGBColor(85, 85, 88), height: 200)
        {
            mailTextBox = new TextBox(10, 50, 380, "Email:");
            passTextBox = new TextBox(10, 100, 380, "Password:", encoded: true);

            btnLogin = new Button(0, 140, "Login", new RGBColor(255, 0, 0));
            btnLogin.X = (Width / 2) - (btnLogin.Width / 2);

            mailTextBox.AddEventListener(Event.CLICKLEFT, OnMailClick);
            passTextBox.AddEventListener(Event.CLICKLEFT, OnPassClick);
            btnLogin.AddEventListener(Event.CLICKLEFT, OnLogin);
            AddEventListener(Event.CLICKLEFT, OnClick);

            AddChild(mailTextBox);
            AddChild(passTextBox);
            AddChild(btnLogin);
        }

        public override void OnExit()
        {
            mailTextBox.Selected = false;
            passTextBox.Selected = false;
            mailTextBox.Clear();
            passTextBox.Clear();
        }

        private void OnLogin(object sender, EventArgs e)
            => GameClient.Info($"Mail: {mailTextBox.Text.ToString()}, Password: {passTextBox.Text.ToString()}");

        private void OnClick(object sender, EventArgs e)
        {
            mailTextBox.Selected = false;
            passTextBox.Selected = false;
        }

        private void OnPassClick(object sender, EventArgs e)
        {
            mailTextBox.Selected = false;
            passTextBox.Selected = true;
        }

        private void OnMailClick(object sender, EventArgs e)
        {
            mailTextBox.Selected = true;
            passTextBox.Selected = false;
        }
    }
}
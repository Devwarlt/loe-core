﻿using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Events;
using LoESoft.Client.Drawing.Sprites.Forms;
using LoESoft.Client.Drawing.Sprites.Forms.Complex;
using System;

namespace LoESoft.Client.Core.game.ui.titlescreen
{
    class LoginPanel : Panel
    {
        TextBox mailTextBox;
        TextBox passTextBox;

        Button btnLogin;

        public LoginPanel(int x, int y)
            : base(x, y, "Login", color: new RGBColor(85, 85, 88), height: 200)
        {
            mailTextBox = new TextBox(10, 50, 380, "Email:");
            passTextBox = new TextBox(10, 100, 380, "Password:", encoded: true);

            btnLogin = new Button(0, 140, "Login", new RGBColor(255, 0, 0));
            btnLogin.X = (Width / 2 - btnLogin.Width / 2);

            AddEventListener(Event.CLICKLEFT, onClick);
            mailTextBox.AddEventListener(Event.CLICKLEFT, onMailClick);
            passTextBox.AddEventListener(Event.CLICKLEFT, onPassClick);
            btnLogin.AddEventListener(Event.CLICKLEFT, onLogin);
            _exitBtn.Exit += onClose;

            AddChild(mailTextBox);
            AddChild(passTextBox);
            AddChild(btnLogin);
        }

        private void onClose()
        {
            mailTextBox.Clear();
            passTextBox.Clear();
            mailTextBox.Selected = false;
            passTextBox.Selected = false;
        }

        private void onLogin(object sender, EventArgs e)
        {
            GameClient._log.Info($"Mail: {mailTextBox.Text.ToString()}, Password: {passTextBox.Text.ToString()}");
        }

        private void onClick(object sender, EventArgs e)
        {
            mailTextBox.Selected = false;
            passTextBox.Selected = false;
        }

        private void onPassClick(object sender, EventArgs e)
        {
            mailTextBox.Selected = false;
            passTextBox.Selected = true;
        }

        private void onMailClick(object sender, EventArgs e)
        {
            mailTextBox.Selected = true;
            passTextBox.Selected = false;
        }
    }
}

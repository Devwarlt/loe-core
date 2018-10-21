using LoESoft.Client.Core.Networking.Packets.Outgoing;
using LoESoft.Client.Core.Utils;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Events;
using LoESoft.Client.Drawing.Sprites.Forms;
using LoESoft.Client.Drawing.Sprites.Forms.Complex;

namespace LoESoft.Client.Core.Screens
{
    public class LoginPanel : Panel
    {
        private TextBox AccountName;
        private TextBox AccountPassword;
        private Button LoginButton;

        public LoginPanel(int x, int y)
            : base(x, y, "Login", color: new RGBColor(85, 85, 88), height: 200)
        {
            AccountName = new TextBox(10, 50, 380, "Account Name:", 16, true);
            AccountPassword = new TextBox(10, 100, 380, "Account Password:", 16, true);

            LoginButton = new Button(0, 140, "Login", new RGBColor(255, 0, 0));
            LoginButton.X = (Width / 2) - (LoginButton.Width / 2);

            AccountName.Selected = false;
            AccountPassword.Selected = false;

            AccountName.AddEventListener(Event.CLICKLEFT, (s, h) =>
            {
                AccountName.Selected = true;
                AccountPassword.Selected = false;
            });
            AccountPassword.AddEventListener(Event.CLICKLEFT, (s, h) =>
            {
                AccountName.Selected = false;
                AccountPassword.Selected = true;
            });
            LoginButton.AddEventListener(Event.CLICKLEFT, (s, h) =>
            {
                AccountName.Selected = false;
                AccountPassword.Selected = false;

                GameApplication.GameUser.SendPacket(new Login()
                {
                    Name = Cipher.Encrypt(AccountName.Text.ToString()),
                    Password = Cipher.Encrypt(AccountPassword.Text.ToString())
                });
            });

            AddChild(AccountName);
            AddChild(AccountPassword);
            AddChild(LoginButton);
        }

        public override void OnExit()
        {
            base.OnExit();

            AccountName.Selected = false;
            AccountPassword.Selected = false;
            AccountName.Clear();
            AccountPassword.Clear();
        }
    }
}
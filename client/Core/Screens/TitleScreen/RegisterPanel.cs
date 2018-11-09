using LoESoft.Client.Core.Networking.Packets.Outgoing;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Events;
using LoESoft.Client.Drawing.Sprites.Forms;
using LoESoft.Client.Drawing.Sprites.Forms.Complex;

namespace LoESoft.Client.Core.Screens
{
    public partial class RegisterPanel : Panel
    {
        private TextBox AccountName;
        private TextBox AccountPassword;
        private Button RegisterButton;

        public RegisterPanel(int x, int y)
            : base(x, y, "Register", color: new RGBColor(85, 85, 88), height: 200)
        {
            AccountName = new TextBox(10, 50, 380, "Account Name:");
            AccountPassword = new TextBox(10, 100, 380, "Account Password:");

            RegisterButton = new Button(0, 150, "Register", new RGBColor(255, 0, 0));
            RegisterButton.X = (Width / 2) - (RegisterButton.Width / 2);

            AddChild(AccountName);
            AddChild(AccountPassword);
            AddChild(RegisterButton);

            AccountName.Selected = false;
            AccountPassword.Selected = false;

            AccountName.AddEventListener(Event.CLICKLEFT, (s, h) => ToggleTextBox(TextBoxType.AccountName));
            AccountPassword.AddEventListener(Event.CLICKLEFT, (s, h) => ToggleTextBox(TextBoxType.AccountPassword));
            RegisterButton.AddEventListener(Event.CLICKLEFT, (s, h) =>
            {
                AccountName.Selected = false;
                AccountPassword.Selected = false;
            });
        }

        private void ToggleTextBox(TextBoxType textBoxType)
        {
            switch (textBoxType)
            {
                case TextBoxType.AccountName:
                    AccountName.Selected = true;
                    AccountPassword.Selected = false;
                    break;

                case TextBoxType.AccountPassword:
                    AccountName.Selected = false;
                    AccountPassword.Selected = true;
                    break;
            }
        }

        public override void OnExit()
        {
            base.OnExit();

            AccountName.Clear();
            AccountPassword.Clear();
            AccountName.Selected = false;
            AccountPassword.Selected = false;
        }
    }
}
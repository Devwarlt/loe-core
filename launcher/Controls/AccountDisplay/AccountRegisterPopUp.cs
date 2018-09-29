using LoESoft.Launcher.Http;
using System;
using System.Windows.Forms;

namespace LoESoft.Launcher.Controls.AccountDisplay
{
    public partial class AccountRegisterPopUp : UserControl
    {
        public AccountRegisterPopUp()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var parent = ((AccountDisplayControl)Parent);
            var httpEngine = HttpEngine.CreateRequest(PacketID.REGISTER);
            var query = new HttpEngineQuery();
            query.AddQuery("name", AccountNameTextBox.Text);
            query.AddQuery("password", PasswordTextBox.Text);

            httpEngine.SendRequest(
                success =>
                {
                    parent.PopUpDisplay.Settings = new PopUpSettings()
                    {
                        Title = "Account Created",
                        Content = success,
                        Action = () => Enabled = false,
                        ExtraAction = () => parent.PopUpDisplay.Visible = !parent.PopUpDisplay.Visible
                    };
                    parent.PopUpDisplay.LoadSettings();

                    GameLauncher.Info(success);
                },
                error =>
                {
                    parent.PopUpDisplay.Settings = new PopUpSettings()
                    {
                        Title = "Account Error",
                        Content = error,
                        Action = () => Enabled = false,
                        ExtraAction = () => parent.PopUpDisplay.Visible = !parent.PopUpDisplay.Visible
                    };
                    parent.PopUpDisplay.LoadSettings();

                    GameLauncher.Warn(error);
                },
                query);
        }

        private void IsKeyDown(object sender, KeyEventArgs e)
        {
            var isCaps = IsKeyLocked(Keys.CapsLock);

            CapsLockLabel.Enabled = isCaps;
            CapsLockLabel.Visible = isCaps;
        }

        private void TitleLabel_Click(object sender, EventArgs e) { }

        private void CloseRegisterButton_Click(object sender, EventArgs e) => ((AccountDisplayControl)Parent).RegisterToggle();
    }
}

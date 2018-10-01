using LoESoft.Launcher.Http;
using System;
using System.Collections.Generic;
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
            var query = new HttpEngineQuery();
            query.AddQuery("name", AccountNameTextBox.Text);
            query.AddQuery("password", PasswordTextBox.Text);

            HttpEngine.Handle(
                PacketID.REGISTER,
                query,
                success =>
                {
                    parent.PopUpDisplay.Settings = new PopUpSettings()
                    {
                        Title = "Account Created",
                        Content = success,
                        WhenDisplay = () => Enabled = false,
                        WhenClose = () => parent.PopUpDisplay.Visible = !parent.PopUpDisplay.Visible
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
                        WhenDisplay = () => Enabled = false,
                        WhenClose = () => parent.PopUpDisplay.Visible = !parent.PopUpDisplay.Visible
                    };
                    parent.PopUpDisplay.LoadSettings();

                    GameLauncher.Warn(error);
                });
        }

        private void IsKeyDown(object sender, KeyEventArgs e)
        {
            var isCaps = IsKeyLocked(Keys.CapsLock);

            CapsLockLabel.Enabled = isCaps;
            CapsLockLabel.Visible = isCaps;
        }

        private void CloseRegisterButton_Click(object sender, EventArgs e) => ((AccountDisplayControl)Parent).RegisterToggle();
    }
}

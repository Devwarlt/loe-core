using LoESoft.Launcher.Http;
using System;
using System.Windows.Forms;
using System.Xml;

namespace LoESoft.Launcher.Controls.AccountDisplay
{
    public partial class LoginRegisterDisplay : UserControl
    {
        public LoginRegisterDisplay()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var httpEngine = HttpEngine.CreateRequest(PacketID.REGISTER);
            var query = new HttpEngineQuery();
            query.AddQuery("name", AccountNameTextBox.Text);
            query.AddQuery("password", PasswordTextBox.Text);

            httpEngine.SendRequest(
                success =>
                {
                    GameLauncher.Info(success);

                    Close();
                },
                error =>
                {
                    GameLauncher.Warn(error);

                    Close();
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

        private void CloseRegisterButton_Click(object sender, EventArgs e) => Close();

        private void Close() => ((AccountDisplayControl)Parent).RegisterToggle();
    }
}

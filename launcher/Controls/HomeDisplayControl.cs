using System.Windows.Forms;

namespace LoESoft.Launcher.Controls
{
    public partial class HomeDisplayControl : UserControl
    {
        public HomeDisplayControl()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("You've successfully pressed the button! Congratulations!");
        }
    }
}

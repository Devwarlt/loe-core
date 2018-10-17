using System.Windows.Forms;

namespace LoESoft.Launcher.Controls.HomeDisplay
{
    public partial class Main : UserControl
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("You've successfully pressed the button! Congratulations!");
        }
    }
}

using System.Windows.Forms;

namespace LoESoft.Launcher.Controls
{
    public class CustomTextBox : TextBox
    {
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0302 || m.Msg == 0x0301 || m.Msg == 0x0300 || m.Msg == 0x1503)
                return;
            base.WndProc(ref m);
        }
    }
}

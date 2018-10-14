using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LoESoft.Launcher.Controls
{
    public class ExtendedButton : Button
    {
        [Category("Control Display")]
        [DisplayName("Display")]
        [Description("This is the display that will be shown on button press")]
        public UserControl Display { get; set; }

        [Category("Control Display")]
        [DisplayName("Selected")]
        [Description("Decide if this is the selected display to show")]
        public bool Selected { get; set; }

        public void SetActive()
        {
            Enabled = false;
            Display.Enabled = true;
            Display.Visible = true;
            Selected = true;
            BackColor = Color.Gray;
        }

        public void SetInActive()
        {
            Enabled = true;
            Display.Enabled = false;
            Display.Visible = false;
            Selected = false;
            BackColor = Color.DimGray;
        }
    }
}

using LoESoft.Client.Core.Networking;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LoESoft.Client.Core.GUI
{
    public partial class Launcher : Form
    {
        public EventHandler<bool> Display;

        public Launcher() => InitializeComponent();

        private void Launcher_Load(object sender, EventArgs e)
        {
            NetworkClient.Listen();

            Display += OnDisplay;

            // Update all fonts
            GetAllControls(this, new List<Control>()).ForEach(control =>
            {
                var cfont = control.Font;
                control.Font = new Font(App.DisposableDroidBB, cfont.Size, cfont.Style, cfont.Unit, cfont.GdiCharSet);
            });
        }

        private void OnDisplay(object sender, bool e)
        {
            if (e)
            {
                WindowState = FormWindowState.Normal;
                Opacity = 0.99D;
                CenterToScreen();
            }
            else
            {
                WindowState = FormWindowState.Minimized;
                Opacity = 0;
                Location = new Point(-999, -999); // out of user window bounds
            }
        }

        private List<Control> GetAllControls(Control container) => GetAllControls(container, new List<Control>());

        private List<Control> GetAllControls(Control container, List<Control> list)
        {
            foreach (Control c in container.Controls)
            {
                if (c.Controls.Count > 0)
                    list = GetAllControls(c, list);
                else
                    list.Add(c);
            }

            return list;
        }
    }
}
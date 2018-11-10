using LoESoft.Client.Core.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static LoESoft.Client.Core.Networking.Server;

namespace LoESoft.Client.Core.GUI
{
    public partial class Launcher : Form
    {
        public GameUser GameUser { get; set; }

        public EventHandler<bool> Display;

        public Launcher() => InitializeComponent();

        private void Launcher_Load(object sender, EventArgs e)
        {
            GameUser = new GameUser(GetServers[ServerName.LOCAL]);
            GameUser.Connect();

            MainMenu.GameUser = GameUser;

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
            Enabled = e;
            Visible = e;
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
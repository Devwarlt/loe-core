using LoESoft.Client.Core.Client;
using System;
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
        }

        private void OnDisplay(object sender, bool e)
        {
            Enabled = e;
            Visible = e;
        }
    }
}
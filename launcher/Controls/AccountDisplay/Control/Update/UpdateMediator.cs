using LoESoft.Launcher.Controls.AccountDisplay.Control.Updater;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace LoESoft.Launcher.Controls.AccountDisplay.Control.Update
{
    public partial class UpdateMediator : UserControl
    {
        private WebClient Client;
        private Stopwatch Watch;

        public UpdateMediator()
        {
            Client = new WebClient();
            Client.DownloadFileCompleted += new AsyncCompletedEventHandler(OnComplete);
            Client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(OnUpdate);

            Watch = new Stopwatch();

            InitializeComponent();
        }

        private void UpdateStartPlayButton_Click(object sender, EventArgs e)
        {
            UpdateStartPlayButton.Enabled = false;

            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(string.IsNullOrEmpty(appData) ? documents : appData, "LoESoft Games\\BRME");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            Watch.Start();

            try { Client.DownloadFileAsync(new Uri(((UpdaterControl)Parent).UpdateLink), path); }
            catch (Exception ex) { GameLauncher.Error(ex); }
        }

        private void OnComplete(object sender, AsyncCompletedEventArgs e)
        {
            Watch.Stop();

            if (e.Cancelled)
            {
                Client?.Dispose();

                var parent = (UpdateControl)Parent;
                parent.ToggleUpdateMediator();
                parent.ToggleUI();
            }
            else
            {
                UpdateStartPlayButton.Enabled = true;
                UpdateStartPlayButton.Text = "Play";
                UpdateStartPlayButton.Click -= UpdateStartPlayButton_Click;
                UpdateStartPlayButton.Click += delegate { }; // TODO: launch client.
            }
        }

        private void OnUpdate(object sender, DownloadProgressChangedEventArgs e)
        {
            SpeedValueLabel.Text = $"{e.BytesReceived / 1024d / Watch.Elapsed.TotalSeconds} KB/s";

            UpdateProgressBar.Value = e.ProgressPercentage;

            ProgressValueLabel.Text = $"{e.ProgressPercentage} % " +
                $"[{(e.BytesReceived / 1024d / 1024d).ToString("0.00")} of " +
                $"{(e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00")} MB]";
        }

        public void SetText() => FileValueLabel.Text = $"...{((UpdaterControl)Parent).UpdateLink.Substring(55)}";
    }
}
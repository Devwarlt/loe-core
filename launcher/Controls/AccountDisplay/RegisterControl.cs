﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoESoft.Launcher.Controls.AccountDisplay
{
    public partial class RegisterControl : UserControl
    {
        public RegisterControl()
        {
            InitializeComponent();
        }

        private void RegisterControl_Load(object sender, EventArgs e)
        {
            // Hide the rest of boxes.
            RegisterBox.Visible = false;
            RegisterBox.Enabled = false;

            SetPopUpBoxVisibility(false);
        }

        public void ToggleRegisterBox()
        {
            RegisterBox.Visible = !RegisterBox.Visible;
            RegisterBox.Enabled = !RegisterBox.Enabled;
        }

        public void ToggleUI()
        {
            Visible = false;
            Enabled = false;

            ((Main)Parent).ToggleButtons();
        }

        public void SetPopUpBoxVisibility(bool visible) => PopUpBox.Visible = visible;

        public void UpdatePopUp(PopUpSettings settings)
        {
            PopUpBox.Settings = settings;
            PopUpBox.LoadSettings();
        }
    }
}
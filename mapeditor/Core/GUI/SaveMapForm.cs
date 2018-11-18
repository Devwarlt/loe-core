﻿using LoESoft.MapEditor.Core.Util;
using System;
using System.Windows.Forms;

namespace LoESoft.MapEditor.Core.GUI
{
    public partial class SaveMapForm : Form
    {
        private string _mapName { get; set; }

        public SaveMapForm(string mapName)
        {
            _mapName = mapName;

            InitializeComponent();
        }

        private void SaveMapForm_Load(object sender, EventArgs e) => MapNameTextBox.Text = _mapName;

        private void Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MapNameTextBox.Text))
                MessageBox.Show("Map name is empty!");
            else
            {
                Utils.SaveMap(MapEditor.Map, MapNameTextBox.Text);

                DialogResult = DialogResult.OK;
            }
        }

        private void Cancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}
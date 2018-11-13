namespace LoESoft.MapEditor.Core.GUI
{
    partial class SaveMapForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Cancel = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.BrowseFolder = new System.Windows.Forms.Button();
            this.MapNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MapPathLabel = new System.Windows.Forms.Label();
            this.MapNameLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(173, 121);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(138, 25);
            this.Cancel.TabIndex = 7;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(12, 121);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(138, 25);
            this.Save.TabIndex = 6;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // BrowseFolder
            // 
            this.BrowseFolder.Location = new System.Drawing.Point(241, 10);
            this.BrowseFolder.Name = "BrowseFolder";
            this.BrowseFolder.Size = new System.Drawing.Size(70, 23);
            this.BrowseFolder.TabIndex = 8;
            this.BrowseFolder.Text = "Folder";
            this.BrowseFolder.UseVisualStyleBackColor = true;
            this.BrowseFolder.Click += new System.EventHandler(this.BrowseFolder_Click);
            // 
            // MapNameTextBox
            // 
            this.MapNameTextBox.Location = new System.Drawing.Point(52, 12);
            this.MapNameTextBox.Name = "MapNameTextBox";
            this.MapNameTextBox.Size = new System.Drawing.Size(183, 20);
            this.MapNameTextBox.TabIndex = 9;
            this.MapNameTextBox.TextChanged += new System.EventHandler(this.MapNameTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MapPathLabel);
            this.groupBox1.Controls.Add(this.MapNameLabel);
            this.groupBox1.Location = new System.Drawing.Point(15, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 77);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // MapPathLabel
            // 
            this.MapPathLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MapPathLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.MapPathLabel.Location = new System.Drawing.Point(3, 46);
            this.MapPathLabel.Name = "MapPathLabel";
            this.MapPathLabel.Size = new System.Drawing.Size(290, 28);
            this.MapPathLabel.TabIndex = 0;
            this.MapPathLabel.Text = "Map Path: empty";
            // 
            // MapNameLabel
            // 
            this.MapNameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MapNameLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.MapNameLabel.Location = new System.Drawing.Point(3, 16);
            this.MapNameLabel.Name = "MapNameLabel";
            this.MapNameLabel.Size = new System.Drawing.Size(290, 30);
            this.MapNameLabel.TabIndex = 0;
            this.MapNameLabel.Text = "Map Name: new_map.json";
            // 
            // SaveMapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(325, 157);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MapNameTextBox);
            this.Controls.Add(this.BrowseFolder);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveMapForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SaveMapForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button BrowseFolder;
        private System.Windows.Forms.TextBox MapNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label MapPathLabel;
        private System.Windows.Forms.Label MapNameLabel;
    }
}
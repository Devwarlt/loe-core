namespace LoESoft.MapEditor.Core.GUI
{
    partial class InterfaceForm
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
            this.NewButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.EditorInformationGroup = new System.Windows.Forms.GroupBox();
            this.MapNameLabel = new System.Windows.Forms.Label();
            this.MapSizeLabel = new System.Windows.Forms.Label();
            this.GridCheckBox = new System.Windows.Forms.CheckBox();
            this.MapOptionsGroup = new System.Windows.Forms.GroupBox();
            this.PalletePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.PalleteComboBox = new System.Windows.Forms.ComboBox();
            this.EditorLabel = new System.Windows.Forms.Label();
            this.TitleUnderLine = new System.Windows.Forms.Panel();
            this.EditorInformationGroup.SuspendLayout();
            this.MapOptionsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // NewButton
            // 
            this.NewButton.Location = new System.Drawing.Point(13, 44);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(75, 24);
            this.NewButton.TabIndex = 0;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(175, 44);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 24);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(94, 44);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 24);
            this.LoadButton.TabIndex = 0;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // EditorInformationGroup
            // 
            this.EditorInformationGroup.Controls.Add(this.MapNameLabel);
            this.EditorInformationGroup.Controls.Add(this.MapSizeLabel);
            this.EditorInformationGroup.Controls.Add(this.GridCheckBox);
            this.EditorInformationGroup.ForeColor = System.Drawing.SystemColors.Desktop;
            this.EditorInformationGroup.Location = new System.Drawing.Point(14, 74);
            this.EditorInformationGroup.Name = "EditorInformationGroup";
            this.EditorInformationGroup.Size = new System.Drawing.Size(235, 76);
            this.EditorInformationGroup.TabIndex = 0;
            this.EditorInformationGroup.TabStop = false;
            this.EditorInformationGroup.Text = "Map";
            // 
            // MapNameLabel
            // 
            this.MapNameLabel.Location = new System.Drawing.Point(6, 16);
            this.MapNameLabel.Name = "MapNameLabel";
            this.MapNameLabel.Size = new System.Drawing.Size(44, 13);
            this.MapNameLabel.TabIndex = 0;
            this.MapNameLabel.Text = "Name: -";
            // 
            // MapSizeLabel
            // 
            this.MapSizeLabel.Location = new System.Drawing.Point(6, 37);
            this.MapSizeLabel.Name = "MapSizeLabel";
            this.MapSizeLabel.Size = new System.Drawing.Size(36, 13);
            this.MapSizeLabel.TabIndex = 0;
            this.MapSizeLabel.Text = "Size: -";
            // 
            // GridCheckBox
            // 
            this.GridCheckBox.AutoSize = true;
            this.GridCheckBox.Location = new System.Drawing.Point(147, 53);
            this.GridCheckBox.Name = "GridCheckBox";
            this.GridCheckBox.Size = new System.Drawing.Size(82, 17);
            this.GridCheckBox.TabIndex = 0;
            this.GridCheckBox.Text = "Display Grid";
            this.GridCheckBox.UseVisualStyleBackColor = true;
            this.GridCheckBox.CheckedChanged += new System.EventHandler(this.GridCheckBox_CheckedChanged);
            // 
            // MapOptionsGroup
            // 
            this.MapOptionsGroup.Controls.Add(this.PalletePanel);
            this.MapOptionsGroup.Controls.Add(this.label1);
            this.MapOptionsGroup.Controls.Add(this.PalleteComboBox);
            this.MapOptionsGroup.ForeColor = System.Drawing.SystemColors.Desktop;
            this.MapOptionsGroup.Location = new System.Drawing.Point(14, 156);
            this.MapOptionsGroup.Name = "MapOptionsGroup";
            this.MapOptionsGroup.Size = new System.Drawing.Size(234, 432);
            this.MapOptionsGroup.TabIndex = 1;
            this.MapOptionsGroup.TabStop = false;
            this.MapOptionsGroup.Text = "Options";
            // 
            // PalletePanel
            // 
            this.PalletePanel.AutoScroll = true;
            this.PalletePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PalletePanel.Location = new System.Drawing.Point(5, 46);
            this.PalletePanel.Name = "PalletePanel";
            this.PalletePanel.Size = new System.Drawing.Size(223, 380);
            this.PalletePanel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pallete:";
            // 
            // PalleteComboBox
            // 
            this.PalleteComboBox.FormattingEnabled = true;
            this.PalleteComboBox.Location = new System.Drawing.Point(58, 19);
            this.PalleteComboBox.Name = "PalleteComboBox";
            this.PalleteComboBox.Size = new System.Drawing.Size(170, 21);
            this.PalleteComboBox.TabIndex = 0;
            this.PalleteComboBox.Text = "---";
            this.PalleteComboBox.SelectedIndexChanged += new System.EventHandler(this.PalleteComboBox_SelectedIndexChanged);
            // 
            // EditorLabel
            // 
            this.EditorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditorLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.EditorLabel.Location = new System.Drawing.Point(13, 1);
            this.EditorLabel.Name = "EditorLabel";
            this.EditorLabel.Size = new System.Drawing.Size(237, 36);
            this.EditorLabel.TabIndex = 2;
            this.EditorLabel.Text = "Map Editor";
            this.EditorLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TitleUnderLine
            // 
            this.TitleUnderLine.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.TitleUnderLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TitleUnderLine.Location = new System.Drawing.Point(16, 38);
            this.TitleUnderLine.Name = "TitleUnderLine";
            this.TitleUnderLine.Size = new System.Drawing.Size(234, 2);
            this.TitleUnderLine.TabIndex = 3;
            // 
            // InterfaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 600);
            this.Controls.Add(this.TitleUnderLine);
            this.Controls.Add(this.EditorLabel);
            this.Controls.Add(this.NewButton);
            this.Controls.Add(this.MapOptionsGroup);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.EditorInformationGroup);
            this.Controls.Add(this.LoadButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InterfaceForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Editor Interface";
            this.Load += new System.EventHandler(this.InterfaceForm_Load);
            this.EditorInformationGroup.ResumeLayout(false);
            this.EditorInformationGroup.PerformLayout();
            this.MapOptionsGroup.ResumeLayout(false);
            this.MapOptionsGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.GroupBox EditorInformationGroup;
        private System.Windows.Forms.CheckBox GridCheckBox;
        private System.Windows.Forms.Label MapSizeLabel;
        private System.Windows.Forms.Label MapNameLabel;
        private System.Windows.Forms.GroupBox MapOptionsGroup;
        private System.Windows.Forms.Label EditorLabel;
        private System.Windows.Forms.Panel TitleUnderLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox PalleteComboBox;
        private System.Windows.Forms.Panel PalletePanel;
    }
}
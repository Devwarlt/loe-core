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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.OptionsGroup = new System.Windows.Forms.GroupBox();
            this.NewButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.TitleUnderLine = new System.Windows.Forms.Panel();
            this.EditorInformationGroup = new System.Windows.Forms.GroupBox();
            this.MapLabel = new System.Windows.Forms.Label();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.LayerLabel = new System.Windows.Forms.Label();
            this.GridCheckBox = new System.Windows.Forms.CheckBox();
            this.MapOptionsGroup = new System.Windows.Forms.GroupBox();
            this.OptionsGroup.SuspendLayout();
            this.EditorInformationGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F);
            this.TitleLabel.Location = new System.Drawing.Point(12, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(626, 37);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Editor Interface";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OptionsGroup
            // 
            this.OptionsGroup.Controls.Add(this.NewButton);
            this.OptionsGroup.Controls.Add(this.SaveButton);
            this.OptionsGroup.Controls.Add(this.LoadButton);
            this.OptionsGroup.Location = new System.Drawing.Point(20, 528);
            this.OptionsGroup.Name = "OptionsGroup";
            this.OptionsGroup.Size = new System.Drawing.Size(250, 60);
            this.OptionsGroup.TabIndex = 0;
            this.OptionsGroup.TabStop = false;
            this.OptionsGroup.Text = "Options";
            // 
            // NewButton
            // 
            this.NewButton.Location = new System.Drawing.Point(6, 19);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(75, 33);
            this.NewButton.TabIndex = 0;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(168, 19);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 33);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(87, 19);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 33);
            this.LoadButton.TabIndex = 0;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // TitleUnderLine
            // 
            this.TitleUnderLine.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.TitleUnderLine.Location = new System.Drawing.Point(20, 50);
            this.TitleUnderLine.Name = "TitleUnderLine";
            this.TitleUnderLine.Size = new System.Drawing.Size(620, 2);
            this.TitleUnderLine.TabIndex = 0;
            // 
            // EditorInformationGroup
            // 
            this.EditorInformationGroup.Controls.Add(this.MapLabel);
            this.EditorInformationGroup.Controls.Add(this.SizeLabel);
            this.EditorInformationGroup.Controls.Add(this.LayerLabel);
            this.EditorInformationGroup.Controls.Add(this.GridCheckBox);
            this.EditorInformationGroup.Location = new System.Drawing.Point(26, 69);
            this.EditorInformationGroup.Name = "EditorInformationGroup";
            this.EditorInformationGroup.Size = new System.Drawing.Size(244, 453);
            this.EditorInformationGroup.TabIndex = 0;
            this.EditorInformationGroup.TabStop = false;
            this.EditorInformationGroup.Text = "Editor Information";
            // 
            // MapLabel
            // 
            this.MapLabel.AutoSize = true;
            this.MapLabel.Location = new System.Drawing.Point(10, 20);
            this.MapLabel.Name = "MapLabel";
            this.MapLabel.Size = new System.Drawing.Size(60, 13);
            this.MapLabel.TabIndex = 0;
            this.MapLabel.Text = "Map: None";
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Location = new System.Drawing.Point(10, 35);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(50, 13);
            this.SizeLabel.TabIndex = 0;
            this.SizeLabel.Text = "Size: 0x0";
            // 
            // LayerLabel
            // 
            this.LayerLabel.AutoSize = true;
            this.LayerLabel.Location = new System.Drawing.Point(10, 50);
            this.LayerLabel.Name = "LayerLabel";
            this.LayerLabel.Size = new System.Drawing.Size(45, 13);
            this.LayerLabel.TabIndex = 0;
            this.LayerLabel.Text = "Layer: 0";
            // 
            // GridCheckBox
            // 
            this.GridCheckBox.AutoSize = true;
            this.GridCheckBox.Location = new System.Drawing.Point(156, 19);
            this.GridCheckBox.Name = "GridCheckBox";
            this.GridCheckBox.Size = new System.Drawing.Size(82, 17);
            this.GridCheckBox.TabIndex = 0;
            this.GridCheckBox.Text = "Display Grid";
            this.GridCheckBox.UseVisualStyleBackColor = true;
            this.GridCheckBox.CheckedChanged += new System.EventHandler(this.GridCheckBox_CheckedChanged);
            // 
            // MapOptionsGroup
            // 
            this.MapOptionsGroup.Location = new System.Drawing.Point(276, 69);
            this.MapOptionsGroup.Name = "MapOptionsGroup";
            this.MapOptionsGroup.Size = new System.Drawing.Size(362, 453);
            this.MapOptionsGroup.TabIndex = 1;
            this.MapOptionsGroup.TabStop = false;
            this.MapOptionsGroup.Text = "Map Options";
            // 
            // InterfaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 600);
            this.Controls.Add(this.MapOptionsGroup);
            this.Controls.Add(this.EditorInformationGroup);
            this.Controls.Add(this.TitleUnderLine);
            this.Controls.Add(this.OptionsGroup);
            this.Controls.Add(this.TitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InterfaceForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Editor Interface";
            this.TopMost = true;
            this.OptionsGroup.ResumeLayout(false);
            this.EditorInformationGroup.ResumeLayout(false);
            this.EditorInformationGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.GroupBox OptionsGroup;
        private System.Windows.Forms.Panel TitleUnderLine;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.GroupBox EditorInformationGroup;
        private System.Windows.Forms.CheckBox GridCheckBox;
        private System.Windows.Forms.Label LayerLabel;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.Label MapLabel;
        private System.Windows.Forms.GroupBox MapOptionsGroup;
    }
}
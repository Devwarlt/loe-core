namespace LoESoft.MapEditor.Core.GUI
{
    partial class NewMapForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.MapFileName = new System.Windows.Forms.TextBox();
            this.Create = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.Size128 = new System.Windows.Forms.RadioButton();
            this.Size256 = new System.Windows.Forms.RadioButton();
            this.Size384 = new System.Windows.Forms.RadioButton();
            this.Size512 = new System.Windows.Forms.RadioButton();
            this.Size768 = new System.Windows.Forms.RadioButton();
            this.Size1024 = new System.Windows.Forms.RadioButton();
            this.SizeGroupBox = new System.Windows.Forms.GroupBox();
            this.SizeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // MapFileName
            // 
            this.MapFileName.Location = new System.Drawing.Point(56, 12);
            this.MapFileName.MaxLength = 32;
            this.MapFileName.Name = "MapFileName";
            this.MapFileName.Size = new System.Drawing.Size(258, 20);
            this.MapFileName.TabIndex = 2;
            this.MapFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Create
            // 
            this.Create.Location = new System.Drawing.Point(15, 131);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(138, 25);
            this.Create.TabIndex = 4;
            this.Create.Text = "Create";
            this.Create.UseVisualStyleBackColor = true;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(176, 131);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(138, 25);
            this.Cancel.TabIndex = 5;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Size128
            // 
            this.Size128.Appearance = System.Windows.Forms.Appearance.Button;
            this.Size128.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Size128.Checked = true;
            this.Size128.FlatAppearance.BorderSize = 0;
            this.Size128.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.HotTrack;
            this.Size128.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Size128.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.Size128.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Size128.Location = new System.Drawing.Point(27, 19);
            this.Size128.Name = "Size128";
            this.Size128.Size = new System.Drawing.Size(78, 25);
            this.Size128.TabIndex = 8;
            this.Size128.TabStop = true;
            this.Size128.Text = "128 x 128";
            this.Size128.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Size128.UseVisualStyleBackColor = false;
            this.Size128.CheckedChanged += new System.EventHandler(this.Size128_CheckedChanged);
            // 
            // Size256
            // 
            this.Size256.Appearance = System.Windows.Forms.Appearance.Button;
            this.Size256.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Size256.FlatAppearance.BorderSize = 0;
            this.Size256.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.HotTrack;
            this.Size256.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Size256.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.Size256.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Size256.Location = new System.Drawing.Point(111, 19);
            this.Size256.Name = "Size256";
            this.Size256.Size = new System.Drawing.Size(78, 25);
            this.Size256.TabIndex = 9;
            this.Size256.Text = "256 x 256";
            this.Size256.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Size256.UseVisualStyleBackColor = false;
            this.Size256.CheckedChanged += new System.EventHandler(this.Size256_CheckedChanged);
            // 
            // Size384
            // 
            this.Size384.Appearance = System.Windows.Forms.Appearance.Button;
            this.Size384.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Size384.FlatAppearance.BorderSize = 0;
            this.Size384.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.HotTrack;
            this.Size384.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Size384.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.Size384.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Size384.Location = new System.Drawing.Point(195, 19);
            this.Size384.Name = "Size384";
            this.Size384.Size = new System.Drawing.Size(78, 25);
            this.Size384.TabIndex = 10;
            this.Size384.Text = "384 x 384";
            this.Size384.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Size384.UseVisualStyleBackColor = false;
            this.Size384.CheckedChanged += new System.EventHandler(this.Size384_CheckedChanged);
            // 
            // Size512
            // 
            this.Size512.Appearance = System.Windows.Forms.Appearance.Button;
            this.Size512.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Size512.FlatAppearance.BorderSize = 0;
            this.Size512.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.HotTrack;
            this.Size512.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Size512.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.Size512.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Size512.Location = new System.Drawing.Point(27, 50);
            this.Size512.Name = "Size512";
            this.Size512.Size = new System.Drawing.Size(78, 25);
            this.Size512.TabIndex = 10;
            this.Size512.Text = "512 x 512";
            this.Size512.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Size512.UseVisualStyleBackColor = false;
            this.Size512.CheckedChanged += new System.EventHandler(this.Size512_CheckedChanged);
            // 
            // Size768
            // 
            this.Size768.Appearance = System.Windows.Forms.Appearance.Button;
            this.Size768.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Size768.FlatAppearance.BorderSize = 0;
            this.Size768.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.HotTrack;
            this.Size768.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Size768.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.Size768.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Size768.Location = new System.Drawing.Point(111, 50);
            this.Size768.Name = "Size768";
            this.Size768.Size = new System.Drawing.Size(78, 25);
            this.Size768.TabIndex = 10;
            this.Size768.Text = "768 x 768";
            this.Size768.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Size768.UseVisualStyleBackColor = false;
            this.Size768.CheckedChanged += new System.EventHandler(this.Size768_CheckedChanged);
            // 
            // Size1024
            // 
            this.Size1024.Appearance = System.Windows.Forms.Appearance.Button;
            this.Size1024.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Size1024.FlatAppearance.BorderSize = 0;
            this.Size1024.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.HotTrack;
            this.Size1024.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Size1024.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.Size1024.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Size1024.Location = new System.Drawing.Point(195, 50);
            this.Size1024.Name = "Size1024";
            this.Size1024.Size = new System.Drawing.Size(78, 25);
            this.Size1024.TabIndex = 10;
            this.Size1024.Text = "1024 x 1024";
            this.Size1024.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Size1024.UseVisualStyleBackColor = false;
            this.Size1024.CheckedChanged += new System.EventHandler(this.Size1024_CheckedChanged);
            // 
            // SizeGroupBox
            // 
            this.SizeGroupBox.Controls.Add(this.Size384);
            this.SizeGroupBox.Controls.Add(this.Size256);
            this.SizeGroupBox.Controls.Add(this.Size1024);
            this.SizeGroupBox.Controls.Add(this.Size128);
            this.SizeGroupBox.Controls.Add(this.Size768);
            this.SizeGroupBox.Controls.Add(this.Size512);
            this.SizeGroupBox.Location = new System.Drawing.Point(15, 37);
            this.SizeGroupBox.Name = "SizeGroupBox";
            this.SizeGroupBox.Size = new System.Drawing.Size(299, 88);
            this.SizeGroupBox.TabIndex = 11;
            this.SizeGroupBox.TabStop = false;
            this.SizeGroupBox.Text = "Size";
            // 
            // NewMapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(328, 168);
            this.Controls.Add(this.SizeGroupBox);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Create);
            this.Controls.Add(this.MapFileName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewMapForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Map";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.NewMapForm_Load);
            this.SizeGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MapFileName;
        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.RadioButton Size256;
        private System.Windows.Forms.RadioButton Size384;
        private System.Windows.Forms.RadioButton Size512;
        private System.Windows.Forms.RadioButton Size768;
        private System.Windows.Forms.RadioButton Size1024;
        private System.Windows.Forms.RadioButton Size128;
        private System.Windows.Forms.GroupBox SizeGroupBox;
    }
}
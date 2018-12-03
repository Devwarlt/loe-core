namespace LoESoft.AssetsManager.Core.GUI
{
    partial class AddXmlForm
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
            this.XmlName = new LoESoft.AssetsManager.Core.GUI.HUD.CustomTextBox();
            this.SaveButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SaveButton)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // XmlName
            // 
            this.XmlName.BorderColor = System.Drawing.Color.DarkGray;
            this.XmlName.Location = new System.Drawing.Point(53, 6);
            this.XmlName.Name = "XmlName";
            this.XmlName.Size = new System.Drawing.Size(234, 20);
            this.XmlName.TabIndex = 1;
            this.XmlName.TextChanged += new System.EventHandler(this.XmlName_TextChanged);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.SystemColors.Desktop;
            this.SaveButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveButton.Enabled = false;
            this.SaveButton.Image = global::LoESoft.AssetsManager.Properties.Resources.hud_check_inactive;
            this.SaveButton.Location = new System.Drawing.Point(293, 4);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(24, 24);
            this.SaveButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SaveButton.TabIndex = 2;
            this.SaveButton.TabStop = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // AddXmlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(324, 34);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.XmlName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddXmlForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New XML";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.SaveButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private HUD.CustomTextBox XmlName;
        private System.Windows.Forms.PictureBox SaveButton;
    }
}
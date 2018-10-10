namespace LoESoft.Launcher.Controls.OptionsDisplay
{
    partial class Main
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TitleLabel = new System.Windows.Forms.Label();
            this.AutoLoginCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoUpdateCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoOffersCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoNewsCheckBox = new System.Windows.Forms.CheckBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleLabel.BackColor = System.Drawing.Color.Gray;
            this.TitleLabel.Font = new System.Drawing.Font("DisposableDroid BB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.TitleLabel.Location = new System.Drawing.Point(0, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(600, 40);
            this.TitleLabel.TabIndex = 3;
            this.TitleLabel.Text = "Options";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AutoLoginCheckBox
            // 
            this.AutoLoginCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AutoLoginCheckBox.Font = new System.Drawing.Font("DisposableDroid BB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoLoginCheckBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.AutoLoginCheckBox.Location = new System.Drawing.Point(24, 64);
            this.AutoLoginCheckBox.Name = "AutoLoginCheckBox";
            this.AutoLoginCheckBox.Size = new System.Drawing.Size(552, 24);
            this.AutoLoginCheckBox.TabIndex = 5;
            this.AutoLoginCheckBox.Text = "Enable auto-login authentication when Launcher start.";
            this.AutoLoginCheckBox.UseVisualStyleBackColor = true;
            // 
            // AutoUpdateCheckBox
            // 
            this.AutoUpdateCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AutoUpdateCheckBox.Font = new System.Drawing.Font("DisposableDroid BB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoUpdateCheckBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.AutoUpdateCheckBox.Location = new System.Drawing.Point(24, 96);
            this.AutoUpdateCheckBox.Name = "AutoUpdateCheckBox";
            this.AutoUpdateCheckBox.Size = new System.Drawing.Size(552, 48);
            this.AutoUpdateCheckBox.TabIndex = 6;
            this.AutoUpdateCheckBox.Text = "Enable automatic update feature when Launcher start. If disabled, user may use re" +
    "gular update method at Home screen to play.";
            this.AutoUpdateCheckBox.UseVisualStyleBackColor = true;
            // 
            // AutoOffersCheckBox
            // 
            this.AutoOffersCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AutoOffersCheckBox.Font = new System.Drawing.Font("DisposableDroid BB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoOffersCheckBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.AutoOffersCheckBox.Location = new System.Drawing.Point(24, 152);
            this.AutoOffersCheckBox.Name = "AutoOffersCheckBox";
            this.AutoOffersCheckBox.Size = new System.Drawing.Size(552, 24);
            this.AutoOffersCheckBox.TabIndex = 7;
            this.AutoOffersCheckBox.Text = "Enable automatic game offers display at Home screen.";
            this.AutoOffersCheckBox.UseVisualStyleBackColor = true;
            // 
            // AutoNewsCheckBox
            // 
            this.AutoNewsCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AutoNewsCheckBox.Font = new System.Drawing.Font("DisposableDroid BB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoNewsCheckBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.AutoNewsCheckBox.Location = new System.Drawing.Point(24, 184);
            this.AutoNewsCheckBox.Name = "AutoNewsCheckBox";
            this.AutoNewsCheckBox.Size = new System.Drawing.Size(552, 24);
            this.AutoNewsCheckBox.TabIndex = 8;
            this.AutoNewsCheckBox.Text = "Enable automatic game news display at Home screen when Launcher start.";
            this.AutoNewsCheckBox.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.DimGray;
            this.SaveButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("DisposableDroid BB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.SaveButton.Location = new System.Drawing.Point(24, 540);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(124, 36);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.TabStop = false;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.AutoNewsCheckBox);
            this.Controls.Add(this.AutoOffersCheckBox);
            this.Controls.Add(this.AutoUpdateCheckBox);
            this.Controls.Add(this.AutoLoginCheckBox);
            this.Controls.Add(this.TitleLabel);
            this.Name = "Main";
            this.Size = new System.Drawing.Size(600, 600);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.CheckBox AutoLoginCheckBox;
        private System.Windows.Forms.CheckBox AutoUpdateCheckBox;
        private System.Windows.Forms.CheckBox AutoOffersCheckBox;
        private System.Windows.Forms.CheckBox AutoNewsCheckBox;
        private System.Windows.Forms.Button SaveButton;
    }
}

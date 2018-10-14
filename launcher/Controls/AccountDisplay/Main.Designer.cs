namespace LoESoft.Launcher.Controls.AccountDisplay
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
            this.LoginLogoutButton = new System.Windows.Forms.Button();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.PlayButton = new System.Windows.Forms.Button();
            this.RegisterControl = new LoESoft.Launcher.Controls.AccountDisplay.Control.Register.RegisterControl();
            this.LogoutControl = new LoESoft.Launcher.Controls.AccountDisplay.Control.Logout.LogoutControl();
            this.LoginControl = new LoESoft.Launcher.Controls.AccountDisplay.Control.Login.LoginControl();
            this.UpdaterControl = new LoESoft.Launcher.Controls.AccountDisplay.Control.Updater.UpdaterControl();
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
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "Account";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginLogoutButton
            // 
            this.LoginLogoutButton.BackColor = System.Drawing.Color.DimGray;
            this.LoginLogoutButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.LoginLogoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginLogoutButton.Font = new System.Drawing.Font("DisposableDroid BB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginLogoutButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.LoginLogoutButton.Location = new System.Drawing.Point(23, 482);
            this.LoginLogoutButton.Name = "LoginLogoutButton";
            this.LoginLogoutButton.Size = new System.Drawing.Size(124, 36);
            this.LoginLogoutButton.TabIndex = 0;
            this.LoginLogoutButton.TabStop = false;
            this.LoginLogoutButton.Text = "Login";
            this.LoginLogoutButton.UseVisualStyleBackColor = false;
            // 
            // RegisterButton
            // 
            this.RegisterButton.BackColor = System.Drawing.Color.DimGray;
            this.RegisterButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.RegisterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegisterButton.Font = new System.Drawing.Font("DisposableDroid BB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.RegisterButton.Location = new System.Drawing.Point(24, 540);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(124, 36);
            this.RegisterButton.TabIndex = 0;
            this.RegisterButton.TabStop = false;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = false;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.BackColor = System.Drawing.Color.DimGray;
            this.PlayButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.PlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayButton.Font = new System.Drawing.Font("DisposableDroid BB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.PlayButton.Location = new System.Drawing.Point(23, 424);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(124, 36);
            this.PlayButton.TabIndex = 6;
            this.PlayButton.TabStop = false;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = false;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // RegisterControl
            // 
            this.RegisterControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.RegisterControl.Location = new System.Drawing.Point(137, 80);
            this.RegisterControl.Name = "RegisterControl";
            this.RegisterControl.Size = new System.Drawing.Size(325, 315);
            this.RegisterControl.TabIndex = 9;
            // 
            // LogoutControl
            // 
            this.LogoutControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.LogoutControl.Location = new System.Drawing.Point(137, 80);
            this.LogoutControl.Name = "LogoutControl";
            this.LogoutControl.Size = new System.Drawing.Size(325, 244);
            this.LogoutControl.TabIndex = 8;
            // 
            // LoginControl
            // 
            this.LoginControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.LoginControl.Location = new System.Drawing.Point(137, 80);
            this.LoginControl.Name = "LoginControl";
            this.LoginControl.Size = new System.Drawing.Size(325, 305);
            this.LoginControl.TabIndex = 7;
            // 
            // UpdaterControl
            // 
            this.UpdaterControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.UpdaterControl.Location = new System.Drawing.Point(137, 80);
            this.UpdaterControl.Name = "UpdaterControl";
            this.UpdaterControl.Size = new System.Drawing.Size(325, 305);
            this.UpdaterControl.TabIndex = 10;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.UpdaterControl);
            this.Controls.Add(this.RegisterControl);
            this.Controls.Add(this.LogoutControl);
            this.Controls.Add(this.LoginControl);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.LoginLogoutButton);
            this.Controls.Add(this.TitleLabel);
            this.Name = "Main";
            this.Size = new System.Drawing.Size(600, 600);
            this.EnabledChanged += new System.EventHandler(this.Main_EnabledChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Button LoginLogoutButton;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Button PlayButton;
        private Control.Login.LoginControl LoginControl;
        private Control.Logout.LogoutControl LogoutControl;
        private Control.Register.RegisterControl RegisterControl;
        private Control.Updater.UpdaterControl UpdaterControl;
    }
}

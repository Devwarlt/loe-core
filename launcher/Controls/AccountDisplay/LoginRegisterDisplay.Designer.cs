namespace LoESoft.Launcher.Controls.AccountDisplay
{
    partial class LoginRegisterDisplay
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
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TitlePanelSeperator = new System.Windows.Forms.Panel();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.EmailTextBox = new LoESoft.Launcher.Controls.CustomTextBox();
            this.PasswordTextBox = new LoESoft.Launcher.Controls.CustomTextBox();
            this.ConfirmPasswordTextBox = new LoESoft.Launcher.Controls.CustomTextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.ConfirmPasswordLabel = new System.Windows.Forms.Label();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.CapsLockLabel = new System.Windows.Forms.Label();
            this.TitlePanelSeperator.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitlePanelSeperator
            // 
            this.TitlePanelSeperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitlePanelSeperator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TitlePanelSeperator.Controls.Add(this.TitleLabel);
            this.TitlePanelSeperator.Location = new System.Drawing.Point(-1, -1);
            this.TitlePanelSeperator.Name = "TitlePanelSeperator";
            this.TitlePanelSeperator.Size = new System.Drawing.Size(514, 73);
            this.TitlePanelSeperator.TabIndex = 8;
            // 
            // TitleLabel
            // 
            this.TitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleLabel.Font = new System.Drawing.Font("Marlett", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.TitleLabel.Location = new System.Drawing.Point(24, 3);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(464, 65);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Account Register";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TitleLabel.Click += new System.EventHandler(this.TitleLabel_Click);
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EmailTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.EmailTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EmailTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailTextBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.EmailTextBox.Location = new System.Drawing.Point(26, 101);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(458, 31);
            this.EmailTextBox.TabIndex = 7;
            this.EmailTextBox.TabStop = false;
            this.EmailTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.PasswordTextBox.Location = new System.Drawing.Point(26, 156);
            this.PasswordTextBox.MaxLength = 32;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(458, 31);
            this.PasswordTextBox.TabIndex = 6;
            this.PasswordTextBox.TabStop = false;
            this.PasswordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PasswordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IsKeyDown);
            // 
            // ConfirmPasswordTextBox
            // 
            this.ConfirmPasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmPasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.ConfirmPasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConfirmPasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmPasswordTextBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.ConfirmPasswordTextBox.Location = new System.Drawing.Point(26, 211);
            this.ConfirmPasswordTextBox.MaxLength = 32;
            this.ConfirmPasswordTextBox.Name = "ConfirmPasswordTextBox";
            this.ConfirmPasswordTextBox.PasswordChar = '*';
            this.ConfirmPasswordTextBox.Size = new System.Drawing.Size(458, 31);
            this.ConfirmPasswordTextBox.TabIndex = 5;
            this.ConfirmPasswordTextBox.TabStop = false;
            this.ConfirmPasswordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ConfirmPasswordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IsKeyDown);
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.EmailLabel.Location = new System.Drawing.Point(27, 82);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(45, 16);
            this.EmailLabel.TabIndex = 4;
            this.EmailLabel.Text = "Email:";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.PasswordLabel.Location = new System.Drawing.Point(27, 137);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(71, 16);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Text = "Password:";
            // 
            // ConfirmPasswordLabel
            // 
            this.ConfirmPasswordLabel.AutoSize = true;
            this.ConfirmPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmPasswordLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.ConfirmPasswordLabel.Location = new System.Drawing.Point(27, 192);
            this.ConfirmPasswordLabel.Name = "ConfirmPasswordLabel";
            this.ConfirmPasswordLabel.Size = new System.Drawing.Size(119, 16);
            this.ConfirmPasswordLabel.TabIndex = 2;
            this.ConfirmPasswordLabel.Text = "Confirm Password:";
            // 
            // RegisterButton
            // 
            this.RegisterButton.FlatAppearance.BorderSize = 0;
            this.RegisterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegisterButton.Font = new System.Drawing.Font("Marlett", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.RegisterButton.Location = new System.Drawing.Point(174, 245);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(160, 45);
            this.RegisterButton.TabIndex = 1;
            this.RegisterButton.TabStop = false;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = false;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // CapsLockLabel
            // 
            this.CapsLockLabel.AutoSize = true;
            this.CapsLockLabel.Enabled = false;
            this.CapsLockLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CapsLockLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.CapsLockLabel.Location = new System.Drawing.Point(215, 78);
            this.CapsLockLabel.Name = "CapsLockLabel";
            this.CapsLockLabel.Size = new System.Drawing.Size(72, 16);
            this.CapsLockLabel.TabIndex = 0;
            this.CapsLockLabel.Text = "Caps Lock";
            this.CapsLockLabel.Visible = false;
            // 
            // LoginRegisterDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.CapsLockLabel);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.ConfirmPasswordLabel);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.ConfirmPasswordTextBox);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.TitlePanelSeperator);
            this.Name = "LoginRegisterDisplay";
            this.Size = new System.Drawing.Size(510, 290);
            this.TitlePanelSeperator.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel TitlePanelSeperator;
        private System.Windows.Forms.Label TitleLabel;
        private CustomTextBox EmailTextBox;
        private CustomTextBox PasswordTextBox;
        private CustomTextBox ConfirmPasswordTextBox;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label ConfirmPasswordLabel;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Label CapsLockLabel;
    }
}

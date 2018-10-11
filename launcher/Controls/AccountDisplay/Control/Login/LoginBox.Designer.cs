namespace LoESoft.Launcher.Controls.AccountDisplay.Control.Login
{
    partial class LoginBox
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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.AccountNameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.LoginOKButton = new System.Windows.Forms.Button();
            this.CapsLockLabel = new System.Windows.Forms.Label();
            this.LoginCancelButton = new System.Windows.Forms.Button();
            this.PasswordTextBox = new LoESoft.Launcher.Controls.CustomTextBox();
            this.AccountNameTextBox = new LoESoft.Launcher.Controls.CustomTextBox();
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
            this.TitleLabel.Size = new System.Drawing.Size(325, 40);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Login";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AccountNameLabel
            // 
            this.AccountNameLabel.AutoSize = true;
            this.AccountNameLabel.Font = new System.Drawing.Font("DisposableDroid BB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountNameLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.AccountNameLabel.Location = new System.Drawing.Point(24, 56);
            this.AccountNameLabel.Name = "AccountNameLabel";
            this.AccountNameLabel.Size = new System.Drawing.Size(101, 16);
            this.AccountNameLabel.TabIndex = 4;
            this.AccountNameLabel.Text = "Account Name";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("DisposableDroid BB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.PasswordLabel.Location = new System.Drawing.Point(24, 106);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(70, 16);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Text = "Password";
            // 
            // LoginOKButton
            // 
            this.LoginOKButton.BackColor = System.Drawing.Color.DimGray;
            this.LoginOKButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.LoginOKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginOKButton.Font = new System.Drawing.Font("DisposableDroid BB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginOKButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.LoginOKButton.Location = new System.Drawing.Point(27, 175);
            this.LoginOKButton.Name = "LoginOKButton";
            this.LoginOKButton.Size = new System.Drawing.Size(124, 36);
            this.LoginOKButton.TabIndex = 1;
            this.LoginOKButton.TabStop = false;
            this.LoginOKButton.Text = "OK";
            this.LoginOKButton.UseVisualStyleBackColor = false;
            this.LoginOKButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // CapsLockLabel
            // 
            this.CapsLockLabel.AutoSize = true;
            this.CapsLockLabel.Enabled = false;
            this.CapsLockLabel.Font = new System.Drawing.Font("DisposableDroid BB", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CapsLockLabel.ForeColor = System.Drawing.Color.Red;
            this.CapsLockLabel.Location = new System.Drawing.Point(239, 59);
            this.CapsLockLabel.Name = "CapsLockLabel";
            this.CapsLockLabel.Size = new System.Drawing.Size(60, 13);
            this.CapsLockLabel.TabIndex = 0;
            this.CapsLockLabel.Text = "CAPS LOCK";
            this.CapsLockLabel.Visible = false;
            // 
            // LoginCancelButton
            // 
            this.LoginCancelButton.BackColor = System.Drawing.Color.DimGray;
            this.LoginCancelButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.LoginCancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginCancelButton.Font = new System.Drawing.Font("DisposableDroid BB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginCancelButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.LoginCancelButton.Location = new System.Drawing.Point(175, 175);
            this.LoginCancelButton.Name = "LoginCancelButton";
            this.LoginCancelButton.Size = new System.Drawing.Size(124, 36);
            this.LoginCancelButton.TabIndex = 9;
            this.LoginCancelButton.TabStop = false;
            this.LoginCancelButton.Text = "Cancel";
            this.LoginCancelButton.UseVisualStyleBackColor = false;
            this.LoginCancelButton.Click += new System.EventHandler(this.LoginCancelButton_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordTextBox.Font = new System.Drawing.Font("DisposableDroid BB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.PasswordTextBox.Location = new System.Drawing.Point(26, 125);
            this.PasswordTextBox.MaxLength = 64;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = 'x';
            this.PasswordTextBox.Size = new System.Drawing.Size(273, 28);
            this.PasswordTextBox.TabIndex = 6;
            this.PasswordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PasswordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IsKeyDown);
            // 
            // AccountNameTextBox
            // 
            this.AccountNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AccountNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.AccountNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AccountNameTextBox.Font = new System.Drawing.Font("DisposableDroid BB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountNameTextBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.AccountNameTextBox.Location = new System.Drawing.Point(26, 75);
            this.AccountNameTextBox.MaxLength = 32;
            this.AccountNameTextBox.Name = "AccountNameTextBox";
            this.AccountNameTextBox.PasswordChar = 'x';
            this.AccountNameTextBox.Size = new System.Drawing.Size(273, 28);
            this.AccountNameTextBox.TabIndex = 7;
            this.AccountNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LoginBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.LoginCancelButton);
            this.Controls.Add(this.CapsLockLabel);
            this.Controls.Add(this.LoginOKButton);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.AccountNameLabel);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.AccountNameTextBox);
            this.Name = "LoginBox";
            this.Size = new System.Drawing.Size(325, 219);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label TitleLabel;
        private CustomTextBox AccountNameTextBox;
        private CustomTextBox PasswordTextBox;
        private System.Windows.Forms.Label AccountNameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Button LoginOKButton;
        private System.Windows.Forms.Label CapsLockLabel;
        private System.Windows.Forms.Button LoginCancelButton;
    }
}

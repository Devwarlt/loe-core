namespace LoESoft.Launcher.Controls.AccountDisplay
{
    partial class AccountLoginPopUp
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
            this.CloseRegisterButton = new System.Windows.Forms.Button();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.AccountNameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.CapsLockLabel = new System.Windows.Forms.Label();
            this.PasswordTextBox = new LoESoft.Launcher.Controls.CustomTextBox();
            this.AccountNameTextBox = new LoESoft.Launcher.Controls.CustomTextBox();
            this.TitlePanelSeperator.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitlePanelSeperator
            // 
            this.TitlePanelSeperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitlePanelSeperator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TitlePanelSeperator.Controls.Add(this.CloseRegisterButton);
            this.TitlePanelSeperator.Controls.Add(this.TitleLabel);
            this.TitlePanelSeperator.Location = new System.Drawing.Point(-1, -1);
            this.TitlePanelSeperator.Name = "TitlePanelSeperator";
            this.TitlePanelSeperator.Size = new System.Drawing.Size(514, 73);
            this.TitlePanelSeperator.TabIndex = 8;
            // 
            // CloseRegisterButton
            // 
            this.CloseRegisterButton.BackColor = System.Drawing.Color.DimGray;
            this.CloseRegisterButton.FlatAppearance.BorderSize = 0;
            this.CloseRegisterButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.CloseRegisterButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.CloseRegisterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseRegisterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseRegisterButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.CloseRegisterButton.Location = new System.Drawing.Point(475, 3);
            this.CloseRegisterButton.Name = "CloseRegisterButton";
            this.CloseRegisterButton.Size = new System.Drawing.Size(32, 32);
            this.CloseRegisterButton.TabIndex = 1;
            this.CloseRegisterButton.TabStop = false;
            this.CloseRegisterButton.Text = "X";
            this.CloseRegisterButton.UseVisualStyleBackColor = false;
            this.CloseRegisterButton.Click += new System.EventHandler(this.CloseRegisterButton_Click);
            // 
            // TitleLabel
            // 
            this.TitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleLabel.Font = new System.Drawing.Font("DisposableDroid BB", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.TitleLabel.Location = new System.Drawing.Point(24, 3);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(464, 65);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Account Login";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AccountNameLabel
            // 
            this.AccountNameLabel.AutoSize = true;
            this.AccountNameLabel.Font = new System.Drawing.Font("DisposableDroid BB", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountNameLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.AccountNameLabel.Location = new System.Drawing.Point(27, 82);
            this.AccountNameLabel.Name = "AccountNameLabel";
            this.AccountNameLabel.Size = new System.Drawing.Size(79, 13);
            this.AccountNameLabel.TabIndex = 4;
            this.AccountNameLabel.Text = "Account Name";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("DisposableDroid BB", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.PasswordLabel.Location = new System.Drawing.Point(27, 137);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(58, 13);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Text = "Password";
            // 
            // LoginButton
            // 
            this.LoginButton.FlatAppearance.BorderSize = 0;
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton.Font = new System.Drawing.Font("DisposableDroid BB", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.LoginButton.Location = new System.Drawing.Point(174, 194);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(160, 45);
            this.LoginButton.TabIndex = 1;
            this.LoginButton.TabStop = false;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // CapsLockLabel
            // 
            this.CapsLockLabel.AutoSize = true;
            this.CapsLockLabel.Enabled = false;
            this.CapsLockLabel.Font = new System.Drawing.Font("DisposableDroid BB", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CapsLockLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.CapsLockLabel.Location = new System.Drawing.Point(215, 78);
            this.CapsLockLabel.Name = "CapsLockLabel";
            this.CapsLockLabel.Size = new System.Drawing.Size(60, 13);
            this.CapsLockLabel.TabIndex = 0;
            this.CapsLockLabel.Text = "Caps Lock";
            this.CapsLockLabel.Visible = false;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordTextBox.Font = new System.Drawing.Font("DisposableDroid BB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.PasswordTextBox.Location = new System.Drawing.Point(26, 156);
            this.PasswordTextBox.MaxLength = 32;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(458, 28);
            this.PasswordTextBox.TabIndex = 6;
            this.PasswordTextBox.TabStop = false;
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
            this.AccountNameTextBox.Location = new System.Drawing.Point(26, 101);
            this.AccountNameTextBox.Name = "AccountNameTextBox";
            this.AccountNameTextBox.Size = new System.Drawing.Size(458, 28);
            this.AccountNameTextBox.TabIndex = 7;
            this.AccountNameTextBox.TabStop = false;
            this.AccountNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AccountLoginPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.CapsLockLabel);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.AccountNameLabel);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.AccountNameTextBox);
            this.Controls.Add(this.TitlePanelSeperator);
            this.Name = "AccountLoginPopUp";
            this.Size = new System.Drawing.Size(510, 242);
            this.TitlePanelSeperator.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel TitlePanelSeperator;
        private System.Windows.Forms.Label TitleLabel;
        private CustomTextBox AccountNameTextBox;
        private CustomTextBox PasswordTextBox;
        private System.Windows.Forms.Label AccountNameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label CapsLockLabel;
        private System.Windows.Forms.Button CloseRegisterButton;
    }
}

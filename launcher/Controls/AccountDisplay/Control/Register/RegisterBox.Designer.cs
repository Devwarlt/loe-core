namespace LoESoft.Launcher.Controls.AccountDisplay.Control.Register
{
    partial class RegisterBox
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
            this.ConfirmPasswordLabel = new System.Windows.Forms.Label();
            this.RegisterCreateButton = new System.Windows.Forms.Button();
            this.CapsLockLabel = new System.Windows.Forms.Label();
            this.RegisterCancelButton = new System.Windows.Forms.Button();
            this.ConfirmPasswordTextBox = new LoESoft.Launcher.Controls.CustomTextBox();
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
            this.TitleLabel.Location = new System.Drawing.Point(0, -1);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(325, 40);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Register";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AccountNameLabel
            // 
            this.AccountNameLabel.AutoSize = true;
            this.AccountNameLabel.Font = new System.Drawing.Font("DisposableDroid BB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountNameLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.AccountNameLabel.Location = new System.Drawing.Point(23, 57);
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
            this.PasswordLabel.Location = new System.Drawing.Point(23, 104);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(70, 16);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Text = "Password";
            // 
            // ConfirmPasswordLabel
            // 
            this.ConfirmPasswordLabel.AutoSize = true;
            this.ConfirmPasswordLabel.Font = new System.Drawing.Font("DisposableDroid BB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmPasswordLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.ConfirmPasswordLabel.Location = new System.Drawing.Point(23, 154);
            this.ConfirmPasswordLabel.Name = "ConfirmPasswordLabel";
            this.ConfirmPasswordLabel.Size = new System.Drawing.Size(127, 16);
            this.ConfirmPasswordLabel.TabIndex = 2;
            this.ConfirmPasswordLabel.Text = "Confirm Password";
            // 
            // RegisterCreateButton
            // 
            this.RegisterCreateButton.BackColor = System.Drawing.Color.DimGray;
            this.RegisterCreateButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.RegisterCreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegisterCreateButton.Font = new System.Drawing.Font("DisposableDroid BB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterCreateButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.RegisterCreateButton.Location = new System.Drawing.Point(26, 223);
            this.RegisterCreateButton.Name = "RegisterCreateButton";
            this.RegisterCreateButton.Size = new System.Drawing.Size(124, 36);
            this.RegisterCreateButton.TabIndex = 1;
            this.RegisterCreateButton.TabStop = false;
            this.RegisterCreateButton.Text = "Create";
            this.RegisterCreateButton.UseVisualStyleBackColor = false;
            this.RegisterCreateButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // CapsLockLabel
            // 
            this.CapsLockLabel.AutoSize = true;
            this.CapsLockLabel.Enabled = false;
            this.CapsLockLabel.Font = new System.Drawing.Font("DisposableDroid BB", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CapsLockLabel.ForeColor = System.Drawing.Color.Red;
            this.CapsLockLabel.Location = new System.Drawing.Point(232, 57);
            this.CapsLockLabel.Name = "CapsLockLabel";
            this.CapsLockLabel.Size = new System.Drawing.Size(60, 13);
            this.CapsLockLabel.TabIndex = 0;
            this.CapsLockLabel.Text = "CAPS LOCK";
            this.CapsLockLabel.Visible = false;
            // 
            // RegisterCancelButton
            // 
            this.RegisterCancelButton.BackColor = System.Drawing.Color.DimGray;
            this.RegisterCancelButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.RegisterCancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegisterCancelButton.Font = new System.Drawing.Font("DisposableDroid BB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterCancelButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.RegisterCancelButton.Location = new System.Drawing.Point(175, 223);
            this.RegisterCancelButton.Name = "RegisterCancelButton";
            this.RegisterCancelButton.Size = new System.Drawing.Size(124, 36);
            this.RegisterCancelButton.TabIndex = 8;
            this.RegisterCancelButton.TabStop = false;
            this.RegisterCancelButton.Text = "Cancel";
            this.RegisterCancelButton.UseVisualStyleBackColor = false;
            this.RegisterCancelButton.Click += new System.EventHandler(this.RegisterCancelButton_Click);
            // 
            // ConfirmPasswordTextBox
            // 
            this.ConfirmPasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmPasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.ConfirmPasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConfirmPasswordTextBox.Font = new System.Drawing.Font("DisposableDroid BB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmPasswordTextBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.ConfirmPasswordTextBox.Location = new System.Drawing.Point(26, 173);
            this.ConfirmPasswordTextBox.MaxLength = 64;
            this.ConfirmPasswordTextBox.Name = "ConfirmPasswordTextBox";
            this.ConfirmPasswordTextBox.PasswordChar = 'x';
            this.ConfirmPasswordTextBox.Size = new System.Drawing.Size(273, 28);
            this.ConfirmPasswordTextBox.TabIndex = 5;
            this.ConfirmPasswordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ConfirmPasswordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IsKeyDown);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordTextBox.Font = new System.Drawing.Font("DisposableDroid BB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.PasswordTextBox.Location = new System.Drawing.Point(26, 123);
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
            // RegisterBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.RegisterCancelButton);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.CapsLockLabel);
            this.Controls.Add(this.RegisterCreateButton);
            this.Controls.Add(this.ConfirmPasswordLabel);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.AccountNameLabel);
            this.Controls.Add(this.ConfirmPasswordTextBox);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.AccountNameTextBox);
            this.Name = "RegisterBox";
            this.Size = new System.Drawing.Size(325, 275);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label TitleLabel;
        private CustomTextBox AccountNameTextBox;
        private CustomTextBox PasswordTextBox;
        private CustomTextBox ConfirmPasswordTextBox;
        private System.Windows.Forms.Label AccountNameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label ConfirmPasswordLabel;
        private System.Windows.Forms.Button RegisterCreateButton;
        private System.Windows.Forms.Label CapsLockLabel;
        private System.Windows.Forms.Button RegisterCancelButton;
    }
}

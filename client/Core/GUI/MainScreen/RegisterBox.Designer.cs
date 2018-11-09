﻿namespace LoESoft.Client.Core.GUI.MainScreen
{
    partial class RegisterBox
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.TitleLabel = new System.Windows.Forms.Label();
            this.AccountNameLabel = new System.Windows.Forms.Label();
            this.AccountNameCapsLockLabel = new System.Windows.Forms.Label();
            this.AccountNameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.ConfirmPasswordLabel = new System.Windows.Forms.Label();
            this.ConfirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.RegisterCancelButton = new System.Windows.Forms.Button();
            this.RegisterCreateButton = new System.Windows.Forms.Button();
            this.PasswordCapsLockLabel = new System.Windows.Forms.Label();
            this.ConfirmPasswordCapsLockLabel = new System.Windows.Forms.Label();
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
            this.TitleLabel.TabIndex = 1;
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
            this.AccountNameLabel.TabIndex = 5;
            this.AccountNameLabel.Text = "Account Name";
            // 
            // AccountNameCapsLockLabel
            // 
            this.AccountNameCapsLockLabel.AutoSize = true;
            this.AccountNameCapsLockLabel.Enabled = false;
            this.AccountNameCapsLockLabel.Font = new System.Drawing.Font("DisposableDroid BB", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountNameCapsLockLabel.ForeColor = System.Drawing.Color.Red;
            this.AccountNameCapsLockLabel.Location = new System.Drawing.Point(232, 57);
            this.AccountNameCapsLockLabel.Name = "AccountNameCapsLockLabel";
            this.AccountNameCapsLockLabel.Size = new System.Drawing.Size(60, 13);
            this.AccountNameCapsLockLabel.TabIndex = 6;
            this.AccountNameCapsLockLabel.Text = "CAPS LOCK";
            this.AccountNameCapsLockLabel.Visible = false;
            // 
            // AccountNameTextBox
            // 
            this.AccountNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AccountNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.AccountNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AccountNameTextBox.Font = new System.Drawing.Font("DisposableDroid BB", 15.75F);
            this.AccountNameTextBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.AccountNameTextBox.Location = new System.Drawing.Point(26, 75);
            this.AccountNameTextBox.MaxLength = 32;
            this.AccountNameTextBox.Name = "AccountNameTextBox";
            this.AccountNameTextBox.PasswordChar = 'x';
            this.AccountNameTextBox.Size = new System.Drawing.Size(273, 28);
            this.AccountNameTextBox.TabIndex = 8;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("DisposableDroid BB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.PasswordLabel.Location = new System.Drawing.Point(23, 104);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(70, 16);
            this.PasswordLabel.TabIndex = 9;
            this.PasswordLabel.Text = "Password";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordTextBox.Font = new System.Drawing.Font("DisposableDroid BB", 15.75F);
            this.PasswordTextBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.PasswordTextBox.Location = new System.Drawing.Point(26, 123);
            this.PasswordTextBox.MaxLength = 32;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = 'x';
            this.PasswordTextBox.Size = new System.Drawing.Size(273, 28);
            this.PasswordTextBox.TabIndex = 10;
            // 
            // ConfirmPasswordLabel
            // 
            this.ConfirmPasswordLabel.AutoSize = true;
            this.ConfirmPasswordLabel.Font = new System.Drawing.Font("DisposableDroid BB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmPasswordLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.ConfirmPasswordLabel.Location = new System.Drawing.Point(23, 154);
            this.ConfirmPasswordLabel.Name = "ConfirmPasswordLabel";
            this.ConfirmPasswordLabel.Size = new System.Drawing.Size(127, 16);
            this.ConfirmPasswordLabel.TabIndex = 11;
            this.ConfirmPasswordLabel.Text = "Confirm Password";
            // 
            // ConfirmPasswordTextBox
            // 
            this.ConfirmPasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmPasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.ConfirmPasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConfirmPasswordTextBox.Font = new System.Drawing.Font("DisposableDroid BB", 15.75F);
            this.ConfirmPasswordTextBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.ConfirmPasswordTextBox.Location = new System.Drawing.Point(26, 173);
            this.ConfirmPasswordTextBox.MaxLength = 32;
            this.ConfirmPasswordTextBox.Name = "ConfirmPasswordTextBox";
            this.ConfirmPasswordTextBox.PasswordChar = 'x';
            this.ConfirmPasswordTextBox.Size = new System.Drawing.Size(273, 28);
            this.ConfirmPasswordTextBox.TabIndex = 12;
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
            this.RegisterCancelButton.TabIndex = 14;
            this.RegisterCancelButton.TabStop = false;
            this.RegisterCancelButton.Text = "Cancel";
            this.RegisterCancelButton.UseVisualStyleBackColor = false;
            this.RegisterCancelButton.Click += new System.EventHandler(this.RegisterCancelButton_Click);
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
            this.RegisterCreateButton.TabIndex = 13;
            this.RegisterCreateButton.TabStop = false;
            this.RegisterCreateButton.Text = "Create";
            this.RegisterCreateButton.UseVisualStyleBackColor = false;
            this.RegisterCreateButton.Click += new System.EventHandler(this.RegisterCreateButton_Click);
            // 
            // PasswordCapsLockLabel
            // 
            this.PasswordCapsLockLabel.AutoSize = true;
            this.PasswordCapsLockLabel.Enabled = false;
            this.PasswordCapsLockLabel.Font = new System.Drawing.Font("DisposableDroid BB", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordCapsLockLabel.ForeColor = System.Drawing.Color.Red;
            this.PasswordCapsLockLabel.Location = new System.Drawing.Point(232, 107);
            this.PasswordCapsLockLabel.Name = "PasswordCapsLockLabel";
            this.PasswordCapsLockLabel.Size = new System.Drawing.Size(60, 13);
            this.PasswordCapsLockLabel.TabIndex = 6;
            this.PasswordCapsLockLabel.Text = "CAPS LOCK";
            this.PasswordCapsLockLabel.Visible = false;
            // 
            // ConfirmPasswordCapsLockLabel
            // 
            this.ConfirmPasswordCapsLockLabel.AutoSize = true;
            this.ConfirmPasswordCapsLockLabel.Enabled = false;
            this.ConfirmPasswordCapsLockLabel.Font = new System.Drawing.Font("DisposableDroid BB", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmPasswordCapsLockLabel.ForeColor = System.Drawing.Color.Red;
            this.ConfirmPasswordCapsLockLabel.Location = new System.Drawing.Point(232, 156);
            this.ConfirmPasswordCapsLockLabel.Name = "ConfirmPasswordCapsLockLabel";
            this.ConfirmPasswordCapsLockLabel.Size = new System.Drawing.Size(60, 13);
            this.ConfirmPasswordCapsLockLabel.TabIndex = 6;
            this.ConfirmPasswordCapsLockLabel.Text = "CAPS LOCK";
            this.ConfirmPasswordCapsLockLabel.Visible = false;
            // 
            // RegisterBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.RegisterCancelButton);
            this.Controls.Add(this.RegisterCreateButton);
            this.Controls.Add(this.ConfirmPasswordTextBox);
            this.Controls.Add(this.ConfirmPasswordLabel);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.AccountNameTextBox);
            this.Controls.Add(this.ConfirmPasswordCapsLockLabel);
            this.Controls.Add(this.PasswordCapsLockLabel);
            this.Controls.Add(this.AccountNameCapsLockLabel);
            this.Controls.Add(this.AccountNameLabel);
            this.Controls.Add(this.TitleLabel);
            this.Name = "RegisterBox";
            this.Size = new System.Drawing.Size(325, 275);
            this.Load += new System.EventHandler(this.RegisterBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label AccountNameLabel;
        private System.Windows.Forms.Label AccountNameCapsLockLabel;
        private System.Windows.Forms.TextBox AccountNameTextBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label ConfirmPasswordLabel;
        private System.Windows.Forms.TextBox ConfirmPasswordTextBox;
        private System.Windows.Forms.Button RegisterCancelButton;
        private System.Windows.Forms.Button RegisterCreateButton;
        private System.Windows.Forms.Label PasswordCapsLockLabel;
        private System.Windows.Forms.Label ConfirmPasswordCapsLockLabel;
    }
}

namespace LoESoft.Client.Core.GUI.MainScreen
{
    partial class LoginBox
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
            this.LoginCancelButton = new System.Windows.Forms.Button();
            this.LoginOKButton = new System.Windows.Forms.Button();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.PasswordCapsLockLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleLabel.BackColor = System.Drawing.Color.Gray;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.TitleLabel.Location = new System.Drawing.Point(0, 0);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(325, 40);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "Login";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AccountNameLabel
            // 
            this.AccountNameLabel.AutoSize = true;
            this.AccountNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountNameLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.AccountNameLabel.Location = new System.Drawing.Point(24, 56);
            this.AccountNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AccountNameLabel.Name = "AccountNameLabel";
            this.AccountNameLabel.Size = new System.Drawing.Size(114, 20);
            this.AccountNameLabel.TabIndex = 5;
            this.AccountNameLabel.Text = "Account Name";
            // 
            // AccountNameCapsLockLabel
            // 
            this.AccountNameCapsLockLabel.AutoSize = true;
            this.AccountNameCapsLockLabel.Enabled = false;
            this.AccountNameCapsLockLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountNameCapsLockLabel.ForeColor = System.Drawing.Color.Red;
            this.AccountNameCapsLockLabel.Location = new System.Drawing.Point(239, 59);
            this.AccountNameCapsLockLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AccountNameCapsLockLabel.Name = "AccountNameCapsLockLabel";
            this.AccountNameCapsLockLabel.Size = new System.Drawing.Size(81, 16);
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
            this.AccountNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountNameTextBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.AccountNameTextBox.Location = new System.Drawing.Point(26, 74);
            this.AccountNameTextBox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.AccountNameTextBox.MaxLength = 32;
            this.AccountNameTextBox.Name = "AccountNameTextBox";
            this.AccountNameTextBox.Size = new System.Drawing.Size(273, 29);
            this.AccountNameTextBox.TabIndex = 7;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.PasswordLabel.Location = new System.Drawing.Point(24, 106);
            this.PasswordLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(78, 20);
            this.PasswordLabel.TabIndex = 9;
            this.PasswordLabel.Text = "Password";
            // 
            // LoginCancelButton
            // 
            this.LoginCancelButton.BackColor = System.Drawing.Color.DimGray;
            this.LoginCancelButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.LoginCancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginCancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginCancelButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.LoginCancelButton.Location = new System.Drawing.Point(175, 175);
            this.LoginCancelButton.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.LoginCancelButton.Name = "LoginCancelButton";
            this.LoginCancelButton.Size = new System.Drawing.Size(124, 35);
            this.LoginCancelButton.TabIndex = 11;
            this.LoginCancelButton.TabStop = false;
            this.LoginCancelButton.Text = "Cancel";
            this.LoginCancelButton.UseVisualStyleBackColor = false;
            this.LoginCancelButton.Click += new System.EventHandler(this.LoginCancelButton_Click);
            // 
            // LoginOKButton
            // 
            this.LoginOKButton.BackColor = System.Drawing.Color.DimGray;
            this.LoginOKButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.LoginOKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginOKButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginOKButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.LoginOKButton.Location = new System.Drawing.Point(26, 175);
            this.LoginOKButton.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.LoginOKButton.Name = "LoginOKButton";
            this.LoginOKButton.Size = new System.Drawing.Size(124, 35);
            this.LoginOKButton.TabIndex = 10;
            this.LoginOKButton.TabStop = false;
            this.LoginOKButton.Text = "OK";
            this.LoginOKButton.UseVisualStyleBackColor = false;
            this.LoginOKButton.Click += new System.EventHandler(this.LoginOKButton_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.PasswordTextBox.Location = new System.Drawing.Point(26, 125);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.PasswordTextBox.MaxLength = 32;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = 'x';
            this.PasswordTextBox.Size = new System.Drawing.Size(273, 29);
            this.PasswordTextBox.TabIndex = 12;
            // 
            // PasswordCapsLockLabel
            // 
            this.PasswordCapsLockLabel.AutoSize = true;
            this.PasswordCapsLockLabel.Enabled = false;
            this.PasswordCapsLockLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordCapsLockLabel.ForeColor = System.Drawing.Color.Red;
            this.PasswordCapsLockLabel.Location = new System.Drawing.Point(239, 108);
            this.PasswordCapsLockLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PasswordCapsLockLabel.Name = "PasswordCapsLockLabel";
            this.PasswordCapsLockLabel.Size = new System.Drawing.Size(81, 16);
            this.PasswordCapsLockLabel.TabIndex = 13;
            this.PasswordCapsLockLabel.Text = "CAPS LOCK";
            this.PasswordCapsLockLabel.Visible = false;
            // 
            // LoginBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.PasswordCapsLockLabel);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.LoginCancelButton);
            this.Controls.Add(this.LoginOKButton);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.AccountNameTextBox);
            this.Controls.Add(this.AccountNameCapsLockLabel);
            this.Controls.Add(this.AccountNameLabel);
            this.Controls.Add(this.TitleLabel);
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "LoginBox";
            this.Size = new System.Drawing.Size(325, 227);
            this.Load += new System.EventHandler(this.LoginBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label AccountNameLabel;
        private System.Windows.Forms.Label AccountNameCapsLockLabel;
        private System.Windows.Forms.TextBox AccountNameTextBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Button LoginCancelButton;
        private System.Windows.Forms.Button LoginOKButton;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label PasswordCapsLockLabel;
    }
}

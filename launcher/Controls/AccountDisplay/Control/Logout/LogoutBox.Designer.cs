namespace LoESoft.Launcher.Controls.AccountDisplay.Control.Logout
{
    partial class LogoutBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogoutBox));
            this.TitleLabel = new System.Windows.Forms.Label();
            this.AccountNameLabel = new System.Windows.Forms.Label();
            this.LoginOKButton = new System.Windows.Forms.Button();
            this.LoginCancelButton = new System.Windows.Forms.Button();
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
            this.TitleLabel.Text = "Logout";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AccountNameLabel
            // 
            this.AccountNameLabel.Font = new System.Drawing.Font("DisposableDroid BB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountNameLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.AccountNameLabel.Location = new System.Drawing.Point(0, 40);
            this.AccountNameLabel.Name = "AccountNameLabel";
            this.AccountNameLabel.Size = new System.Drawing.Size(325, 133);
            this.AccountNameLabel.TabIndex = 4;
            this.AccountNameLabel.Text = resources.GetString("AccountNameLabel.Text");
            this.AccountNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginOKButton
            // 
            this.LoginOKButton.BackColor = System.Drawing.Color.DimGray;
            this.LoginOKButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.LoginOKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginOKButton.Font = new System.Drawing.Font("DisposableDroid BB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginOKButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.LoginOKButton.Location = new System.Drawing.Point(27, 192);
            this.LoginOKButton.Name = "LoginOKButton";
            this.LoginOKButton.Size = new System.Drawing.Size(124, 36);
            this.LoginOKButton.TabIndex = 1;
            this.LoginOKButton.TabStop = false;
            this.LoginOKButton.Text = "OK";
            this.LoginOKButton.UseVisualStyleBackColor = false;
            this.LoginOKButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // LoginCancelButton
            // 
            this.LoginCancelButton.BackColor = System.Drawing.Color.DimGray;
            this.LoginCancelButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.LoginCancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginCancelButton.Font = new System.Drawing.Font("DisposableDroid BB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginCancelButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.LoginCancelButton.Location = new System.Drawing.Point(175, 192);
            this.LoginCancelButton.Name = "LoginCancelButton";
            this.LoginCancelButton.Size = new System.Drawing.Size(124, 36);
            this.LoginCancelButton.TabIndex = 9;
            this.LoginCancelButton.TabStop = false;
            this.LoginCancelButton.Text = "Cancel";
            this.LoginCancelButton.UseVisualStyleBackColor = false;
            this.LoginCancelButton.Click += new System.EventHandler(this.LogoutCancelButton_Click);
            // 
            // LogoutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.LoginCancelButton);
            this.Controls.Add(this.LoginOKButton);
            this.Controls.Add(this.AccountNameLabel);
            this.Name = "LogoutBox";
            this.Size = new System.Drawing.Size(325, 244);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label AccountNameLabel;
        private System.Windows.Forms.Button LoginOKButton;
        private System.Windows.Forms.Button LoginCancelButton;
    }
}

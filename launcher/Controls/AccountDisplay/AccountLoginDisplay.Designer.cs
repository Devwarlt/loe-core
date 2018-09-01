namespace LoESoft.Launcher.Controls.AccountDisplay
{
    partial class AccountLoginDisplay
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
            this.TitlePanelSeperator = new System.Windows.Forms.Panel();
            this.LoginButton = new System.Windows.Forms.Button();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.TitleLabel = new System.Windows.Forms.Label();
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
            this.TitlePanelSeperator.Size = new System.Drawing.Size(352, 73);
            this.TitlePanelSeperator.TabIndex = 1;
            // 
            // LoginButton
            // 
            this.LoginButton.FlatAppearance.BorderSize = 0;
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton.Font = new System.Drawing.Font("Marlett", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.LoginButton.Location = new System.Drawing.Point(6, 82);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(160, 75);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = false;
            // 
            // RegisterButton
            // 
            this.RegisterButton.FlatAppearance.BorderSize = 0;
            this.RegisterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegisterButton.Font = new System.Drawing.Font("Marlett", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.RegisterButton.Location = new System.Drawing.Point(183, 82);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(160, 75);
            this.RegisterButton.TabIndex = 2;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = false;
            // 
            // TitleLabel
            // 
            this.TitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleLabel.Font = new System.Drawing.Font("Marlett", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.TitleLabel.Location = new System.Drawing.Point(24, 3);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(302, 65);
            this.TitleLabel.TabIndex = 9;
            this.TitleLabel.Text = "Login";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AccountLoginDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.TitlePanelSeperator);
            this.Name = "AccountLoginDisplay";
            this.Size = new System.Drawing.Size(348, 168);
            this.TitlePanelSeperator.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TitlePanelSeperator;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Label TitleLabel;
    }
}

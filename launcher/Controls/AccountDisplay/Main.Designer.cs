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
            this.LoginButton = new System.Windows.Forms.Button();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.RegisterBox = new LoESoft.Launcher.Controls.AccountDisplay.RegisterBox();
            this.LoginBox = new LoESoft.Launcher.Controls.AccountDisplay.LoginBox();
            this.PopUpBox = new LoESoft.Launcher.Controls.AccountDisplay.PopUpBox();
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
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.DimGray;
            this.LoginButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton.Font = new System.Drawing.Font("DisposableDroid BB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.LoginButton.Location = new System.Drawing.Point(23, 479);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(160, 36);
            this.LoginButton.TabIndex = 0;
            this.LoginButton.TabStop = false;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // RegisterButton
            // 
            this.RegisterButton.BackColor = System.Drawing.Color.DimGray;
            this.RegisterButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.RegisterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegisterButton.Font = new System.Drawing.Font("DisposableDroid BB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.RegisterButton.Location = new System.Drawing.Point(23, 537);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(160, 36);
            this.RegisterButton.TabIndex = 0;
            this.RegisterButton.TabStop = false;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = false;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // RegisterBox
            // 
            this.RegisterBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RegisterBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RegisterBox.Location = new System.Drawing.Point(100, 125);
            this.RegisterBox.Name = "RegisterBox";
            this.RegisterBox.Size = new System.Drawing.Size(400, 285);
            this.RegisterBox.TabIndex = 0;
            this.RegisterBox.TabStop = false;
            // 
            // LoginBox
            // 
            this.LoginBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LoginBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LoginBox.Location = new System.Drawing.Point(100, 125);
            this.LoginBox.Name = "LoginBox";
            this.LoginBox.Size = new System.Drawing.Size(400, 224);
            this.LoginBox.TabIndex = 0;
            this.LoginBox.TabStop = false;
            // 
            // PopUpBox
            // 
            this.PopUpBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PopUpBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PopUpBox.Location = new System.Drawing.Point(100, 165);
            this.PopUpBox.Name = "PopUpBox";
            this.PopUpBox.Settings = null;
            this.PopUpBox.Size = new System.Drawing.Size(400, 242);
            this.PopUpBox.TabIndex = 5;
            this.PopUpBox.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.PopUpBox);
            this.Controls.Add(this.LoginBox);
            this.Controls.Add(this.RegisterBox);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.TitleLabel);
            this.Name = "Main";
            this.Size = new System.Drawing.Size(600, 600);
            this.EnabledChanged += new System.EventHandler(this.Main_EnabledChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Button RegisterButton;
        private RegisterBox RegisterBox;
        private LoginBox LoginBox;
        private PopUpBox PopUpBox;
    }
}

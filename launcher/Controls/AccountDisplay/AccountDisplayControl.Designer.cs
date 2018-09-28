namespace LoESoft.Launcher.Controls.AccountDisplay
{
    partial class AccountDisplayControl
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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.PopUpDisplay = new LoESoft.Launcher.Controls.AccountDisplay.PopUpDisplay();
            this.AccountRegisterPopUp = new LoESoft.Launcher.Controls.AccountDisplay.AccountRegisterPopUp();
            this.CurrentAcccountDisplay = new LoESoft.Launcher.Controls.AccountDisplay.CurrentAcccountDisplay();
            this.AccountLoginRegisterDisplay = new LoESoft.Launcher.Controls.AccountDisplay.AccountLoginRegisterDisplay();
            this.TitlePanelSeperator.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitlePanelSeperator
            // 
            this.TitlePanelSeperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitlePanelSeperator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TitlePanelSeperator.Controls.Add(this.TitleLabel);
            this.TitlePanelSeperator.Location = new System.Drawing.Point(-1, 1);
            this.TitlePanelSeperator.Name = "TitlePanelSeperator";
            this.TitlePanelSeperator.Size = new System.Drawing.Size(1025, 75);
            this.TitlePanelSeperator.TabIndex = 1;
            // 
            // TitleLabel
            // 
            this.TitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleLabel.Font = new System.Drawing.Font("DisposableDroid BB", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.TitleLabel.Location = new System.Drawing.Point(366, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(291, 73);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Account";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PopUpDisplay
            // 
            this.PopUpDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PopUpDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PopUpDisplay.Location = new System.Drawing.Point(240, 227);
            this.PopUpDisplay.Name = "PopUpDisplay";
            this.PopUpDisplay.Size = new System.Drawing.Size(546, 149);
            this.PopUpDisplay.TabIndex = 4;
            // 
            // LoginRegisterDisplay
            // 
            this.AccountRegisterPopUp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AccountRegisterPopUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AccountRegisterPopUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AccountRegisterPopUp.Enabled = false;
            this.AccountRegisterPopUp.Location = new System.Drawing.Point(256, 155);
            this.AccountRegisterPopUp.Name = "LoginRegisterDisplay";
            this.AccountRegisterPopUp.Size = new System.Drawing.Size(510, 290);
            this.AccountRegisterPopUp.TabIndex = 2;
            this.AccountRegisterPopUp.TabStop = false;
            this.AccountRegisterPopUp.Visible = false;
            // 
            // CurrentAcccountDisplay
            // 
            this.CurrentAcccountDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CurrentAcccountDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CurrentAcccountDisplay.Location = new System.Drawing.Point(0, 76);
            this.CurrentAcccountDisplay.Name = "CurrentAcccountDisplay";
            this.CurrentAcccountDisplay.Size = new System.Drawing.Size(1025, 524);
            this.CurrentAcccountDisplay.TabIndex = 5;
            this.CurrentAcccountDisplay.Visible = false;
            // 
            // AccountLoginDisplay
            // 
            this.AccountLoginRegisterDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AccountLoginRegisterDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AccountLoginRegisterDisplay.Location = new System.Drawing.Point(343, 263);
            this.AccountLoginRegisterDisplay.Name = "AccountLoginDisplay";
            this.AccountLoginRegisterDisplay.Size = new System.Drawing.Size(339, 85);
            this.AccountLoginRegisterDisplay.TabIndex = 6;
            // 
            // AccountDisplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.TitlePanelSeperator);
            this.Controls.Add(this.PopUpDisplay);
            this.Controls.Add(this.AccountLoginRegisterDisplay);
            this.Controls.Add(this.AccountRegisterPopUp);
            this.Controls.Add(this.CurrentAcccountDisplay);
            this.Name = "AccountDisplayControl";
            this.Size = new System.Drawing.Size(1023, 600);
            this.EnabledChanged += new System.EventHandler(this.AccountDisplayControl_EnabledChanged);
            this.TitlePanelSeperator.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel TitlePanelSeperator;
        private System.Windows.Forms.Label TitleLabel;
        public AccountRegisterPopUp AccountRegisterPopUp;
        public PopUpDisplay PopUpDisplay;
        public CurrentAcccountDisplay CurrentAcccountDisplay;
        public AccountLoginRegisterDisplay AccountLoginRegisterDisplay;
    }
}

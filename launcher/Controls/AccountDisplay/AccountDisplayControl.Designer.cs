﻿namespace LoESoft.Launcher.Controls.AccountDisplay
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
            this.CurrentAccountDisplay = new LoESoft.Launcher.Controls.AccountDisplay.CurrentAcccountDisplay();
            this.AccountLoginDisplay = new LoESoft.Launcher.Controls.AccountDisplay.AccountLoginDisplay();
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
            this.TitlePanelSeperator.TabIndex = 0;
            // 
            // TitleLabel
            // 
            this.TitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleLabel.Font = new System.Drawing.Font("Marlett", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.TitleLabel.Location = new System.Drawing.Point(366, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(291, 73);
            this.TitleLabel.TabIndex = 4;
            this.TitleLabel.Text = "Account Settings";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CurrentAccountDisplay
            // 
            this.CurrentAccountDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CurrentAccountDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CurrentAccountDisplay.Location = new System.Drawing.Point(-1, 75);
            this.CurrentAccountDisplay.Name = "CurrentAccountDisplay";
            this.CurrentAccountDisplay.Size = new System.Drawing.Size(1025, 526);
            this.CurrentAccountDisplay.TabIndex = 2;
            // 
            // AccountLoginDisplay
            // 
            this.AccountLoginDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AccountLoginDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AccountLoginDisplay.Location = new System.Drawing.Point(337, 216);
            this.AccountLoginDisplay.Name = "AccountLoginDisplay";
            this.AccountLoginDisplay.Size = new System.Drawing.Size(348, 168);
            this.AccountLoginDisplay.TabIndex = 4;
            // 
            // AccountDisplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.AccountLoginDisplay);
            this.Controls.Add(this.TitlePanelSeperator);
            this.Controls.Add(this.CurrentAccountDisplay);
            this.Name = "AccountDisplayControl";
            this.Size = new System.Drawing.Size(1023, 600);
            this.EnabledChanged += new System.EventHandler(this.AccountDisplayControl_EnabledChanged);
            this.TitlePanelSeperator.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel TitlePanelSeperator;
        private System.Windows.Forms.Label TitleLabel;
        private CurrentAcccountDisplay CurrentAccountDisplay;
        private AccountLoginDisplay AccountLoginDisplay;
    }
}

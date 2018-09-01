using LoESoft.Launcher.Controls;
using LoESoft.Launcher.Controls.AccountDisplay;
using LoESoft.Launcher.Controls.HomeDisplay;
using LoESoft.Launcher.Controls.OptionsDisplay;

namespace LoESoft.Launcher
{
    partial class LauncherForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                components?.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.ButtonsPanel = new System.Windows.Forms.Panel();
            this.LauncherVersionLabel = new System.Windows.Forms.Label();
            this.ButtonSelectedDisplay = new System.Windows.Forms.Panel();
            this.OptionsButton = new LoESoft.Launcher.Controls.ExtendedButton();
            this.OptionsDisplay = new LoESoft.Launcher.Controls.OptionsDisplay.OptionsDisplayControl();
            this.AccountButton = new LoESoft.Launcher.Controls.ExtendedButton();
            this.AccountDisplay = new LoESoft.Launcher.Controls.AccountDisplay.AccountDisplayControl();
            this.HomeButton = new LoESoft.Launcher.Controls.ExtendedButton();
            this.ButtonsPanelTitle = new System.Windows.Forms.Panel();
            this.ButtonPanelTitleLabel = new System.Windows.Forms.Label();
            this.HomeDisplay = new LoESoft.Launcher.Controls.HomeDisplay.HomeDisplayControl();
            this.ButtonsPanel.SuspendLayout();
            this.ButtonsPanelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ButtonsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ButtonsPanel.Controls.Add(this.LauncherVersionLabel);
            this.ButtonsPanel.Controls.Add(this.ButtonSelectedDisplay);
            this.ButtonsPanel.Controls.Add(this.OptionsButton);
            this.ButtonsPanel.Controls.Add(this.AccountButton);
            this.ButtonsPanel.Controls.Add(this.HomeButton);
            this.ButtonsPanel.Controls.Add(this.ButtonsPanelTitle);
            this.ButtonsPanel.Location = new System.Drawing.Point(0, 0);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(175, 600);
            this.ButtonsPanel.TabIndex = 3;
            // 
            // LauncherVersionLabel
            // 
            this.LauncherVersionLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LauncherVersionLabel.ForeColor = System.Drawing.Color.Gray;
            this.LauncherVersionLabel.Location = new System.Drawing.Point(0, 523);
            this.LauncherVersionLabel.Name = "LauncherVersionLabel";
            this.LauncherVersionLabel.Size = new System.Drawing.Size(173, 74);
            this.LauncherVersionLabel.TabIndex = 0;
            this.LauncherVersionLabel.Text = "Version: ";
            this.LauncherVersionLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // ButtonSelectedDisplay
            // 
            this.ButtonSelectedDisplay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ButtonSelectedDisplay.BackColor = System.Drawing.Color.Gray;
            this.ButtonSelectedDisplay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonSelectedDisplay.Location = new System.Drawing.Point(0, 75);
            this.ButtonSelectedDisplay.Name = "ButtonSelectedDisplay";
            this.ButtonSelectedDisplay.Size = new System.Drawing.Size(5, 75);
            this.ButtonSelectedDisplay.TabIndex = 1;
            // 
            // OptionsButton
            // 
            this.OptionsButton.Display = this.OptionsDisplay;
            this.OptionsButton.FlatAppearance.BorderSize = 0;
            this.OptionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OptionsButton.Font = new System.Drawing.Font("Marlett", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptionsButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.OptionsButton.Location = new System.Drawing.Point(0, 225);
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Selected = false;
            this.OptionsButton.Size = new System.Drawing.Size(174, 75);
            this.OptionsButton.TabIndex = 2;
            this.OptionsButton.TabStop = false;
            this.OptionsButton.Text = "Options";
            this.OptionsButton.UseVisualStyleBackColor = false;
            this.OptionsButton.Click += new System.EventHandler(this.ChangeButtonSelected);
            // 
            // OptionsDisplay
            // 
            this.OptionsDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OptionsDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.OptionsDisplay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OptionsDisplay.Enabled = false;
            this.OptionsDisplay.Location = new System.Drawing.Point(177, 0);
            this.OptionsDisplay.Name = "OptionsDisplay";
            this.OptionsDisplay.Size = new System.Drawing.Size(1023, 600);
            this.OptionsDisplay.TabIndex = 1;
            this.OptionsDisplay.TabStop = false;
            this.OptionsDisplay.Visible = false;
            // 
            // AccountButton
            // 
            this.AccountButton.Display = this.AccountDisplay;
            this.AccountButton.FlatAppearance.BorderSize = 0;
            this.AccountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AccountButton.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.AccountButton.Location = new System.Drawing.Point(0, 150);
            this.AccountButton.Name = "AccountButton";
            this.AccountButton.Selected = false;
            this.AccountButton.Size = new System.Drawing.Size(174, 75);
            this.AccountButton.TabIndex = 3;
            this.AccountButton.TabStop = false;
            this.AccountButton.Text = "Account";
            this.AccountButton.UseVisualStyleBackColor = false;
            this.AccountButton.Click += new System.EventHandler(this.ChangeButtonSelected);
            // 
            // AccountDisplay
            // 
            this.AccountDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AccountDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.AccountDisplay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AccountDisplay.Enabled = false;
            this.AccountDisplay.Location = new System.Drawing.Point(177, 0);
            this.AccountDisplay.Name = "AccountDisplay";
            this.AccountDisplay.Size = new System.Drawing.Size(1023, 600);
            this.AccountDisplay.TabIndex = 2;
            this.AccountDisplay.TabStop = false;
            this.AccountDisplay.Visible = false;
            // 
            // HomeButton
            // 
            this.HomeButton.Display = this.HomeDisplay;
            this.HomeButton.Enabled = false;
            this.HomeButton.FlatAppearance.BorderSize = 0;
            this.HomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeButton.Font = new System.Drawing.Font("Marlett", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.HomeButton.Location = new System.Drawing.Point(0, 75);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Selected = true;
            this.HomeButton.Size = new System.Drawing.Size(174, 75);
            this.HomeButton.TabIndex = 4;
            this.HomeButton.TabStop = false;
            this.HomeButton.Text = "Home";
            this.HomeButton.UseVisualStyleBackColor = false;
            this.HomeButton.Click += new System.EventHandler(this.ChangeButtonSelected);
            // 
            // ButtonsPanelTitle
            // 
            this.ButtonsPanelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ButtonsPanelTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ButtonsPanelTitle.Controls.Add(this.ButtonPanelTitleLabel);
            this.ButtonsPanelTitle.Location = new System.Drawing.Point(0, 0);
            this.ButtonsPanelTitle.Name = "ButtonsPanelTitle";
            this.ButtonsPanelTitle.Size = new System.Drawing.Size(175, 75);
            this.ButtonsPanelTitle.TabIndex = 5;
            // 
            // ButtonPanelTitleLabel
            // 
            this.ButtonPanelTitleLabel.Font = new System.Drawing.Font("Marlett", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonPanelTitleLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.ButtonPanelTitleLabel.Location = new System.Drawing.Point(0, 0);
            this.ButtonPanelTitleLabel.Name = "ButtonPanelTitleLabel";
            this.ButtonPanelTitleLabel.Size = new System.Drawing.Size(173, 74);
            this.ButtonPanelTitleLabel.TabIndex = 0;
            this.ButtonPanelTitleLabel.Text = "BRME";
            this.ButtonPanelTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HomeDisplay
            // 
            this.HomeDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HomeDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.HomeDisplay.Location = new System.Drawing.Point(177, 0);
            this.HomeDisplay.Name = "HomeDisplay";
            this.HomeDisplay.Size = new System.Drawing.Size(1023, 600);
            this.HomeDisplay.TabIndex = 0;
            this.HomeDisplay.TabStop = false;
            // 
            // LauncherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.ButtonsPanel);
            this.Controls.Add(this.HomeDisplay);
            this.Controls.Add(this.AccountDisplay);
            this.Controls.Add(this.OptionsDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1220, 643);
            this.MinimumSize = new System.Drawing.Size(1220, 643);
            this.Name = "LauncherForm";
            this.Text = " ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LauncherForm_FormClosed);
            this.Load += new System.EventHandler(this.LauncherForm_Load);
            this.SizeChanged += new System.EventHandler(this.LauncherForm_SizeChanged);
            this.ButtonsPanel.ResumeLayout(false);
            this.ButtonsPanelTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ButtonsPanel;
        private ExtendedButton HomeButton;
        private System.Windows.Forms.Panel ButtonsPanelTitle;
        private System.Windows.Forms.Label ButtonPanelTitleLabel;
        private System.Windows.Forms.Panel ButtonSelectedDisplay;
        private ExtendedButton AccountButton;
        private ExtendedButton OptionsButton;
        private OptionsDisplayControl OptionsDisplay;
        private AccountDisplayControl AccountDisplay;
        private System.Windows.Forms.Label LauncherVersionLabel;
        private HomeDisplayControl HomeDisplay;
    }
}


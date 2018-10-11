using LoESoft.Launcher.Controls;

namespace LoESoft.Launcher
{
    partial class GameLauncherForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameLauncherForm));
            this.ButtonsPanel = new System.Windows.Forms.Panel();
            this.LauncherVersionLabel = new System.Windows.Forms.Label();
            this.ButtonSelectedDisplay = new System.Windows.Forms.Panel();
            this.ButtonPanelTitleLabel = new System.Windows.Forms.Label();
            this.ExitButton = new LoESoft.Launcher.Controls.ExtendedButton();
            this.OptionsButton = new LoESoft.Launcher.Controls.ExtendedButton();
            this.OptionsDisplay = new LoESoft.Launcher.Controls.OptionsDisplay.Main();
            this.AccountButton = new LoESoft.Launcher.Controls.ExtendedButton();
            this.AccountDisplay = new LoESoft.Launcher.Controls.AccountDisplay.Main();
            this.HomeButton = new LoESoft.Launcher.Controls.ExtendedButton();
            this.HomeDisplay = new LoESoft.Launcher.Controls.HomeDisplay.Main();
            this.PopUpBox = new LoESoft.Launcher.Controls.PopUpBox();
            this.Division = new System.Windows.Forms.Panel();
            this.ButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ButtonsPanel.Controls.Add(this.Division);
            this.ButtonsPanel.Controls.Add(this.LauncherVersionLabel);
            this.ButtonsPanel.Controls.Add(this.ButtonSelectedDisplay);
            this.ButtonsPanel.Controls.Add(this.ButtonPanelTitleLabel);
            this.ButtonsPanel.Controls.Add(this.ExitButton);
            this.ButtonsPanel.Controls.Add(this.OptionsButton);
            this.ButtonsPanel.Controls.Add(this.AccountButton);
            this.ButtonsPanel.Controls.Add(this.HomeButton);
            this.ButtonsPanel.Location = new System.Drawing.Point(0, 0);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(200, 600);
            this.ButtonsPanel.TabIndex = 3;
            // 
            // LauncherVersionLabel
            // 
            this.LauncherVersionLabel.Font = new System.Drawing.Font("DisposableDroid BB", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LauncherVersionLabel.ForeColor = System.Drawing.Color.Gray;
            this.LauncherVersionLabel.Location = new System.Drawing.Point(0, 584);
            this.LauncherVersionLabel.Name = "LauncherVersionLabel";
            this.LauncherVersionLabel.Size = new System.Drawing.Size(200, 14);
            this.LauncherVersionLabel.TabIndex = 0;
            this.LauncherVersionLabel.Text = "<version>";
            this.LauncherVersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButtonSelectedDisplay
            // 
            this.ButtonSelectedDisplay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ButtonSelectedDisplay.BackColor = System.Drawing.Color.Gray;
            this.ButtonSelectedDisplay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonSelectedDisplay.Location = new System.Drawing.Point(0, 0);
            this.ButtonSelectedDisplay.Name = "ButtonSelectedDisplay";
            this.ButtonSelectedDisplay.Size = new System.Drawing.Size(16, 40);
            this.ButtonSelectedDisplay.TabIndex = 1;
            // 
            // ButtonPanelTitleLabel
            // 
            this.ButtonPanelTitleLabel.Font = new System.Drawing.Font("DisposableDroid BB", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonPanelTitleLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.ButtonPanelTitleLabel.Location = new System.Drawing.Point(0, 547);
            this.ButtonPanelTitleLabel.Name = "ButtonPanelTitleLabel";
            this.ButtonPanelTitleLabel.Size = new System.Drawing.Size(200, 37);
            this.ButtonPanelTitleLabel.TabIndex = 0;
            this.ButtonPanelTitleLabel.Text = "BRME";
            this.ButtonPanelTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.DimGray;
            this.ExitButton.Display = null;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("DisposableDroid BB", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.ExitButton.Location = new System.Drawing.Point(0, 144);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Selected = false;
            this.ExitButton.Size = new System.Drawing.Size(200, 40);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.TabStop = false;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ChangeButtonSelected);
            // 
            // OptionsButton
            // 
            this.OptionsButton.BackColor = System.Drawing.Color.DimGray;
            this.OptionsButton.Display = this.OptionsDisplay;
            this.OptionsButton.FlatAppearance.BorderSize = 0;
            this.OptionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OptionsButton.Font = new System.Drawing.Font("DisposableDroid BB", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptionsButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.OptionsButton.Location = new System.Drawing.Point(0, 96);
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Selected = false;
            this.OptionsButton.Size = new System.Drawing.Size(200, 40);
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
            this.OptionsDisplay.Location = new System.Drawing.Point(200, 0);
            this.OptionsDisplay.Name = "OptionsDisplay";
            this.OptionsDisplay.Size = new System.Drawing.Size(600, 600);
            this.OptionsDisplay.TabIndex = 1;
            this.OptionsDisplay.TabStop = false;
            this.OptionsDisplay.Visible = false;
            // 
            // AccountButton
            // 
            this.AccountButton.BackColor = System.Drawing.Color.DimGray;
            this.AccountButton.Display = this.AccountDisplay;
            this.AccountButton.FlatAppearance.BorderSize = 0;
            this.AccountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AccountButton.Font = new System.Drawing.Font("DisposableDroid BB", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.AccountButton.Location = new System.Drawing.Point(0, 48);
            this.AccountButton.Name = "AccountButton";
            this.AccountButton.Selected = false;
            this.AccountButton.Size = new System.Drawing.Size(200, 40);
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
            this.AccountDisplay.Location = new System.Drawing.Point(200, 0);
            this.AccountDisplay.Name = "AccountDisplay";
            this.AccountDisplay.Size = new System.Drawing.Size(600, 600);
            this.AccountDisplay.TabIndex = 2;
            this.AccountDisplay.TabStop = false;
            this.AccountDisplay.Visible = false;
            // 
            // HomeButton
            // 
            this.HomeButton.BackColor = System.Drawing.Color.DimGray;
            this.HomeButton.Display = this.HomeDisplay;
            this.HomeButton.Enabled = false;
            this.HomeButton.FlatAppearance.BorderSize = 0;
            this.HomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeButton.Font = new System.Drawing.Font("DisposableDroid BB", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.HomeButton.Location = new System.Drawing.Point(0, 0);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Selected = true;
            this.HomeButton.Size = new System.Drawing.Size(200, 40);
            this.HomeButton.TabIndex = 4;
            this.HomeButton.TabStop = false;
            this.HomeButton.Text = "Home";
            this.HomeButton.UseVisualStyleBackColor = false;
            this.HomeButton.Click += new System.EventHandler(this.ChangeButtonSelected);
            // 
            // HomeDisplay
            // 
            this.HomeDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HomeDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.HomeDisplay.Location = new System.Drawing.Point(200, 0);
            this.HomeDisplay.Name = "HomeDisplay";
            this.HomeDisplay.Size = new System.Drawing.Size(600, 600);
            this.HomeDisplay.TabIndex = 0;
            this.HomeDisplay.TabStop = false;
            // 
            // PopUpBox
            // 
            this.PopUpBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PopUpBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PopUpBox.Location = new System.Drawing.Point(337, 80);
            this.PopUpBox.Name = "PopUpBox";
            this.PopUpBox.Settings = null;
            this.PopUpBox.Size = new System.Drawing.Size(325, 265);
            this.PopUpBox.TabIndex = 4;
            // 
            // Division
            // 
            this.Division.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Division.BackColor = System.Drawing.Color.Gray;
            this.Division.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Division.Location = new System.Drawing.Point(196, 0);
            this.Division.Name = "Division";
            this.Division.Size = new System.Drawing.Size(4, 600);
            this.Division.TabIndex = 2;
            // 
            // GameLauncherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.PopUpBox);
            this.Controls.Add(this.ButtonsPanel);
            this.Controls.Add(this.HomeDisplay);
            this.Controls.Add(this.AccountDisplay);
            this.Controls.Add(this.OptionsDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "GameLauncherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LauncherForm_FormClosed);
            this.Load += new System.EventHandler(this.LauncherForm_Load);
            this.SizeChanged += new System.EventHandler(this.LauncherForm_SizeChanged);
            this.ButtonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ButtonsPanel;
        private ExtendedButton HomeButton;
        private System.Windows.Forms.Label ButtonPanelTitleLabel;
        private System.Windows.Forms.Panel ButtonSelectedDisplay;
        private ExtendedButton AccountButton;
        private ExtendedButton OptionsButton;
        private System.Windows.Forms.Label LauncherVersionLabel;
        private ExtendedButton ExitButton;
        private Controls.OptionsDisplay.Main OptionsDisplay;
        private Controls.AccountDisplay.Main AccountDisplay;
        private Controls.HomeDisplay.Main HomeDisplay;
        private PopUpBox PopUpBox;
        private System.Windows.Forms.Panel Division;
    }
}


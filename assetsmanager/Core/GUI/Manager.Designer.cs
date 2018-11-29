namespace LoESoft.AssetsManager.Core.GUI
{
    partial class Manager
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

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manager));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.XmlCountLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SpritesheetCountLabel = new System.Windows.Forms.Label();
            this.LoadAssetsButton = new System.Windows.Forms.Button();
            this.XmlPanel = new System.Windows.Forms.Panel();
            this.SpritesheetPanel = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.SplitPanels = new System.Windows.Forms.SplitContainer();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.MainTab = new System.Windows.Forms.TabPage();
            this.FolderIcon = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.WorkingContentLabel = new System.Windows.Forms.Label();
            this.WorkingTitleLabel = new System.Windows.Forms.Label();
            this.HelpTab = new System.Windows.Forms.TabPage();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.ContentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitPanels)).BeginInit();
            this.SplitPanels.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.MainTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FolderIcon)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.XmlCountLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox1.Location = new System.Drawing.Point(550, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 40);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // XmlCountLabel
            // 
            this.XmlCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XmlCountLabel.Location = new System.Drawing.Point(43, 16);
            this.XmlCountLabel.Name = "XmlCountLabel";
            this.XmlCountLabel.Size = new System.Drawing.Size(169, 13);
            this.XmlCountLabel.TabIndex = 1;
            this.XmlCountLabel.Text = "0";
            this.XmlCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Xml:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Spritesheet:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SpritesheetCountLabel
            // 
            this.SpritesheetCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpritesheetCountLabel.Location = new System.Drawing.Point(87, 16);
            this.SpritesheetCountLabel.Name = "SpritesheetCountLabel";
            this.SpritesheetCountLabel.Size = new System.Drawing.Size(125, 13);
            this.SpritesheetCountLabel.TabIndex = 1;
            this.SpritesheetCountLabel.Text = "0";
            this.SpritesheetCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LoadAssetsButton
            // 
            this.LoadAssetsButton.Location = new System.Drawing.Point(580, 6);
            this.LoadAssetsButton.Name = "LoadAssetsButton";
            this.LoadAssetsButton.Size = new System.Drawing.Size(190, 24);
            this.LoadAssetsButton.TabIndex = 0;
            this.LoadAssetsButton.TabStop = false;
            this.LoadAssetsButton.Text = "Load Assets";
            this.LoadAssetsButton.UseVisualStyleBackColor = true;
            this.LoadAssetsButton.Click += new System.EventHandler(this.LoadAssetsButton_Click);
            // 
            // XmlPanel
            // 
            this.XmlPanel.AutoScroll = true;
            this.XmlPanel.BackColor = System.Drawing.SystemColors.Info;
            this.XmlPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.XmlPanel.Location = new System.Drawing.Point(550, 156);
            this.XmlPanel.Name = "XmlPanel";
            this.XmlPanel.Size = new System.Drawing.Size(220, 160);
            this.XmlPanel.TabIndex = 1;
            // 
            // SpritesheetPanel
            // 
            this.SpritesheetPanel.AutoScroll = true;
            this.SpritesheetPanel.BackColor = System.Drawing.SystemColors.Info;
            this.SpritesheetPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SpritesheetPanel.Location = new System.Drawing.Point(550, 368);
            this.SpritesheetPanel.Name = "SpritesheetPanel";
            this.SpritesheetPanel.Size = new System.Drawing.Size(220, 160);
            this.SpritesheetPanel.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SpritesheetCountLabel);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox2.Location = new System.Drawing.Point(550, 322);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 40);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // ContentPanel
            // 
            this.ContentPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ContentPanel.Controls.Add(this.SplitPanels);
            this.ContentPanel.Location = new System.Drawing.Point(0, 0);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(544, 538);
            this.ContentPanel.TabIndex = 3;
            // 
            // SplitPanels
            // 
            this.SplitPanels.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitPanels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitPanels.IsSplitterFixed = true;
            this.SplitPanels.Location = new System.Drawing.Point(0, 0);
            this.SplitPanels.Name = "SplitPanels";
            // 
            // SplitPanels.Panel1
            // 
            this.SplitPanels.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            // 
            // SplitPanels.Panel2
            // 
            this.SplitPanels.Panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SplitPanels.Size = new System.Drawing.Size(544, 538);
            this.SplitPanels.SplitterDistance = 241;
            this.SplitPanels.TabIndex = 0;
            this.SplitPanels.TabStop = false;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.MainTab);
            this.TabControl.Controls.Add(this.HelpTab);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(784, 562);
            this.TabControl.TabIndex = 4;
            this.TabControl.TabStop = false;
            // 
            // MainTab
            // 
            this.MainTab.BackColor = System.Drawing.SystemColors.Control;
            this.MainTab.Controls.Add(this.FolderIcon);
            this.MainTab.Controls.Add(this.LoadAssetsButton);
            this.MainTab.Controls.Add(this.ContentPanel);
            this.MainTab.Controls.Add(this.SpritesheetPanel);
            this.MainTab.Controls.Add(this.groupBox2);
            this.MainTab.Controls.Add(this.groupBox3);
            this.MainTab.Controls.Add(this.groupBox1);
            this.MainTab.Controls.Add(this.XmlPanel);
            this.MainTab.Location = new System.Drawing.Point(4, 22);
            this.MainTab.Name = "MainTab";
            this.MainTab.Padding = new System.Windows.Forms.Padding(3);
            this.MainTab.Size = new System.Drawing.Size(776, 536);
            this.MainTab.TabIndex = 0;
            this.MainTab.Text = "Main";
            // 
            // FolderIcon
            // 
            this.FolderIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FolderIcon.Image = global::LoESoft.AssetsManager.Properties.Resources.folder_icon;
            this.FolderIcon.Location = new System.Drawing.Point(550, 6);
            this.FolderIcon.Name = "FolderIcon";
            this.FolderIcon.Size = new System.Drawing.Size(24, 24);
            this.FolderIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FolderIcon.TabIndex = 4;
            this.FolderIcon.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.WorkingContentLabel);
            this.groupBox3.Controls.Add(this.WorkingTitleLabel);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox3.Location = new System.Drawing.Point(550, 36);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(220, 68);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Info";
            // 
            // WorkingContentLabel
            // 
            this.WorkingContentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WorkingContentLabel.Location = new System.Drawing.Point(9, 29);
            this.WorkingContentLabel.Name = "WorkingContentLabel";
            this.WorkingContentLabel.Size = new System.Drawing.Size(205, 36);
            this.WorkingContentLabel.TabIndex = 1;
            this.WorkingContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WorkingTitleLabel
            // 
            this.WorkingTitleLabel.AutoSize = true;
            this.WorkingTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WorkingTitleLabel.Location = new System.Drawing.Point(6, 16);
            this.WorkingTitleLabel.Name = "WorkingTitleLabel";
            this.WorkingTitleLabel.Size = new System.Drawing.Size(0, 13);
            this.WorkingTitleLabel.TabIndex = 1;
            this.WorkingTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HelpTab
            // 
            this.HelpTab.AutoScroll = true;
            this.HelpTab.BackColor = System.Drawing.SystemColors.Control;
            this.HelpTab.ForeColor = System.Drawing.SystemColors.Desktop;
            this.HelpTab.Location = new System.Drawing.Point(4, 22);
            this.HelpTab.Name = "HelpTab";
            this.HelpTab.Padding = new System.Windows.Forms.Padding(3);
            this.HelpTab.Size = new System.Drawing.Size(776, 536);
            this.HelpTab.TabIndex = 1;
            this.HelpTab.Text = "Help";
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.TabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Manager";
            this.Text = "LoESoft - Assets Manager";
            this.Load += new System.EventHandler(this.Manager_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ContentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitPanels)).EndInit();
            this.SplitPanels.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.MainTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FolderIcon)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button LoadAssetsButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label SpritesheetCountLabel;
        private System.Windows.Forms.Label XmlCountLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel XmlPanel;
        private System.Windows.Forms.Panel SpritesheetPanel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage MainTab;
        private System.Windows.Forms.TabPage HelpTab;
        private System.Windows.Forms.SplitContainer SplitPanels;
        private System.Windows.Forms.PictureBox FolderIcon;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label WorkingContentLabel;
        private System.Windows.Forms.Label WorkingTitleLabel;
    }
}


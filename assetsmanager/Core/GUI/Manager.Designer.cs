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
            this.panel4 = new System.Windows.Forms.Panel();
            this.TextContent = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.SaveIcon = new System.Windows.Forms.PictureBox();
            this.HelpTab = new System.Windows.Forms.TabPage();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SaveIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.XmlCountLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox1.Location = new System.Drawing.Point(550, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 40);
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
            this.LoadAssetsButton.Location = new System.Drawing.Point(581, 6);
            this.LoadAssetsButton.Name = "LoadAssetsButton";
            this.LoadAssetsButton.Size = new System.Drawing.Size(187, 24);
            this.LoadAssetsButton.TabIndex = 0;
            this.LoadAssetsButton.Text = "Load Assets";
            this.LoadAssetsButton.UseVisualStyleBackColor = true;
            this.LoadAssetsButton.Click += new System.EventHandler(this.LoadAssetsButton_Click);
            // 
            // XmlPanel
            // 
            this.XmlPanel.AutoScroll = true;
            this.XmlPanel.BackColor = System.Drawing.SystemColors.Info;
            this.XmlPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.XmlPanel.Location = new System.Drawing.Point(550, 81);
            this.XmlPanel.Name = "XmlPanel";
            this.XmlPanel.Size = new System.Drawing.Size(220, 200);
            this.XmlPanel.TabIndex = 1;
            // 
            // SpritesheetPanel
            // 
            this.SpritesheetPanel.AutoScroll = true;
            this.SpritesheetPanel.BackColor = System.Drawing.SystemColors.Info;
            this.SpritesheetPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SpritesheetPanel.Location = new System.Drawing.Point(550, 333);
            this.SpritesheetPanel.Name = "SpritesheetPanel";
            this.SpritesheetPanel.Size = new System.Drawing.Size(220, 200);
            this.SpritesheetPanel.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SpritesheetCountLabel);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox2.Location = new System.Drawing.Point(552, 287);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(218, 40);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.TextContent);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(544, 538);
            this.panel4.TabIndex = 3;
            // 
            // TextContent
            // 
            this.TextContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextContent.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextContent.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextContent.Location = new System.Drawing.Point(0, 0);
            this.TextContent.Name = "TextContent";
            this.TextContent.Size = new System.Drawing.Size(540, 534);
            this.TextContent.TabIndex = 0;
            this.TextContent.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.HelpTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 562);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.SaveIcon);
            this.tabPage1.Controls.Add(this.LoadAssetsButton);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Controls.Add(this.SpritesheetPanel);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.XmlPanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(776, 536);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            // 
            // SaveIcon
            // 
            this.SaveIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveIcon.Image = global::LoESoft.AssetsManager.Properties.Resources.save_icon;
            this.SaveIcon.Location = new System.Drawing.Point(550, 6);
            this.SaveIcon.Name = "SaveIcon";
            this.SaveIcon.Size = new System.Drawing.Size(27, 24);
            this.SaveIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SaveIcon.TabIndex = 4;
            this.SaveIcon.TabStop = false;
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
            this.Controls.Add(this.tabControl1);
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
            this.panel4.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SaveIcon)).EndInit();
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
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage HelpTab;
        private System.Windows.Forms.RichTextBox TextContent;
        private System.Windows.Forms.PictureBox SaveIcon;
    }
}


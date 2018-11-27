﻿namespace LoESoft.AssetsManager.Core.GUI
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LoadAssetsButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.xmlObject5 = new LoESoft.AssetsManager.Core.GUI.HUD.XmlObject();
            this.xmlObject4 = new LoESoft.AssetsManager.Core.GUI.HUD.XmlObject();
            this.xmlObject3 = new LoESoft.AssetsManager.Core.GUI.HUD.XmlObject();
            this.xmlObject2 = new LoESoft.AssetsManager.Core.GUI.HUD.XmlObject();
            this.xmlObject1 = new LoESoft.AssetsManager.Core.GUI.HUD.XmlObject();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pngObject5 = new LoESoft.AssetsManager.Core.GUI.HUD.PngObject();
            this.pngObject4 = new LoESoft.AssetsManager.Core.GUI.HUD.PngObject();
            this.pngObject3 = new LoESoft.AssetsManager.Core.GUI.HUD.PngObject();
            this.pngObject2 = new LoESoft.AssetsManager.Core.GUI.HUD.PngObject();
            this.pngObject1 = new LoESoft.AssetsManager.Core.GUI.HUD.PngObject();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox1.Location = new System.Drawing.Point(550, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 40);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "0";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(87, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "0";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LoadAssetsButton
            // 
            this.LoadAssetsButton.Location = new System.Drawing.Point(550, 6);
            this.LoadAssetsButton.Name = "LoadAssetsButton";
            this.LoadAssetsButton.Size = new System.Drawing.Size(218, 24);
            this.LoadAssetsButton.TabIndex = 0;
            this.LoadAssetsButton.Text = "Load Assets";
            this.LoadAssetsButton.UseVisualStyleBackColor = true;
            this.LoadAssetsButton.Click += new System.EventHandler(this.LoadAssetsButton_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.xmlObject5);
            this.panel1.Controls.Add(this.xmlObject4);
            this.panel1.Controls.Add(this.xmlObject3);
            this.panel1.Controls.Add(this.xmlObject2);
            this.panel1.Controls.Add(this.xmlObject1);
            this.panel1.Location = new System.Drawing.Point(550, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 200);
            this.panel1.TabIndex = 1;
            // 
            // xmlObject5
            // 
            this.xmlObject5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xmlObject5.Location = new System.Drawing.Point(3, 179);
            this.xmlObject5.Name = "xmlObject5";
            this.xmlObject5.Size = new System.Drawing.Size(190, 38);
            this.xmlObject5.TabIndex = 0;
            // 
            // xmlObject4
            // 
            this.xmlObject4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xmlObject4.Location = new System.Drawing.Point(3, 135);
            this.xmlObject4.Name = "xmlObject4";
            this.xmlObject4.Size = new System.Drawing.Size(190, 38);
            this.xmlObject4.TabIndex = 0;
            // 
            // xmlObject3
            // 
            this.xmlObject3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xmlObject3.Location = new System.Drawing.Point(3, 91);
            this.xmlObject3.Name = "xmlObject3";
            this.xmlObject3.Size = new System.Drawing.Size(190, 38);
            this.xmlObject3.TabIndex = 0;
            // 
            // xmlObject2
            // 
            this.xmlObject2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xmlObject2.Location = new System.Drawing.Point(3, 47);
            this.xmlObject2.Name = "xmlObject2";
            this.xmlObject2.Size = new System.Drawing.Size(190, 38);
            this.xmlObject2.TabIndex = 0;
            // 
            // xmlObject1
            // 
            this.xmlObject1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xmlObject1.Location = new System.Drawing.Point(3, 3);
            this.xmlObject1.Name = "xmlObject1";
            this.xmlObject1.Size = new System.Drawing.Size(190, 38);
            this.xmlObject1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.pngObject5);
            this.panel2.Controls.Add(this.pngObject4);
            this.panel2.Controls.Add(this.pngObject3);
            this.panel2.Controls.Add(this.pngObject2);
            this.panel2.Controls.Add(this.pngObject1);
            this.panel2.Location = new System.Drawing.Point(550, 333);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 200);
            this.panel2.TabIndex = 1;
            // 
            // pngObject5
            // 
            this.pngObject5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pngObject5.Location = new System.Drawing.Point(4, 171);
            this.pngObject5.Name = "pngObject5";
            this.pngObject5.Size = new System.Drawing.Size(188, 36);
            this.pngObject5.TabIndex = 0;
            // 
            // pngObject4
            // 
            this.pngObject4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pngObject4.Location = new System.Drawing.Point(3, 129);
            this.pngObject4.Name = "pngObject4";
            this.pngObject4.Size = new System.Drawing.Size(188, 36);
            this.pngObject4.TabIndex = 0;
            // 
            // pngObject3
            // 
            this.pngObject3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pngObject3.Location = new System.Drawing.Point(3, 87);
            this.pngObject3.Name = "pngObject3";
            this.pngObject3.Size = new System.Drawing.Size(188, 36);
            this.pngObject3.TabIndex = 0;
            // 
            // pngObject2
            // 
            this.pngObject2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pngObject2.Location = new System.Drawing.Point(3, 45);
            this.pngObject2.Name = "pngObject2";
            this.pngObject2.Size = new System.Drawing.Size(188, 36);
            this.pngObject2.TabIndex = 0;
            // 
            // pngObject1
            // 
            this.pngObject1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pngObject1.Location = new System.Drawing.Point(3, 3);
            this.pngObject1.Name = "pngObject1";
            this.pngObject1.Size = new System.Drawing.Size(188, 36);
            this.pngObject1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
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
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(544, 538);
            this.panel4.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
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
            this.tabPage1.Controls.Add(this.LoadAssetsButton);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(776, 536);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(776, 536);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Help";
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
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button LoadAssetsButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private HUD.XmlObject xmlObject5;
        private HUD.XmlObject xmlObject4;
        private HUD.XmlObject xmlObject3;
        private HUD.XmlObject xmlObject2;
        private HUD.XmlObject xmlObject1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel4;
        private HUD.PngObject pngObject5;
        private HUD.PngObject pngObject4;
        private HUD.PngObject pngObject3;
        private HUD.PngObject pngObject2;
        private HUD.PngObject pngObject1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

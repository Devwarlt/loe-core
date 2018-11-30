namespace LoESoft.AssetsManager.Core.GUI.HUD
{
    partial class XmlObject
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

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.FileSizeLabel = new System.Windows.Forms.Label();
            this.XmlIcon = new System.Windows.Forms.PictureBox();
            this.RemoveXmlIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.XmlIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemoveXmlIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileNameLabel.Location = new System.Drawing.Point(43, 3);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(113, 20);
            this.FileNameLabel.TabIndex = 1;
            this.FileNameLabel.Text = "File Name";
            // 
            // FileSizeLabel
            // 
            this.FileSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileSizeLabel.Location = new System.Drawing.Point(44, 23);
            this.FileSizeLabel.Name = "FileSizeLabel";
            this.FileSizeLabel.Size = new System.Drawing.Size(113, 10);
            this.FileSizeLabel.TabIndex = 1;
            this.FileSizeLabel.Text = "File Name";
            // 
            // XmlIcon
            // 
            this.XmlIcon.BackColor = System.Drawing.Color.Transparent;
            this.XmlIcon.Image = global::LoESoft.AssetsManager.Properties.Resources.xml_icon;
            this.XmlIcon.Location = new System.Drawing.Point(0, 0);
            this.XmlIcon.Name = "XmlIcon";
            this.XmlIcon.Size = new System.Drawing.Size(38, 38);
            this.XmlIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.XmlIcon.TabIndex = 0;
            this.XmlIcon.TabStop = false;
            this.XmlIcon.DoubleClick += new System.EventHandler(this.XmlIcon_DoubleClick);
            // 
            // RemoveXmlIcon
            // 
            this.RemoveXmlIcon.BackColor = System.Drawing.Color.Transparent;
            this.RemoveXmlIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RemoveXmlIcon.Image = global::LoESoft.AssetsManager.Properties.Resources.minus_icon;
            this.RemoveXmlIcon.Location = new System.Drawing.Point(163, 7);
            this.RemoveXmlIcon.Name = "RemoveXmlIcon";
            this.RemoveXmlIcon.Size = new System.Drawing.Size(24, 24);
            this.RemoveXmlIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RemoveXmlIcon.TabIndex = 0;
            this.RemoveXmlIcon.TabStop = false;
            this.RemoveXmlIcon.Click += new System.EventHandler(this.RemoveXmlIcon_Click);
            this.RemoveXmlIcon.DoubleClick += new System.EventHandler(this.XmlIcon_DoubleClick);
            // 
            // XmlObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RemoveXmlIcon);
            this.Controls.Add(this.FileSizeLabel);
            this.Controls.Add(this.FileNameLabel);
            this.Controls.Add(this.XmlIcon);
            this.Name = "XmlObject";
            this.Size = new System.Drawing.Size(190, 38);
            ((System.ComponentModel.ISupportInitialize)(this.XmlIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemoveXmlIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox XmlIcon;
        private System.Windows.Forms.Label FileNameLabel;
        private System.Windows.Forms.Label FileSizeLabel;
        private System.Windows.Forms.PictureBox RemoveXmlIcon;
    }
}

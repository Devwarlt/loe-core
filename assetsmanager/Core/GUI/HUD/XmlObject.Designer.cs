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
            this.XmlIcon = new System.Windows.Forms.PictureBox();
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.FileSizeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.XmlIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.XmlIcon.BackColor = System.Drawing.Color.Transparent;
            this.XmlIcon.Image = global::LoESoft.AssetsManager.Properties.Resources.xml_icon;
            this.XmlIcon.Location = new System.Drawing.Point(0, 0);
            this.XmlIcon.Name = "pictureBox1";
            this.XmlIcon.Size = new System.Drawing.Size(38, 38);
            this.XmlIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.XmlIcon.TabIndex = 0;
            this.XmlIcon.TabStop = false;
            this.XmlIcon.DoubleClick += new System.EventHandler(this.XmlIcon_DoubleClick);
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileNameLabel.Location = new System.Drawing.Point(44, 3);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(143, 15);
            this.FileNameLabel.TabIndex = 1;
            this.FileNameLabel.Text = "File Name";
            // 
            // FileSizeLabel
            // 
            this.FileSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileSizeLabel.Location = new System.Drawing.Point(44, 23);
            this.FileSizeLabel.Name = "FileSizeLabel";
            this.FileSizeLabel.Size = new System.Drawing.Size(143, 10);
            this.FileSizeLabel.TabIndex = 1;
            this.FileSizeLabel.Text = "File Name";
            // 
            // XmlObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FileSizeLabel);
            this.Controls.Add(this.FileNameLabel);
            this.Controls.Add(this.XmlIcon);
            this.Name = "XmlObject";
            this.Size = new System.Drawing.Size(190, 38);
            ((System.ComponentModel.ISupportInitialize)(this.XmlIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox XmlIcon;
        private System.Windows.Forms.Label FileNameLabel;
        private System.Windows.Forms.Label FileSizeLabel;
    }
}

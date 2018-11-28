namespace LoESoft.AssetsManager.Core.GUI.HUD
{
    partial class PngObject
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.FileSizeLabel = new System.Windows.Forms.Label();
            this.FileNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::LoESoft.AssetsManager.Properties.Resources.png_icon;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FileSizeLabel
            // 
            this.FileSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileSizeLabel.Location = new System.Drawing.Point(44, 23);
            this.FileSizeLabel.Name = "FileSizeLabel";
            this.FileSizeLabel.Size = new System.Drawing.Size(143, 10);
            this.FileSizeLabel.TabIndex = 2;
            this.FileSizeLabel.Text = "File Name";
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileNameLabel.Location = new System.Drawing.Point(44, 3);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(143, 15);
            this.FileNameLabel.TabIndex = 3;
            this.FileNameLabel.Text = "File Name";
            // 
            // PngObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FileSizeLabel);
            this.Controls.Add(this.FileNameLabel);
            this.Controls.Add(this.pictureBox1);
            this.Name = "PngObject";
            this.Size = new System.Drawing.Size(190, 38);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label FileSizeLabel;
        private System.Windows.Forms.Label FileNameLabel;
    }
}

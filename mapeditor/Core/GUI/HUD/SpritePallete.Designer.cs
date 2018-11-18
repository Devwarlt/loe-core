namespace LoESoft.MapEditor.Core.GUI.HUD
{
    partial class SpritePallete
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
            this.SpriteBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SpriteBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SpriteBox
            // 
            this.SpriteBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SpriteBox.Location = new System.Drawing.Point(1, 1);
            this.SpriteBox.Name = "SpriteBox";
            this.SpriteBox.Size = new System.Drawing.Size(32, 32);
            this.SpriteBox.TabIndex = 0;
            this.SpriteBox.TabStop = false;
            this.SpriteBox.Click += new System.EventHandler(this.SpriteBox_Click);
            // 
            // SpritePallete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SpriteBox);
            this.Name = "SpritePallete";
            this.Size = new System.Drawing.Size(33, 33);
            ((System.ComponentModel.ISupportInitialize)(this.SpriteBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox SpriteBox;
    }
}

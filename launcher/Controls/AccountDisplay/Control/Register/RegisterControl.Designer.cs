namespace LoESoft.Launcher.Controls.AccountDisplay.Control.Register
{
    partial class RegisterControl
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
            this.RegisterBox = new LoESoft.Launcher.Controls.AccountDisplay.RegisterBox();
            this.PopUpBox = new LoESoft.Launcher.Controls.AccountDisplay.PopUpBox();
            this.SuspendLayout();
            // 
            // RegisterBox
            // 
            this.RegisterBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RegisterBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RegisterBox.Location = new System.Drawing.Point(0, 0);
            this.RegisterBox.Name = "RegisterBox";
            this.RegisterBox.Size = new System.Drawing.Size(400, 285);
            this.RegisterBox.TabIndex = 0;
            // 
            // PopUpBox
            // 
            this.PopUpBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PopUpBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PopUpBox.Location = new System.Drawing.Point(0, 40);
            this.PopUpBox.Name = "PopUpBox";
            this.PopUpBox.Settings = null;
            this.PopUpBox.Size = new System.Drawing.Size(400, 242);
            this.PopUpBox.TabIndex = 1;
            // 
            // RegisterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.PopUpBox);
            this.Controls.Add(this.RegisterBox);
            this.Name = "RegisterControl";
            this.Size = new System.Drawing.Size(400, 285);
            this.Load += new System.EventHandler(this.RegisterControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private RegisterBox RegisterBox;
        private PopUpBox PopUpBox;
    }
}

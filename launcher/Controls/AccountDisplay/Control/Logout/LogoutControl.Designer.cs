namespace LoESoft.Launcher.Controls.AccountDisplay.Control.Logout
{
    partial class LogoutControl
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
            this.LogoutBox = new LoESoft.Launcher.Controls.AccountDisplay.Control.Logout.LogoutBox();
            this.SuspendLayout();
            // 
            // LogoutBox
            // 
            this.LogoutBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LogoutBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LogoutBox.Location = new System.Drawing.Point(0, 0);
            this.LogoutBox.Name = "LogoutBox";
            this.LogoutBox.Size = new System.Drawing.Size(325, 244);
            this.LogoutBox.TabIndex = 0;
            // 
            // LogoutControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.LogoutBox);
            this.Name = "LogoutControl";
            this.Size = new System.Drawing.Size(325, 244);
            this.Load += new System.EventHandler(this.LoginControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private LogoutBox LogoutBox;
    }
}

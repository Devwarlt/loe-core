namespace LoESoft.Launcher.Controls.AccountDisplay.Control.Login
{
    partial class LoginControl
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
            this.PopUpBox = new LoESoft.Launcher.Controls.PopUpBox();
            this.LoginBox = new LoESoft.Launcher.Controls.AccountDisplay.Control.Login.LoginBox();
            this.SuspendLayout();
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
            // LoginBox
            // 
            this.LoginBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LoginBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LoginBox.Location = new System.Drawing.Point(0, 0);
            this.LoginBox.Name = "LoginBox";
            this.LoginBox.Size = new System.Drawing.Size(400, 224);
            this.LoginBox.TabIndex = 0;
            // 
            // LoginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.PopUpBox);
            this.Controls.Add(this.LoginBox);
            this.Name = "LoginControl";
            this.Size = new System.Drawing.Size(400, 282);
            this.Load += new System.EventHandler(this.LoginControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private LoginBox LoginBox;
        private PopUpBox PopUpBox;
    }
}

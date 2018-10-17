using LoESoft.Launcher.Controls.AccountDisplay.Control.Register;

namespace LoESoft.Launcher.Controls.AccountDisplay.Control.Updater
{
    partial class UpdaterControl
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
            this.UpdaterBox = new LoESoft.Launcher.Controls.AccountDisplay.Control.Updater.UpdaterBox();
            this.SuspendLayout();
            // 
            // PopUpBox
            // 
            this.PopUpBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PopUpBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PopUpBox.Location = new System.Drawing.Point(0, 38);
            this.PopUpBox.Name = "PopUpBox";
            this.PopUpBox.Settings = null;
            this.PopUpBox.Size = new System.Drawing.Size(325, 265);
            this.PopUpBox.TabIndex = 1;
            // 
            // UpdaterBox
            // 
            this.UpdaterBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UpdaterBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UpdaterBox.Location = new System.Drawing.Point(0, 0);
            this.UpdaterBox.Name = "UpdaterBox";
            this.UpdaterBox.Size = new System.Drawing.Size(325, 244);
            this.UpdaterBox.TabIndex = 2;
            // 
            // UpdaterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.PopUpBox);
            this.Controls.Add(this.UpdaterBox);
            this.Name = "UpdaterControl";
            this.Size = new System.Drawing.Size(325, 305);
            this.Load += new System.EventHandler(this.UpdaterControl_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private PopUpBox PopUpBox;
        private UpdaterBox UpdaterBox;
    }
}

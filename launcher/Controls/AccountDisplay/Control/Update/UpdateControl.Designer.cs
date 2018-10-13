namespace LoESoft.Launcher.Controls.AccountDisplay.Control.Update
{
    partial class UpdateControl
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
            this.UpdateMediator = new LoESoft.Launcher.Controls.AccountDisplay.Control.Update.UpdateMediator();
            this.UpdateBox = new LoESoft.Launcher.Controls.AccountDisplay.Control.Update.UpdateBox();
            this.PopUpBox = new LoESoft.Launcher.Controls.PopUpBox();
            this.SuspendLayout();
            // 
            // UpdateMediator
            // 
            this.UpdateMediator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UpdateMediator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UpdateMediator.Location = new System.Drawing.Point(0, 0);
            this.UpdateMediator.Name = "UpdateMediator";
            this.UpdateMediator.Size = new System.Drawing.Size(325, 233);
            this.UpdateMediator.TabIndex = 4;
            // 
            // UupdateBox
            // 
            this.UpdateBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UpdateBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UpdateBox.Location = new System.Drawing.Point(0, 0);
            this.UpdateBox.Name = "UupdateBox";
            this.UpdateBox.Size = new System.Drawing.Size(325, 233);
            this.UpdateBox.TabIndex = 3;
            // 
            // PopUpBox
            // 
            this.PopUpBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PopUpBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PopUpBox.Location = new System.Drawing.Point(0, 0);
            this.PopUpBox.Name = "PopUpBox";
            this.PopUpBox.Settings = null;
            this.PopUpBox.Size = new System.Drawing.Size(325, 265);
            this.PopUpBox.TabIndex = 2;
            // 
            // UpdateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.UpdateMediator);
            this.Controls.Add(this.UpdateBox);
            this.Controls.Add(this.PopUpBox);
            this.Name = "UpdateControl";
            this.Size = new System.Drawing.Size(325, 265);
            this.Load += new System.EventHandler(this.UpdateControl_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private PopUpBox PopUpBox;
        private UpdateBox UpdateBox;
        private UpdateMediator UpdateMediator;
    }
}

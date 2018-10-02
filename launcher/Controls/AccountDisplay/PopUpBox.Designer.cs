namespace LoESoft.Launcher.Controls.AccountDisplay
{
    partial class PopUpBox
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
            this.OkButton = new System.Windows.Forms.Button();
            this.PopUpTitle = new System.Windows.Forms.Label();
            this.PopUpContent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.BackColor = System.Drawing.Color.DimGray;
            this.OkButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkButton.Font = new System.Drawing.Font("DisposableDroid BB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OkButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.OkButton.Location = new System.Drawing.Point(117, 127);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(160, 36);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "Submit";
            this.OkButton.UseVisualStyleBackColor = false;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // PopUpTitle
            // 
            this.PopUpTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PopUpTitle.BackColor = System.Drawing.Color.Gray;
            this.PopUpTitle.Font = new System.Drawing.Font("DisposableDroid BB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PopUpTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.PopUpTitle.Location = new System.Drawing.Point(0, 0);
            this.PopUpTitle.Name = "PopUpTitle";
            this.PopUpTitle.Size = new System.Drawing.Size(400, 40);
            this.PopUpTitle.TabIndex = 0;
            this.PopUpTitle.Text = "<Title>";
            this.PopUpTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PopUpContent
            // 
            this.PopUpContent.BackColor = System.Drawing.Color.Transparent;
            this.PopUpContent.Font = new System.Drawing.Font("DisposableDroid BB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PopUpContent.ForeColor = System.Drawing.Color.Gainsboro;
            this.PopUpContent.Location = new System.Drawing.Point(0, 40);
            this.PopUpContent.Name = "PopUpContent";
            this.PopUpContent.Size = new System.Drawing.Size(400, 84);
            this.PopUpContent.TabIndex = 2;
            this.PopUpContent.Text = "<Content>";
            this.PopUpContent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PopUpBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.PopUpTitle);
            this.Controls.Add(this.PopUpContent);
            this.Controls.Add(this.OkButton);
            this.Name = "PopUpBox";
            this.Size = new System.Drawing.Size(400, 173);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label PopUpTitle;
        private System.Windows.Forms.Label PopUpContent;
    }
}

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
            this.SubmitButton = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.Content = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SubmitButton
            // 
            this.SubmitButton.BackColor = System.Drawing.Color.DimGray;
            this.SubmitButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.SubmitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubmitButton.Font = new System.Drawing.Font("DisposableDroid BB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.SubmitButton.Location = new System.Drawing.Point(116, 197);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(160, 36);
            this.SubmitButton.TabIndex = 0;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = false;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // Title
            // 
            this.Title.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Title.BackColor = System.Drawing.Color.Gray;
            this.Title.Font = new System.Drawing.Font("DisposableDroid BB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.Gainsboro;
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(400, 40);
            this.Title.TabIndex = 0;
            this.Title.Text = "<Title>";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Content
            // 
            this.Content.Font = new System.Drawing.Font("DisposableDroid BB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Content.ForeColor = System.Drawing.Color.Gainsboro;
            this.Content.Location = new System.Drawing.Point(0, 40);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(400, 154);
            this.Content.TabIndex = 1;
            this.Content.Text = "<Content>";
            this.Content.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PopUpBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Content);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.SubmitButton);
            this.Name = "PopUpBox";
            this.Size = new System.Drawing.Size(400, 242);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label Content;
    }
}

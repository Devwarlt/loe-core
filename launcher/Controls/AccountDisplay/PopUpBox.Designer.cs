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
            this.panel1 = new System.Windows.Forms.Panel();
            this.PopUpTitle = new System.Windows.Forms.Label();
            this.PopUpContent = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.BackColor = System.Drawing.Color.DimGray;
            this.OkButton.FlatAppearance.BorderSize = 0;
            this.OkButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.OkButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkButton.Font = new System.Drawing.Font("DisposableDroid BB", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OkButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.OkButton.Location = new System.Drawing.Point(240, 118);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 28);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = false;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.PopUpTitle);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 32);
            this.panel1.TabIndex = 1;
            // 
            // PopUpTitle
            // 
            this.PopUpTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PopUpTitle.BackColor = System.Drawing.Color.DimGray;
            this.PopUpTitle.Font = new System.Drawing.Font("DisposableDroid BB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PopUpTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.PopUpTitle.Location = new System.Drawing.Point(-2, -1);
            this.PopUpTitle.Name = "PopUpTitle";
            this.PopUpTitle.Size = new System.Drawing.Size(548, 32);
            this.PopUpTitle.TabIndex = 0;
            this.PopUpTitle.Text = "Some title here";
            this.PopUpTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PopUpText
            // 
            this.PopUpContent.BackColor = System.Drawing.Color.Transparent;
            this.PopUpContent.Font = new System.Drawing.Font("DisposableDroid BB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PopUpContent.ForeColor = System.Drawing.Color.Gainsboro;
            this.PopUpContent.Location = new System.Drawing.Point(-1, 31);
            this.PopUpContent.Name = "PopUpText";
            this.PopUpContent.Size = new System.Drawing.Size(548, 84);
            this.PopUpContent.TabIndex = 2;
            this.PopUpContent.Text = "Some text here";
            this.PopUpContent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PopUpDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.PopUpContent);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.OkButton);
            this.Name = "PopUpDisplay";
            this.Size = new System.Drawing.Size(546, 149);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label PopUpTitle;
        private System.Windows.Forms.Label PopUpContent;
    }
}

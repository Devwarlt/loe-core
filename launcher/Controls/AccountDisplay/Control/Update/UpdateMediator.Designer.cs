namespace LoESoft.Launcher.Controls.AccountDisplay.Control.Update
{
    partial class UpdateMediator
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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.UpdateLabel = new System.Windows.Forms.Label();
            this.UpdateStartPlayButton = new System.Windows.Forms.Button();
            this.UpdateCancelButton = new System.Windows.Forms.Button();
            this.UpdateProgressBar = new System.Windows.Forms.ProgressBar();
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.SpeedLabel = new System.Windows.Forms.Label();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.FileValueLabel = new System.Windows.Forms.Label();
            this.SpeedValueLabel = new System.Windows.Forms.Label();
            this.ProgressValueLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleLabel.BackColor = System.Drawing.Color.Gray;
            this.TitleLabel.Font = new System.Drawing.Font("DisposableDroid BB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.TitleLabel.Location = new System.Drawing.Point(0, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(325, 40);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "Updating...";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UpdateLabel
            // 
            this.UpdateLabel.Font = new System.Drawing.Font("DisposableDroid BB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.UpdateLabel.Location = new System.Drawing.Point(0, 56);
            this.UpdateLabel.Name = "UpdateLabel";
            this.UpdateLabel.Size = new System.Drawing.Size(325, 16);
            this.UpdateLabel.TabIndex = 5;
            this.UpdateLabel.Text = "The game is updating, please wait...";
            this.UpdateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UpdateStartPlayButton
            // 
            this.UpdateStartPlayButton.BackColor = System.Drawing.Color.DimGray;
            this.UpdateStartPlayButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.UpdateStartPlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateStartPlayButton.Font = new System.Drawing.Font("DisposableDroid BB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateStartPlayButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.UpdateStartPlayButton.Location = new System.Drawing.Point(27, 192);
            this.UpdateStartPlayButton.Name = "UpdateStartPlayButton";
            this.UpdateStartPlayButton.Size = new System.Drawing.Size(124, 36);
            this.UpdateStartPlayButton.TabIndex = 7;
            this.UpdateStartPlayButton.TabStop = false;
            this.UpdateStartPlayButton.Text = "Start";
            this.UpdateStartPlayButton.UseVisualStyleBackColor = false;
            this.UpdateStartPlayButton.Click += new System.EventHandler(this.UpdateStartPlayButton_Click);
            // 
            // UpdateCancelButton
            // 
            this.UpdateCancelButton.BackColor = System.Drawing.Color.DimGray;
            this.UpdateCancelButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.UpdateCancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateCancelButton.Font = new System.Drawing.Font("DisposableDroid BB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateCancelButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.UpdateCancelButton.Location = new System.Drawing.Point(175, 192);
            this.UpdateCancelButton.Name = "UpdateCancelButton";
            this.UpdateCancelButton.Size = new System.Drawing.Size(124, 36);
            this.UpdateCancelButton.TabIndex = 10;
            this.UpdateCancelButton.TabStop = false;
            this.UpdateCancelButton.Text = "Cancel";
            this.UpdateCancelButton.UseVisualStyleBackColor = false;
            // 
            // UpdateProgressBar
            // 
            this.UpdateProgressBar.ForeColor = System.Drawing.Color.Silver;
            this.UpdateProgressBar.Location = new System.Drawing.Point(27, 154);
            this.UpdateProgressBar.Name = "UpdateProgressBar";
            this.UpdateProgressBar.Size = new System.Drawing.Size(272, 16);
            this.UpdateProgressBar.Step = 1;
            this.UpdateProgressBar.TabIndex = 11;
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.Font = new System.Drawing.Font("DisposableDroid BB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileNameLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.FileNameLabel.Location = new System.Drawing.Point(24, 88);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(127, 16);
            this.FileNameLabel.TabIndex = 12;
            this.FileNameLabel.Text = "File:";
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.Font = new System.Drawing.Font("DisposableDroid BB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpeedLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.SpeedLabel.Location = new System.Drawing.Point(24, 104);
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(127, 16);
            this.SpeedLabel.TabIndex = 12;
            this.SpeedLabel.Text = "Speed:";
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.Font = new System.Drawing.Font("DisposableDroid BB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgressLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.ProgressLabel.Location = new System.Drawing.Point(24, 120);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(127, 16);
            this.ProgressLabel.TabIndex = 12;
            this.ProgressLabel.Text = "Progress:";
            // 
            // FileValueLabel
            // 
            this.FileValueLabel.Font = new System.Drawing.Font("DisposableDroid BB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileValueLabel.ForeColor = System.Drawing.Color.Gold;
            this.FileValueLabel.Location = new System.Drawing.Point(175, 88);
            this.FileValueLabel.Name = "FileValueLabel";
            this.FileValueLabel.Size = new System.Drawing.Size(124, 16);
            this.FileValueLabel.TabIndex = 12;
            this.FileValueLabel.Text = "...loading";
            this.FileValueLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SpeedValueLabel
            // 
            this.SpeedValueLabel.Font = new System.Drawing.Font("DisposableDroid BB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpeedValueLabel.ForeColor = System.Drawing.Color.Gold;
            this.SpeedValueLabel.Location = new System.Drawing.Point(175, 104);
            this.SpeedValueLabel.Name = "SpeedValueLabel";
            this.SpeedValueLabel.Size = new System.Drawing.Size(124, 16);
            this.SpeedValueLabel.TabIndex = 12;
            this.SpeedValueLabel.Text = "...loading";
            this.SpeedValueLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ProgressValueLabel
            // 
            this.ProgressValueLabel.Font = new System.Drawing.Font("DisposableDroid BB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgressValueLabel.ForeColor = System.Drawing.Color.Gold;
            this.ProgressValueLabel.Location = new System.Drawing.Point(175, 120);
            this.ProgressValueLabel.Name = "ProgressValueLabel";
            this.ProgressValueLabel.Size = new System.Drawing.Size(124, 16);
            this.ProgressValueLabel.TabIndex = 12;
            this.ProgressValueLabel.Text = "...loading";
            this.ProgressValueLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // UpdateMediator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.ProgressLabel);
            this.Controls.Add(this.SpeedLabel);
            this.Controls.Add(this.ProgressValueLabel);
            this.Controls.Add(this.SpeedValueLabel);
            this.Controls.Add(this.FileValueLabel);
            this.Controls.Add(this.FileNameLabel);
            this.Controls.Add(this.UpdateProgressBar);
            this.Controls.Add(this.UpdateCancelButton);
            this.Controls.Add(this.UpdateStartPlayButton);
            this.Controls.Add(this.UpdateLabel);
            this.Controls.Add(this.TitleLabel);
            this.Name = "UpdateMediator";
            this.Size = new System.Drawing.Size(325, 233);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label UpdateLabel;
        private System.Windows.Forms.Button UpdateStartPlayButton;
        private System.Windows.Forms.Button UpdateCancelButton;
        private System.Windows.Forms.ProgressBar UpdateProgressBar;
        private System.Windows.Forms.Label FileNameLabel;
        private System.Windows.Forms.Label SpeedLabel;
        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.Label FileValueLabel;
        private System.Windows.Forms.Label SpeedValueLabel;
        private System.Windows.Forms.Label ProgressValueLabel;
    }
}

namespace LoESoft.Launcher.Controls.AccountDisplay.Control.Updater
{
    partial class UpdaterBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UpdateCancelButton = new System.Windows.Forms.Button();
            this.UpdateOKButton = new System.Windows.Forms.Button();
            this.UpdateLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.UpdateCancelButton.TabIndex = 14;
            this.UpdateCancelButton.TabStop = false;
            this.UpdateCancelButton.Text = "Cancel";
            this.UpdateCancelButton.UseVisualStyleBackColor = false;
            // 
            // UpdateOKButton
            // 
            this.UpdateOKButton.BackColor = System.Drawing.Color.DimGray;
            this.UpdateOKButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.UpdateOKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateOKButton.Font = new System.Drawing.Font("DisposableDroid BB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateOKButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.UpdateOKButton.Location = new System.Drawing.Point(27, 192);
            this.UpdateOKButton.Name = "UpdateOKButton";
            this.UpdateOKButton.Size = new System.Drawing.Size(124, 36);
            this.UpdateOKButton.TabIndex = 13;
            this.UpdateOKButton.TabStop = false;
            this.UpdateOKButton.Text = "OK";
            this.UpdateOKButton.UseVisualStyleBackColor = false;
            // 
            // UpdateLabel
            // 
            this.UpdateLabel.Font = new System.Drawing.Font("DisposableDroid BB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.UpdateLabel.Location = new System.Drawing.Point(0, 40);
            this.UpdateLabel.Name = "UpdateLabel";
            this.UpdateLabel.Size = new System.Drawing.Size(325, 133);
            this.UpdateLabel.TabIndex = 12;
            this.UpdateLabel.Text = "<Content>";
            this.UpdateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.TitleLabel.TabIndex = 11;
            this.TitleLabel.Text = "Update";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UpdaterBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.UpdateCancelButton);
            this.Controls.Add(this.UpdateOKButton);
            this.Controls.Add(this.UpdateLabel);
            this.Controls.Add(this.TitleLabel);
            this.Name = "UpdaterBox";
            this.Size = new System.Drawing.Size(325, 244);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UpdateCancelButton;
        private System.Windows.Forms.Button UpdateOKButton;
        private System.Windows.Forms.Label UpdateLabel;
        private System.Windows.Forms.Label TitleLabel;
    }
}

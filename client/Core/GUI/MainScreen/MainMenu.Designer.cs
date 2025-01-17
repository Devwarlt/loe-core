﻿namespace LoESoft.Client.Core.GUI.MainScreen
{
    partial class MainMenu
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
            this.BRMELabel = new System.Windows.Forms.Label();
            this.BRMEVersion = new System.Windows.Forms.Label();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.LoginButton = new System.Windows.Forms.Button();
            this.LaunchButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LoginBox = new LoESoft.Client.Core.GUI.MainScreen.LoginBox();
            this.RegisterBox = new LoESoft.Client.Core.GUI.MainScreen.RegisterBox();
            this.GameDialog = new LoESoft.Client.Core.GUI.GameDialog.GameDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BRMELabel
            // 
            this.BRMELabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BRMELabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.BRMELabel.Location = new System.Drawing.Point(3, 40);
            this.BRMELabel.Name = "BRMELabel";
            this.BRMELabel.Size = new System.Drawing.Size(171, 51);
            this.BRMELabel.TabIndex = 0;
            this.BRMELabel.Text = "BRME";
            this.BRMELabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BRMEVersion
            // 
            this.BRMEVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BRMEVersion.ForeColor = System.Drawing.Color.Gray;
            this.BRMEVersion.Location = new System.Drawing.Point(23, 91);
            this.BRMEVersion.Name = "BRMEVersion";
            this.BRMEVersion.Size = new System.Drawing.Size(124, 14);
            this.BRMEVersion.TabIndex = 1;
            this.BRMEVersion.Text = "<version>";
            this.BRMEVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RegisterButton
            // 
            this.RegisterButton.BackColor = System.Drawing.Color.DimGray;
            this.RegisterButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.RegisterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegisterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.RegisterButton.Location = new System.Drawing.Point(23, 290);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(124, 36);
            this.RegisterButton.TabIndex = 3;
            this.RegisterButton.TabStop = false;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = false;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.DimGray;
            this.LoginButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.LoginButton.Location = new System.Drawing.Point(23, 240);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(124, 36);
            this.LoginButton.TabIndex = 4;
            this.LoginButton.TabStop = false;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // LaunchButton
            // 
            this.LaunchButton.BackColor = System.Drawing.Color.DimGray;
            this.LaunchButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.LaunchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LaunchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LaunchButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.LaunchButton.Location = new System.Drawing.Point(23, 190);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.Size = new System.Drawing.Size(124, 36);
            this.LaunchButton.TabIndex = 5;
            this.LaunchButton.TabStop = false;
            this.LaunchButton.Text = "Launch";
            this.LaunchButton.UseVisualStyleBackColor = false;
            this.LaunchButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.DimGray;
            this.ExitButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.ExitButton.Location = new System.Drawing.Point(24, 340);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(124, 36);
            this.ExitButton.TabIndex = 6;
            this.ExitButton.TabStop = false;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // TitleLabel
            // 
            this.TitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleLabel.BackColor = System.Drawing.Color.Gray;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.TitleLabel.Location = new System.Drawing.Point(0, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(600, 40);
            this.TitleLabel.TabIndex = 9;
            this.TitleLabel.Text = "Launcher";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LoESoft.Client.Properties.Resources.loesoft_new_expanded_shadows_closer;
            this.pictureBox1.Location = new System.Drawing.Point(501, 301);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // LoginBox
            // 
            this.LoginBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LoginBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LoginBox.Enabled = false;
            this.LoginBox.Location = new System.Drawing.Point(189, 49);
            this.LoginBox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.LoginBox.Name = "LoginBox";
            this.LoginBox.Size = new System.Drawing.Size(325, 227);
            this.LoginBox.TabIndex = 7;
            this.LoginBox.Visible = false;
            // 
            // RegisterBox
            // 
            this.RegisterBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RegisterBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RegisterBox.Enabled = false;
            this.RegisterBox.Location = new System.Drawing.Point(188, 48);
            this.RegisterBox.Name = "RegisterBox";
            this.RegisterBox.Size = new System.Drawing.Size(325, 333);
            this.RegisterBox.TabIndex = 8;
            this.RegisterBox.Visible = false;
            // 
            // GameDialog
            // 
            this.GameDialog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.GameDialog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GameDialog.Location = new System.Drawing.Point(189, 49);
            this.GameDialog.Name = "GameDialog";
            this.GameDialog.Settings = null;
            this.GameDialog.Size = new System.Drawing.Size(325, 265);
            this.GameDialog.TabIndex = 11;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.GameDialog);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.LoginBox);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.LaunchButton);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.BRMEVersion);
            this.Controls.Add(this.BRMELabel);
            this.Controls.Add(this.RegisterBox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MainMenu";
            this.Size = new System.Drawing.Size(600, 400);
            this.Load += new System.EventHandler(this.MainScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label BRMELabel;
        private System.Windows.Forms.Label BRMEVersion;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Button LaunchButton;
        private System.Windows.Forms.Button ExitButton;
        private LoginBox LoginBox;
        private RegisterBox RegisterBox;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private GameDialog.GameDialog GameDialog;
    }
}

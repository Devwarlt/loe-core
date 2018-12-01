namespace LoESoft.AssetsManager.Core.GUI.HUD
{
    partial class ItemControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TilesButton = new System.Windows.Forms.RadioButton();
            this.ItemsButton = new System.Windows.Forms.RadioButton();
            this.ObjectsButton = new System.Windows.Forms.RadioButton();
            this.ItemId = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.PictureBox();
            this.ProgressMainLabel = new System.Windows.Forms.Label();
            this.ProgressStatusLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ItemFile = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ItemName = new LoESoft.AssetsManager.Core.GUI.HUD.CustomTextBox();
            this.spritePallete1 = new LoESoft.AssetsManager.Core.GUI.HUD.SpritePallete();
            this.ItemY = new LoESoft.AssetsManager.Core.GUI.HUD.CustomTextBox();
            this.ItemX = new LoESoft.AssetsManager.Core.GUI.HUD.CustomTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveButton)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TilesButton);
            this.groupBox1.Controls.Add(this.ItemsButton);
            this.groupBox1.Controls.Add(this.ObjectsButton);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 46);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Content Type";
            // 
            // TilesButton
            // 
            this.TilesButton.AutoSize = true;
            this.TilesButton.Enabled = false;
            this.TilesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TilesButton.Location = new System.Drawing.Point(195, 19);
            this.TilesButton.Name = "TilesButton";
            this.TilesButton.Size = new System.Drawing.Size(47, 17);
            this.TilesButton.TabIndex = 0;
            this.TilesButton.Text = "Tiles";
            this.TilesButton.UseVisualStyleBackColor = true;
            // 
            // ItemsButton
            // 
            this.ItemsButton.AutoSize = true;
            this.ItemsButton.Enabled = false;
            this.ItemsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemsButton.Location = new System.Drawing.Point(108, 19);
            this.ItemsButton.Name = "ItemsButton";
            this.ItemsButton.Size = new System.Drawing.Size(50, 17);
            this.ItemsButton.TabIndex = 0;
            this.ItemsButton.Text = "Items";
            this.ItemsButton.UseVisualStyleBackColor = true;
            // 
            // ObjectsButton
            // 
            this.ObjectsButton.AutoSize = true;
            this.ObjectsButton.Enabled = false;
            this.ObjectsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObjectsButton.Location = new System.Drawing.Point(23, 19);
            this.ObjectsButton.Name = "ObjectsButton";
            this.ObjectsButton.Size = new System.Drawing.Size(61, 17);
            this.ObjectsButton.TabIndex = 0;
            this.ObjectsButton.Text = "Objects";
            this.ObjectsButton.UseVisualStyleBackColor = true;
            // 
            // ItemId
            // 
            this.ItemId.BackColor = System.Drawing.SystemColors.Info;
            this.ItemId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ItemId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemId.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ItemId.Location = new System.Drawing.Point(55, 55);
            this.ItemId.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.ItemId.Name = "ItemId";
            this.ItemId.Size = new System.Drawing.Size(201, 20);
            this.ItemId.TabIndex = 2;
            this.ItemId.TabStop = false;
            this.ItemId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ItemId.Validating += new System.ComponentModel.CancelEventHandler(this.IDNumeric_Validating);
            this.ItemId.Validated += new System.EventHandler(this.IDNumeric_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(29, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(10, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // SaveButton
            // 
            this.SaveButton.Image = global::LoESoft.AssetsManager.Properties.Resources.hud_save;
            this.SaveButton.Location = new System.Drawing.Point(265, 15);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(6);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(24, 24);
            this.SaveButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SaveButton.TabIndex = 5;
            this.SaveButton.TabStop = false;
            this.SaveButton.Visible = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ProgressMainLabel
            // 
            this.ProgressMainLabel.AutoSize = true;
            this.ProgressMainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgressMainLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ProgressMainLabel.Location = new System.Drawing.Point(3, 3);
            this.ProgressMainLabel.Margin = new System.Windows.Forms.Padding(3);
            this.ProgressMainLabel.Name = "ProgressMainLabel";
            this.ProgressMainLabel.Size = new System.Drawing.Size(60, 13);
            this.ProgressMainLabel.TabIndex = 3;
            this.ProgressMainLabel.Text = "Progress:";
            this.ProgressMainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ProgressMainLabel.Visible = false;
            // 
            // ProgressStatusLabel
            // 
            this.ProgressStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgressStatusLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ProgressStatusLabel.Location = new System.Drawing.Point(69, 3);
            this.ProgressStatusLabel.Margin = new System.Windows.Forms.Padding(3);
            this.ProgressStatusLabel.Name = "ProgressStatusLabel";
            this.ProgressStatusLabel.Size = new System.Drawing.Size(219, 13);
            this.ProgressStatusLabel.TabIndex = 3;
            this.ProgressStatusLabel.Text = "status";
            this.ProgressStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ProgressStatusLabel.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.ProgressMainLabel);
            this.panel1.Controls.Add(this.ProgressStatusLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 513);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 21);
            this.panel1.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.spritePallete1);
            this.groupBox2.Controls.Add(this.ItemFile);
            this.groupBox2.Controls.Add(this.ItemY);
            this.groupBox2.Controls.Add(this.ItemX);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox2.Location = new System.Drawing.Point(3, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 79);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Texture Data";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(52, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "File";
            // 
            // ItemFile
            // 
            this.ItemFile.BackColor = System.Drawing.SystemColors.Info;
            this.ItemFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ItemFile.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ItemFile.FormattingEnabled = true;
            this.ItemFile.Location = new System.Drawing.Point(85, 23);
            this.ItemFile.Name = "ItemFile";
            this.ItemFile.Size = new System.Drawing.Size(157, 21);
            this.ItemFile.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(64, 53);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "X";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(161, 53);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Y";
            // 
            // ItemName
            // 
            this.ItemName.BackColor = System.Drawing.SystemColors.Info;
            this.ItemName.BorderColor = System.Drawing.Color.DarkGray;
            this.ItemName.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ItemName.Location = new System.Drawing.Point(55, 81);
            this.ItemName.Name = "ItemName";
            this.ItemName.Size = new System.Drawing.Size(201, 20);
            this.ItemName.TabIndex = 6;
            this.ItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // spritePallete1
            // 
            this.spritePallete1.Action = null;
            this.spritePallete1.ItemControl = null;
            this.spritePallete1.Location = new System.Drawing.Point(13, 30);
            this.spritePallete1.Name = "spritePallete1";
            this.spritePallete1.Size = new System.Drawing.Size(33, 33);
            this.spritePallete1.TabIndex = 7;
            // 
            // ItemY
            // 
            this.ItemY.BackColor = System.Drawing.SystemColors.Info;
            this.ItemY.BorderColor = System.Drawing.Color.DarkGray;
            this.ItemY.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ItemY.Location = new System.Drawing.Point(182, 50);
            this.ItemY.Name = "ItemY";
            this.ItemY.Size = new System.Drawing.Size(60, 20);
            this.ItemY.TabIndex = 6;
            this.ItemY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ItemX
            // 
            this.ItemX.BackColor = System.Drawing.SystemColors.Info;
            this.ItemX.BorderColor = System.Drawing.Color.DarkGray;
            this.ItemX.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ItemX.Location = new System.Drawing.Point(85, 50);
            this.ItemX.Name = "ItemX";
            this.ItemX.Size = new System.Drawing.Size(60, 20);
            this.ItemX.TabIndex = 6;
            this.ItemX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(144, 246);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // ItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ItemName);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ItemId);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ItemControl";
            this.Size = new System.Drawing.Size(295, 534);
            this.Load += new System.EventHandler(this.ItemControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveButton)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton TilesButton;
        private System.Windows.Forms.RadioButton ItemsButton;
        private System.Windows.Forms.RadioButton ObjectsButton;
        private System.Windows.Forms.NumericUpDown ItemId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox SaveButton;
        private CustomTextBox ItemName;
        private System.Windows.Forms.Label ProgressMainLabel;
        private System.Windows.Forms.Label ProgressStatusLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private SpritePallete spritePallete1;
        private System.Windows.Forms.ComboBox ItemFile;
        private CustomTextBox ItemY;
        private CustomTextBox ItemX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

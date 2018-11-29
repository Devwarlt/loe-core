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
            this.IDNumeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.PictureBox();
            this.NameTextBox = new LoESoft.AssetsManager.Core.GUI.HUD.CustomTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IDNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveButton)).BeginInit();
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
            // IDNumeric
            // 
            this.IDNumeric.BackColor = System.Drawing.SystemColors.Info;
            this.IDNumeric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IDNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDNumeric.ForeColor = System.Drawing.SystemColors.Desktop;
            this.IDNumeric.Location = new System.Drawing.Point(55, 55);
            this.IDNumeric.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.IDNumeric.Name = "IDNumeric";
            this.IDNumeric.Size = new System.Drawing.Size(201, 20);
            this.IDNumeric.TabIndex = 2;
            this.IDNumeric.TabStop = false;
            this.IDNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.SaveButton.Image = global::LoESoft.AssetsManager.Properties.Resources.save_icon;
            this.SaveButton.Location = new System.Drawing.Point(265, 15);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(6);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(24, 24);
            this.SaveButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SaveButton.TabIndex = 5;
            this.SaveButton.TabStop = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // NameTextBox
            // 
            this.NameTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.NameTextBox.BorderColor = System.Drawing.Color.DarkGray;
            this.NameTextBox.ForeColor = System.Drawing.SystemColors.Desktop;
            this.NameTextBox.Location = new System.Drawing.Point(55, 81);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(201, 20);
            this.NameTextBox.TabIndex = 6;
            this.NameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IDNumeric);
            this.Controls.Add(this.groupBox1);
            this.Name = "ItemControl";
            this.Size = new System.Drawing.Size(295, 534);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IDNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton TilesButton;
        private System.Windows.Forms.RadioButton ItemsButton;
        private System.Windows.Forms.RadioButton ObjectsButton;
        private System.Windows.Forms.NumericUpDown IDNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox SaveButton;
        private CustomTextBox NameTextBox;
    }
}

namespace LoESoft.MapEditor.Core.GUI.HUD
{
    partial class HUD
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
            this.EditorLabel = new System.Windows.Forms.Label();
            this.NewButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.MapNameLabel = new System.Windows.Forms.Label();
            this.MapSizeLabel = new System.Windows.Forms.Label();
            this.CompressionCheckBox = new System.Windows.Forms.CheckBox();
            this.GridCheckBox = new System.Windows.Forms.CheckBox();
            this.LoadButton = new System.Windows.Forms.Button();
            this.MapOptionsGroup = new System.Windows.Forms.GroupBox();
            this.MapFPSLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PalleteComboBox = new System.Windows.Forms.ComboBox();
            this.PalletePanel = new System.Windows.Forms.Panel();
            this.TitleUnderLine = new System.Windows.Forms.Panel();
            this.MapObjectLabel = new System.Windows.Forms.Label();
            this.MapOptionsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditorLabel
            // 
            this.EditorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditorLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.EditorLabel.Location = new System.Drawing.Point(3, 0);
            this.EditorLabel.Name = "EditorLabel";
            this.EditorLabel.Size = new System.Drawing.Size(194, 36);
            this.EditorLabel.TabIndex = 9;
            this.EditorLabel.Text = "Map Editor";
            this.EditorLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // NewButton
            // 
            this.NewButton.Location = new System.Drawing.Point(10, 47);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(48, 24);
            this.NewButton.TabIndex = 4;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(142, 47);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(48, 24);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // MapNameLabel
            // 
            this.MapNameLabel.Location = new System.Drawing.Point(9, 75);
            this.MapNameLabel.Name = "MapNameLabel";
            this.MapNameLabel.Size = new System.Drawing.Size(181, 13);
            this.MapNameLabel.TabIndex = 0;
            this.MapNameLabel.Text = "Name: -";
            // 
            // MapSizeLabel
            // 
            this.MapSizeLabel.Location = new System.Drawing.Point(9, 96);
            this.MapSizeLabel.Name = "MapSizeLabel";
            this.MapSizeLabel.Size = new System.Drawing.Size(179, 13);
            this.MapSizeLabel.TabIndex = 0;
            this.MapSizeLabel.Text = "Size: -";
            // 
            // CompressionCheckBox
            // 
            this.CompressionCheckBox.AutoSize = true;
            this.CompressionCheckBox.Location = new System.Drawing.Point(10, 42);
            this.CompressionCheckBox.Name = "CompressionCheckBox";
            this.CompressionCheckBox.Size = new System.Drawing.Size(86, 17);
            this.CompressionCheckBox.TabIndex = 0;
            this.CompressionCheckBox.Text = "Compression";
            this.CompressionCheckBox.UseVisualStyleBackColor = true;
            this.CompressionCheckBox.CheckedChanged += new System.EventHandler(this.CompressionCheckBox_CheckedChanged);
            // 
            // GridCheckBox
            // 
            this.GridCheckBox.AutoSize = true;
            this.GridCheckBox.Location = new System.Drawing.Point(10, 19);
            this.GridCheckBox.Name = "GridCheckBox";
            this.GridCheckBox.Size = new System.Drawing.Size(45, 17);
            this.GridCheckBox.TabIndex = 0;
            this.GridCheckBox.Text = "Grid";
            this.GridCheckBox.UseVisualStyleBackColor = true;
            this.GridCheckBox.CheckedChanged += new System.EventHandler(this.GridCheckBox_CheckedChanged);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(76, 47);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(48, 24);
            this.LoadButton.TabIndex = 7;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // MapOptionsGroup
            // 
            this.MapOptionsGroup.Controls.Add(this.MapFPSLabel);
            this.MapOptionsGroup.Controls.Add(this.MapObjectLabel);
            this.MapOptionsGroup.Controls.Add(this.label1);
            this.MapOptionsGroup.Controls.Add(this.PalleteComboBox);
            this.MapOptionsGroup.Controls.Add(this.CompressionCheckBox);
            this.MapOptionsGroup.Controls.Add(this.GridCheckBox);
            this.MapOptionsGroup.ForeColor = System.Drawing.SystemColors.Desktop;
            this.MapOptionsGroup.Location = new System.Drawing.Point(3, 112);
            this.MapOptionsGroup.Name = "MapOptionsGroup";
            this.MapOptionsGroup.Size = new System.Drawing.Size(194, 112);
            this.MapOptionsGroup.TabIndex = 8;
            this.MapOptionsGroup.TabStop = false;
            this.MapOptionsGroup.Text = "Options";
            // 
            // MapFPSLabel
            // 
            this.MapFPSLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MapFPSLabel.Location = new System.Drawing.Point(122, 16);
            this.MapFPSLabel.Name = "MapFPSLabel";
            this.MapFPSLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MapFPSLabel.Size = new System.Drawing.Size(65, 13);
            this.MapFPSLabel.TabIndex = 11;
            this.MapFPSLabel.Text = "FPS: -";
            this.MapFPSLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pallete:";
            // 
            // PalleteComboBox
            // 
            this.PalleteComboBox.FormattingEnabled = true;
            this.PalleteComboBox.Location = new System.Drawing.Point(54, 62);
            this.PalleteComboBox.Name = "PalleteComboBox";
            this.PalleteComboBox.Size = new System.Drawing.Size(131, 21);
            this.PalleteComboBox.TabIndex = 0;
            this.PalleteComboBox.Text = "---";
            this.PalleteComboBox.SelectedIndexChanged += new System.EventHandler(this.PalleteComboBox_SelectedIndexChanged);
            // 
            // PalletePanel
            // 
            this.PalletePanel.AutoScroll = true;
            this.PalletePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PalletePanel.Location = new System.Drawing.Point(3, 230);
            this.PalletePanel.Name = "PalletePanel";
            this.PalletePanel.Size = new System.Drawing.Size(194, 375);
            this.PalletePanel.TabIndex = 2;
            // 
            // TitleUnderLine
            // 
            this.TitleUnderLine.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.TitleUnderLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TitleUnderLine.Location = new System.Drawing.Point(9, 39);
            this.TitleUnderLine.Name = "TitleUnderLine";
            this.TitleUnderLine.Size = new System.Drawing.Size(180, 2);
            this.TitleUnderLine.TabIndex = 10;
            // 
            // ObjectLabel
            // 
            this.MapObjectLabel.AutoSize = true;
            this.MapObjectLabel.Location = new System.Drawing.Point(6, 88);
            this.MapObjectLabel.Name = "ObjectLabel";
            this.MapObjectLabel.Size = new System.Drawing.Size(47, 13);
            this.MapObjectLabel.TabIndex = 1;
            this.MapObjectLabel.Text = "Object: -";
            // 
            // HUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PalletePanel);
            this.Controls.Add(this.MapSizeLabel);
            this.Controls.Add(this.MapNameLabel);
            this.Controls.Add(this.EditorLabel);
            this.Controls.Add(this.NewButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.MapOptionsGroup);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.TitleUnderLine);
            this.Name = "HUD";
            this.Size = new System.Drawing.Size(200, 608);
            this.MapOptionsGroup.ResumeLayout(false);
            this.MapOptionsGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label EditorLabel;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label MapNameLabel;
        private System.Windows.Forms.Label MapSizeLabel;
        private System.Windows.Forms.CheckBox CompressionCheckBox;
        private System.Windows.Forms.CheckBox GridCheckBox;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.GroupBox MapOptionsGroup;
        private System.Windows.Forms.Panel PalletePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox PalleteComboBox;
        private System.Windows.Forms.Panel TitleUnderLine;
        private System.Windows.Forms.Label MapFPSLabel;
        private System.Windows.Forms.Label MapObjectLabel;
    }
}

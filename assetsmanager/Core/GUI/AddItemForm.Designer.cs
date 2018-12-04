namespace LoESoft.AssetsManager.Core.GUI
{
    partial class AddItemForm
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
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ItemName = new LoESoft.AssetsManager.Core.GUI.HUD.CustomTextBox();
            this.SaveButton = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ItemId = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ItemSprite = new LoESoft.AssetsManager.Core.GUI.HUD.SpritePallete();
            this.ItemFile = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ItemX = new System.Windows.Forms.NumericUpDown();
            this.ItemY = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ItemWalkable = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ItemBlocked = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TilesButton = new System.Windows.Forms.RadioButton();
            this.ItemsButton = new System.Windows.Forms.RadioButton();
            this.ObjectsButton = new System.Windows.Forms.RadioButton();
            this.ItemXml = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SaveButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemId)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemY)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ItemName
            // 
            this.ItemName.BackColor = System.Drawing.SystemColors.Info;
            this.ItemName.BorderColor = System.Drawing.Color.DarkGray;
            this.ItemName.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ItemName.Location = new System.Drawing.Point(64, 150);
            this.ItemName.Name = "ItemName";
            this.ItemName.Size = new System.Drawing.Size(234, 20);
            this.ItemName.TabIndex = 18;
            this.ItemName.TabStop = false;
            this.ItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.SystemColors.Desktop;
            this.SaveButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveButton.Enabled = false;
            this.SaveButton.Image = global::LoESoft.AssetsManager.Properties.Resources.hud_check_inactive;
            this.SaveButton.Location = new System.Drawing.Point(274, 15);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(6);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(24, 24);
            this.SaveButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SaveButton.TabIndex = 17;
            this.SaveButton.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(19, 153);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Name";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label7.Location = new System.Drawing.Point(12, 12);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(184, 30);
            this.label7.TabIndex = 15;
            this.label7.Text = "Item Editor";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(38, 126);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "ID";
            // 
            // ItemId
            // 
            this.ItemId.BackColor = System.Drawing.SystemColors.Info;
            this.ItemId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ItemId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemId.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ItemId.Location = new System.Drawing.Point(64, 124);
            this.ItemId.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.ItemId.Name = "ItemId";
            this.ItemId.Size = new System.Drawing.Size(234, 20);
            this.ItemId.TabIndex = 13;
            this.ItemId.TabStop = false;
            this.ItemId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ItemSprite);
            this.groupBox2.Controls.Add(this.ItemFile);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.ItemX);
            this.groupBox2.Controls.Add(this.ItemY);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox2.Location = new System.Drawing.Point(12, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 79);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Texture Data";
            // 
            // ItemSprite
            // 
            this.ItemSprite.Action = null;
            this.ItemSprite.Id = 0;
            this.ItemSprite.Image = null;
            this.ItemSprite.ItemControl = null;
            this.ItemSprite.Location = new System.Drawing.Point(13, 30);
            this.ItemSprite.Name = "ItemSprite";
            this.ItemSprite.Origin = null;
            this.ItemSprite.ParentId = 0;
            this.ItemSprite.Size = new System.Drawing.Size(33, 33);
            this.ItemSprite.TabIndex = 7;
            this.ItemSprite.Type = LoESoft.AssetsManager.Core.Assets.Structure.XmlContent.ContentType.Objects;
            // 
            // ItemFile
            // 
            this.ItemFile.BackColor = System.Drawing.SystemColors.Info;
            this.ItemFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ItemFile.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ItemFile.FormattingEnabled = true;
            this.ItemFile.Location = new System.Drawing.Point(85, 23);
            this.ItemFile.Name = "ItemFile";
            this.ItemFile.Size = new System.Drawing.Size(195, 21);
            this.ItemFile.TabIndex = 4;
            this.ItemFile.TabStop = false;
            this.ItemFile.SelectedIndexChanged += new System.EventHandler(this.ItemFile_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(190, 53);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Y";
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
            // ItemX
            // 
            this.ItemX.BackColor = System.Drawing.SystemColors.Info;
            this.ItemX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ItemX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemX.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ItemX.Location = new System.Drawing.Point(85, 50);
            this.ItemX.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.ItemX.Name = "ItemX";
            this.ItemX.Size = new System.Drawing.Size(65, 20);
            this.ItemX.TabIndex = 2;
            this.ItemX.TabStop = false;
            this.ItemX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ItemX.ValueChanged += new System.EventHandler(this.ItemX_ValueChanged);
            // 
            // ItemY
            // 
            this.ItemY.BackColor = System.Drawing.SystemColors.Info;
            this.ItemY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ItemY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemY.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ItemY.Location = new System.Drawing.Point(215, 50);
            this.ItemY.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.ItemY.Name = "ItemY";
            this.ItemY.Size = new System.Drawing.Size(65, 20);
            this.ItemY.TabIndex = 2;
            this.ItemY.TabStop = false;
            this.ItemY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ItemY.ValueChanged += new System.EventHandler(this.ItemY_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label6.Location = new System.Drawing.Point(9, 61);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "preview";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ItemWalkable);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox4.Location = new System.Drawing.Point(12, 313);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(286, 46);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tiles Content";
            // 
            // ItemWalkable
            // 
            this.ItemWalkable.AutoSize = true;
            this.ItemWalkable.Enabled = false;
            this.ItemWalkable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemWalkable.Location = new System.Drawing.Point(23, 19);
            this.ItemWalkable.Name = "ItemWalkable";
            this.ItemWalkable.Size = new System.Drawing.Size(71, 17);
            this.ItemWalkable.TabIndex = 0;
            this.ItemWalkable.TabStop = false;
            this.ItemWalkable.Text = "Walkable";
            this.ItemWalkable.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ItemBlocked);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox3.Location = new System.Drawing.Point(12, 261);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(286, 46);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Objects Content";
            // 
            // ItemBlocked
            // 
            this.ItemBlocked.AutoSize = true;
            this.ItemBlocked.Enabled = false;
            this.ItemBlocked.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemBlocked.Location = new System.Drawing.Point(23, 19);
            this.ItemBlocked.Name = "ItemBlocked";
            this.ItemBlocked.Size = new System.Drawing.Size(65, 17);
            this.ItemBlocked.TabIndex = 0;
            this.ItemBlocked.TabStop = false;
            this.ItemBlocked.Text = "Blocked";
            this.ItemBlocked.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TilesButton);
            this.groupBox1.Controls.Add(this.ItemsButton);
            this.groupBox1.Controls.Add(this.ObjectsButton);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox1.Location = new System.Drawing.Point(12, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 46);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Content Type";
            // 
            // TilesButton
            // 
            this.TilesButton.AutoSize = true;
            this.TilesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TilesButton.Location = new System.Drawing.Point(193, 19);
            this.TilesButton.Name = "TilesButton";
            this.TilesButton.Size = new System.Drawing.Size(47, 17);
            this.TilesButton.TabIndex = 0;
            this.TilesButton.Text = "Tiles";
            this.TilesButton.UseVisualStyleBackColor = true;
            // 
            // ItemsButton
            // 
            this.ItemsButton.AutoSize = true;
            this.ItemsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemsButton.Location = new System.Drawing.Point(110, 19);
            this.ItemsButton.Name = "ItemsButton";
            this.ItemsButton.Size = new System.Drawing.Size(50, 17);
            this.ItemsButton.TabIndex = 0;
            this.ItemsButton.Text = "Items";
            this.ItemsButton.UseVisualStyleBackColor = true;
            // 
            // ObjectsButton
            // 
            this.ObjectsButton.AutoSize = true;
            this.ObjectsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObjectsButton.Location = new System.Drawing.Point(23, 19);
            this.ObjectsButton.Name = "ObjectsButton";
            this.ObjectsButton.Size = new System.Drawing.Size(61, 17);
            this.ObjectsButton.TabIndex = 0;
            this.ObjectsButton.Text = "Objects";
            this.ObjectsButton.UseVisualStyleBackColor = true;
            // 
            // ItemXml
            // 
            this.ItemXml.BackColor = System.Drawing.SystemColors.Info;
            this.ItemXml.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemXml.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ItemXml.FormattingEnabled = true;
            this.ItemXml.Location = new System.Drawing.Point(64, 45);
            this.ItemXml.Name = "ItemXml";
            this.ItemXml.Size = new System.Drawing.Size(234, 21);
            this.ItemXml.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label8.Location = new System.Drawing.Point(26, 48);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "XML";
            // 
            // AddItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(310, 369);
            this.Controls.Add(this.ItemXml);
            this.Controls.Add(this.ItemName);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ItemId);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddItemForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Item";
            this.Load += new System.EventHandler(this.AddItemForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SaveButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemId)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemY)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HUD.CustomTextBox ItemName;
        private System.Windows.Forms.PictureBox SaveButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ItemId;
        private System.Windows.Forms.GroupBox groupBox2;
        private HUD.SpritePallete ItemSprite;
        private System.Windows.Forms.ComboBox ItemFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown ItemX;
        private System.Windows.Forms.NumericUpDown ItemY;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox ItemWalkable;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox ItemBlocked;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton TilesButton;
        private System.Windows.Forms.RadioButton ItemsButton;
        private System.Windows.Forms.RadioButton ObjectsButton;
        private System.Windows.Forms.ComboBox ItemXml;
        private System.Windows.Forms.Label label8;
    }
}
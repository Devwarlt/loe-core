namespace LoESoft.MapEditor.Core.GUI.Forms
{
    partial class NewMapForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MapFileName = new System.Windows.Forms.TextBox();
            this.Sizes = new System.Windows.Forms.ComboBox();
            this.Create = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Map Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Size:";
            // 
            // MapName
            // 
            this.MapFileName.Location = new System.Drawing.Point(80, 6);
            this.MapFileName.MaxLength = 32;
            this.MapFileName.Name = "MapName";
            this.MapFileName.Size = new System.Drawing.Size(217, 20);
            this.MapFileName.TabIndex = 2;
            this.MapFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Sizes
            // 
            this.Sizes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Sizes.FormattingEnabled = true;
            this.Sizes.Items.AddRange(new object[] {
            "128x128",
            "256x256",
            "384x384",
            "512x512",
            "768x768",
            "1024x1024"});
            this.Sizes.Location = new System.Drawing.Point(339, 5);
            this.Sizes.Name = "Sizes";
            this.Sizes.Size = new System.Drawing.Size(89, 21);
            this.Sizes.TabIndex = 3;
            this.Sizes.Text = "128x128";
            // 
            // Create
            // 
            this.Create.Location = new System.Drawing.Point(12, 36);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(200, 48);
            this.Create.TabIndex = 4;
            this.Create.Text = "Create";
            this.Create.UseVisualStyleBackColor = true;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(228, 36);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(200, 48);
            this.Cancel.TabIndex = 5;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // NewMapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 96);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Create);
            this.Controls.Add(this.Sizes);
            this.Controls.Add(this.MapFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NewMapForm";
            this.ShowIcon = false;
            this.Text = "New Map";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MapFileName;
        private System.Windows.Forms.ComboBox Sizes;
        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.Button Cancel;
    }
}
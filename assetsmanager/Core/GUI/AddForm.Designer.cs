namespace LoESoft.AssetsManager.Core.GUI
{
    partial class AddForm
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
            this.AddXml = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AddItem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddXml
            // 
            this.AddXml.BackColor = System.Drawing.SystemColors.Highlight;
            this.AddXml.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddXml.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddXml.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddXml.ForeColor = System.Drawing.Color.Transparent;
            this.AddXml.Location = new System.Drawing.Point(12, 12);
            this.AddXml.Name = "AddXml";
            this.AddXml.Size = new System.Drawing.Size(75, 23);
            this.AddXml.TabIndex = 0;
            this.AddXml.TabStop = false;
            this.AddXml.Text = "Add";
            this.AddXml.UseVisualStyleBackColor = false;
            this.AddXml.Click += new System.EventHandler(this.AddXml_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(93, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add a XML into assets";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(93, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Add an item into XML";
            // 
            // AddItem
            // 
            this.AddItem.BackColor = System.Drawing.SystemColors.Highlight;
            this.AddItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddItem.ForeColor = System.Drawing.Color.Transparent;
            this.AddItem.Location = new System.Drawing.Point(12, 41);
            this.AddItem.Name = "AddItem";
            this.AddItem.Size = new System.Drawing.Size(75, 23);
            this.AddItem.TabIndex = 0;
            this.AddItem.TabStop = false;
            this.AddItem.Text = "Add";
            this.AddItem.UseVisualStyleBackColor = false;
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(214, 76);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddItem);
            this.Controls.Add(this.AddXml);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "What do you want to add?";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddXml;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddItem;
    }
}
using LoESoft.MapEditor.Core.GUI.HUD;

namespace LoESoft.MapEditor.Core.GUI
{
    partial class MapEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapEditorForm));
            this.hud1 = new LoESoft.MapEditor.Core.GUI.HUD.HUD();
            this.monoGameWindow1 = new LoESoft.MapEditor.Core.GUI.HUD.MEGameControl();
            this.SuspendLayout();
            // 
            // hud1
            // 
            this.hud1.Location = new System.Drawing.Point(609, 0);
            this.hud1.Name = "hud1";
            this.hud1.Size = new System.Drawing.Size(200, 608);
            this.hud1.TabIndex = 1;
            // 
            // monoGameWindow1
            // 
            this.monoGameWindow1.Location = new System.Drawing.Point(0, 0);
            this.monoGameWindow1.Name = "monoGameWindow1";
            this.monoGameWindow1.Size = new System.Drawing.Size(609, 608);
            this.monoGameWindow1.TabIndex = 0;
            this.monoGameWindow1.Text = "monoGameWindow1";
            // 
            // MapEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 608);
            this.Controls.Add(this.hud1);
            this.Controls.Add(this.monoGameWindow1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MapEditorForm";
            this.Text = "LoESoft Games - BRME Map Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MapEditorForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private MEGameControl monoGameWindow1;
        private HUD.HUD hud1;
    }
}
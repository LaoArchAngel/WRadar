namespace Radar.Utilities.Forms.Blips
{
    partial class WowObjectDetails
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
            this.ViewGrid = new ReadOnlyPropertyGrid();
            this.SuspendLayout();
            // 
            // ViewGrid
            // 
            this.ViewGrid.Location = new System.Drawing.Point(12, 12);
            this.ViewGrid.Name = "ViewGrid";
            this.ViewGrid.Size = new System.Drawing.Size(540, 396);
            this.ViewGrid.TabIndex = 0;
            this.ViewGrid.ReadOnly = true;
            // 
            // WowObjectDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 420);
            this.Controls.Add(this.ViewGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "WowObjectDetails";
            this.Text = "Wow Object Details";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private ReadOnlyPropertyGrid ViewGrid;

    }
}
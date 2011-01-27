namespace Radar.Utilities
{
    partial class TrackableEditor
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
            this._patternLbl = new System.Windows.Forms.Label();
            this._namePatternTxtBx = new System.Windows.Forms.TextBox();
            this._nameLbl = new System.Windows.Forms.Label();
            this._nameTxtBx = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _patternLbl
            // 
            this._patternLbl.AutoSize = true;
            this._patternLbl.Location = new System.Drawing.Point(12, 47);
            this._patternLbl.Name = "_patternLbl";
            this._patternLbl.Size = new System.Drawing.Size(72, 13);
            this._patternLbl.TabIndex = 0;
            this._patternLbl.Text = "Name Pattern";
            // 
            // _namePatternTxtBx
            // 
            this._namePatternTxtBx.Location = new System.Drawing.Point(90, 44);
            this._namePatternTxtBx.Name = "_namePatternTxtBx";
            this._namePatternTxtBx.Size = new System.Drawing.Size(163, 20);
            this._namePatternTxtBx.TabIndex = 1;
            this._namePatternTxtBx.TextChanged += new System.EventHandler(this.PatternChanged);
            // 
            // _nameLbl
            // 
            this._nameLbl.AutoSize = true;
            this._nameLbl.Location = new System.Drawing.Point(49, 9);
            this._nameLbl.Name = "_nameLbl";
            this._nameLbl.Size = new System.Drawing.Size(35, 13);
            this._nameLbl.TabIndex = 2;
            this._nameLbl.Text = "Name";
            // 
            // _nameTxtBx
            // 
            this._nameTxtBx.Location = new System.Drawing.Point(90, 9);
            this._nameTxtBx.Name = "_nameTxtBx";
            this._nameTxtBx.Size = new System.Drawing.Size(163, 20);
            this._nameTxtBx.TabIndex = 0;
            this._nameTxtBx.TextChanged += new System.EventHandler(this.NameChanged);
            // 
            // TrackableEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 75);
            this.Controls.Add(this._nameTxtBx);
            this.Controls.Add(this._nameLbl);
            this.Controls.Add(this._namePatternTxtBx);
            this.Controls.Add(this._patternLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "TrackableEditor";
            this.Text = "Trackable";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TryClose);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _patternLbl;
        private System.Windows.Forms.TextBox _namePatternTxtBx;
        private System.Windows.Forms.Label _nameLbl;
        private System.Windows.Forms.TextBox _nameTxtBx;
    }
}
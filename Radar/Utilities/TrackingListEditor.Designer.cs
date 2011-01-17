namespace Radar.Utilities
{
    partial class TrackingListEditor
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
            this._listsLabel = new System.Windows.Forms.Label();
            this._listsCombo = new System.Windows.Forms.ComboBox();
            this._listsAddButton = new System.Windows.Forms.Button();
            this._listsEditBtn = new System.Windows.Forms.Button();
            this._trackablesLstBx = new System.Windows.Forms.ListBox();
            this._trackablesAddBtn = new System.Windows.Forms.Button();
            this._trackablesEditBtn = new System.Windows.Forms.Button();
            this._trackablesDelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _listsLabel
            // 
            this._listsLabel.AutoSize = true;
            this._listsLabel.Location = new System.Drawing.Point(12, 9);
            this._listsLabel.Name = "_listsLabel";
            this._listsLabel.Size = new System.Drawing.Size(68, 13);
            this._listsLabel.TabIndex = 0;
            this._listsLabel.Text = "Tracking List";
            // 
            // _listsCombo
            // 
            this._listsCombo.Enabled = false;
            this._listsCombo.FormattingEnabled = true;
            this._listsCombo.Location = new System.Drawing.Point(86, 6);
            this._listsCombo.Name = "_listsCombo";
            this._listsCombo.Size = new System.Drawing.Size(185, 21);
            this._listsCombo.TabIndex = 1;
            this._listsCombo.SelectedIndexChanged += new System.EventHandler(this.ListChanged);
            // 
            // _listsAddButton
            // 
            this._listsAddButton.Enabled = false;
            this._listsAddButton.Location = new System.Drawing.Point(277, 4);
            this._listsAddButton.Name = "_listsAddButton";
            this._listsAddButton.Size = new System.Drawing.Size(41, 23);
            this._listsAddButton.TabIndex = 2;
            this._listsAddButton.Text = "Add";
            this._listsAddButton.UseVisualStyleBackColor = true;
            // 
            // _listsEditBtn
            // 
            this._listsEditBtn.Enabled = false;
            this._listsEditBtn.Location = new System.Drawing.Point(324, 4);
            this._listsEditBtn.Name = "_listsEditBtn";
            this._listsEditBtn.Size = new System.Drawing.Size(38, 23);
            this._listsEditBtn.TabIndex = 3;
            this._listsEditBtn.Text = "Edit";
            this._listsEditBtn.UseVisualStyleBackColor = true;
            // 
            // _trackablesLstBx
            // 
            this._trackablesLstBx.FormattingEnabled = true;
            this._trackablesLstBx.Location = new System.Drawing.Point(15, 33);
            this._trackablesLstBx.Name = "_trackablesLstBx";
            this._trackablesLstBx.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this._trackablesLstBx.Size = new System.Drawing.Size(256, 186);
            this._trackablesLstBx.TabIndex = 4;
            // 
            // _trackablesAddBtn
            // 
            this._trackablesAddBtn.Location = new System.Drawing.Point(277, 33);
            this._trackablesAddBtn.Name = "_trackablesAddBtn";
            this._trackablesAddBtn.Size = new System.Drawing.Size(41, 23);
            this._trackablesAddBtn.TabIndex = 5;
            this._trackablesAddBtn.Text = "New";
            this._trackablesAddBtn.UseVisualStyleBackColor = true;
            this._trackablesAddBtn.Click += new System.EventHandler(this.NewTrackable);
            // 
            // _trackablesEditBtn
            // 
            this._trackablesEditBtn.Location = new System.Drawing.Point(277, 62);
            this._trackablesEditBtn.Name = "_trackablesEditBtn";
            this._trackablesEditBtn.Size = new System.Drawing.Size(41, 23);
            this._trackablesEditBtn.TabIndex = 6;
            this._trackablesEditBtn.Text = "Edit";
            this._trackablesEditBtn.UseVisualStyleBackColor = true;
            this._trackablesEditBtn.Click += new System.EventHandler(this.EditTrackable);
            // 
            // _trackablesDelBtn
            // 
            this._trackablesDelBtn.Location = new System.Drawing.Point(277, 91);
            this._trackablesDelBtn.Name = "_trackablesDelBtn";
            this._trackablesDelBtn.Size = new System.Drawing.Size(50, 23);
            this._trackablesDelBtn.TabIndex = 7;
            this._trackablesDelBtn.Text = "Delete";
            this._trackablesDelBtn.UseVisualStyleBackColor = true;
            this._trackablesDelBtn.Click += new System.EventHandler(this.DeleteTrackables);
            // 
            // TrackingListEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 234);
            this.Controls.Add(this._trackablesDelBtn);
            this.Controls.Add(this._trackablesEditBtn);
            this.Controls.Add(this._trackablesAddBtn);
            this.Controls.Add(this._trackablesLstBx);
            this.Controls.Add(this._listsEditBtn);
            this.Controls.Add(this._listsAddButton);
            this.Controls.Add(this._listsCombo);
            this.Controls.Add(this._listsLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TrackingListEditor";
            this.Text = "TrackingListEditor";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.ReloadInfo);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _listsLabel;
        private System.Windows.Forms.ComboBox _listsCombo;
        private System.Windows.Forms.Button _listsAddButton;
        private System.Windows.Forms.Button _listsEditBtn;
        private System.Windows.Forms.ListBox _trackablesLstBx;
        private System.Windows.Forms.Button _trackablesAddBtn;
        private System.Windows.Forms.Button _trackablesEditBtn;
        private System.Windows.Forms.Button _trackablesDelBtn;
    }
}
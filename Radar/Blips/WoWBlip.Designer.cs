using System.ComponentModel;
using System.Windows.Forms;
using BlackRain.Common.Contracts;

namespace Radar.Blips
{
	partial class WowBlip
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = new Container();

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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.blipMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.objectInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.headerSep = new System.Windows.Forms.ToolStripSeparator();
            this.trackName = new System.Windows.Forms.ToolStripMenuItem();
            this._trackingMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.blipMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // blipMenu
            // 
            this.blipMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.objectInfo,
            this.headerSep,
            this.trackName,
            this._trackingMenu});
            this.blipMenu.Name = "Tracking Menu";
            this.blipMenu.ShowImageMargin = false;
            this.blipMenu.Size = new System.Drawing.Size(134, 76);
            // 
            // objectInfo
            // 
            this.objectInfo.Enabled = false;
            this.objectInfo.Name = "objectInfo";
            this.objectInfo.Size = new System.Drawing.Size(133, 22);
            // 
            // headerSep
            // 
            this.headerSep.Name = "headerSep";
            this.headerSep.Size = new System.Drawing.Size(130, 6);
            // 
            // trackName
            // 
            this.trackName.Name = "trackName";
            this.trackName.Size = new System.Drawing.Size(133, 22);
            this.trackName.Text = "Track this name";
            this.trackName.Click += new System.EventHandler(this.SelectTracking);
            // 
            // _trackingMenu
            // 
            this._trackingMenu.Name = "_trackingMenu";
            this._trackingMenu.Size = new System.Drawing.Size(133, 22);
            this._trackingMenu.Text = "Tracking Menu";
            this._trackingMenu.Click += new System.EventHandler(OpenTrackingMenu);
            // 
            // WowBlip
            // 
            this.ContextMenuStrip = this.blipMenu;
            this.Size = new System.Drawing.Size(18, 18);
            this.DoubleClick += new System.EventHandler(this.ShowDetails);
            this.blipMenu.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		protected System.Windows.Forms.ContextMenuStrip blipMenu;
        //private System.Windows.Forms.ToolStripMenuItem trackType;
		private System.Windows.Forms.ToolStripMenuItem trackName;
        private ToolStripMenuItem objectInfo;
        private ToolStripSeparator headerSep;
        private ToolStripMenuItem _trackingMenu;
	}
}

using System.Drawing;

namespace Radar.Screen
{
    partial class Radar
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Radar));
            this.PulseTimer = new System.Windows.Forms.Timer(this.components);
            this.tp = new System.Windows.Forms.ToolTip(this.components);
            this.RadarMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.wowInstances = new System.Windows.Forms.ToolStripMenuItem();
            this.resetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tslSettings = new System.Windows.Forms.ToolStripLabel("Settings");
            this.tsmiStColors = new System.Windows.Forms.ToolStripMenuItem("Colors...");
            this.tss2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RadarMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PulseTimer
            // 
            this.PulseTimer.Enabled = true;
            this.PulseTimer.Interval = 50;
            this.PulseTimer.Tick += new System.EventHandler(this.PulseTick);
            // 
            // tp
            // 
            this.tp.AutoPopDelay = 5000;
            this.tp.InitialDelay = 0;
            this.tp.ReshowDelay = 0;
            this.tp.UseAnimation = false;
            this.tp.UseFading = false;
            // 
            // RadarMenu
            // 
            this.RadarMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wowInstances,
            this.resetMenuItem,
            this.toolStripSeparator1,
            this.tslSettings,
            this.tsmiStColors,
            this.tss2,
            this.ExitMenuItem});
            this.RadarMenu.Name = "RadarMenu";
            this.RadarMenu.Size = new System.Drawing.Size(156, 98);
            this.RadarMenu.Opening += new System.ComponentModel.CancelEventHandler(this.LoadWowInstances);
            // 
            // wowInstances
            // 
            this.wowInstances.Name = "wowInstances";
            this.wowInstances.Size = new System.Drawing.Size(155, 22);
            this.wowInstances.Text = "WoW Instances";
            // 
            // resetMenuItem
            // 
            this.resetMenuItem.Name = "resetMenuItem";
            this.resetMenuItem.Size = new System.Drawing.Size(155, 22);
            this.resetMenuItem.Text = "Reset!";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            //
            //
            //
            this.tsmiStColors.Click += ShowColorSettings;
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(155, 22);
            this.ExitMenuItem.Text = "Exit";
            this.ExitMenuItem.Click += new System.EventHandler(QuitRadar);
            // 
            // Radar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Red;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(542, 542);
            this.ContextMenuStrip = this.RadarMenu;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = Utilities.Security.RandomString(7);
            this.Text = Name;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.White;
            this.RadarMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer PulseTimer;
        private System.Windows.Forms.ToolTip tp;
        private System.Windows.Forms.ContextMenuStrip RadarMenu;
        private System.Windows.Forms.ToolStripMenuItem wowInstances;
        private System.Windows.Forms.ToolStripMenuItem resetMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ToolStripSeparator tss2;
        private System.Windows.Forms.ToolStripLabel tslSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmiStColors;
    }
}
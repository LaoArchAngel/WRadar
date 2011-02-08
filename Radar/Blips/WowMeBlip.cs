using System;
using System.Drawing;
using System.Windows.Forms;
using BlackRain.WowObjects;
using Radar.Properties;

namespace Radar.Blips
{
    internal class WowMeBlip : WowPlayerBlip
    {
        private Point _mouseOffset;

        public WowMeBlip(WowPlayer unit) : base(unit)
        {
            MouseDown += RecordPosition;
            MouseMove += MoveScreen;

            FillContextMenu();
        }

        protected override void DrawHighlight(System.Drawing.Drawing2D.GraphicsPath graphicsPath, Graphics graphics)
        {
            // DO NOT highlight the player.
            return;
        }

        private void FillContextMenu()
        {
        	#region Modes
            blipMenu.Items.Add(new ToolStripSeparator());
            
            var toolStripButton = new ToolStripButton
                              {
                                  Name = "HUDMode",
                                  Text = Resources.WowMeBlip_FillContextMenu_HUD_Mode,
                                  CheckOnClick = true,
                                  Checked = false
                              };

            blipMenu.Items.Add(toolStripButton);
            toolStripButton.CheckedChanged += SetHUDMode;

            toolStripButton = new ToolStripButton
                                  {
                                      Name = "Exclusive",
                                      Text = Resources.WowMeBlip_FillContextMenu_Exclusive_Mode,
                                      CheckOnClick = true,
                                      Checked = false
                                  };
            blipMenu.Items.Add(toolStripButton);
            toolStripButton.CheckedChanged += SetExclusiveMode;
            #endregion
            
            #region Settings
            blipMenu.Items.Add(new ToolStripSeparator());
            
            var tsmiNewItem = new ToolStripMenuItem
            {
            	Name = "ColorSettings",
            	Text = "Colors..."
            };
            tsmiNewItem.Click += delegate { Utilities.Forms.Settings.Colors.ColorSettings.ShowDialog(); };

            blipMenu.Items.Add(tsmiNewItem);
            #endregion
        }

        private static void SetExclusiveMode(object sender, EventArgs eventArgs)
        {
            var exMode = sender as ToolStripButton;

            if (exMode == null) return;

            Settings.Screen.Exclusive = exMode.Checked;
        }

        private void SetHUDMode(object sender, EventArgs e)
        {
            var hudMode = sender as ToolStripButton;

            if (hudMode == null) return;

            Settings.Screen.HUDMode = hudMode.Checked;
            if (Parent != null)
            {
                Parent.BackgroundImage = Utilities.Radar.ScreenImage(Settings.Screen.Zoom);
            }
        }

        private void RecordPosition(object sender, MouseEventArgs e)
        {
            _mouseOffset = MousePosition;
        }

        private void MoveScreen(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            if (Parent == null) return;

            var pos = MousePosition;
            var delta = new Point(pos.X - _mouseOffset.X, pos.Y - _mouseOffset.Y);
            var current = Parent.Location;
            current.Offset(delta);

            Parent.Location = current;
            _mouseOffset = pos;
        }
    }
}
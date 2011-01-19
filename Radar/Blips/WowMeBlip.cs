using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BlackRain.Common.Objects;
using Radar.Properties;

namespace Radar.Blips
{
    internal class WowMeBlip : WowPlayerBlip
    {
        private Point mouseOffset;

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
            mouseOffset = MousePosition;
        }

        private void MoveScreen(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            if (Parent == null) return;

            var pos = MousePosition;
            var delta = new Point(pos.X - mouseOffset.X, pos.Y - mouseOffset.Y);
            var current = Parent.Location;
            current.Offset(delta);

            Parent.Location = current;
            mouseOffset = pos;
        }
    }
}
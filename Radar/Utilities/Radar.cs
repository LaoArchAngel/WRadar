using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Linq;
using BlackRain.Common.Contracts;
using BlackRain.Common.Objects;
using Radar.Blips;

namespace Radar.Utilities
{
    public static class Radar
    {
        private static readonly WowObjectDetails _detailForm = new WowObjectDetails();

        public static WowObjectDetails DetailForm
        {
            get { return _detailForm; }
        }

        /// <summary>
        /// Clears out all blips no longer in range.
        /// </summary>
        /// <param name="screen">The screen containing the blips.</param>
        public static void CleanBlips(Control screen)
        {
            var blips =
                screen.Controls.OfType<WowBlip>().Where(
                    x =>
                    !ObjectManager.Objects.Exists(y => (y.GUID == x.BlipObject.GUID)) ||
                    (Settings.Screen.Exclusive && !x.Tracked) && !(x is WowMeBlip));

            foreach (var wowBlip in blips)
            {
                screen.Controls.Remove(wowBlip);
            }
        }

        /// <summary>
        /// Draws <paramref name="blip"/> at a relative location to the <see cref="WowPlayerBlip"/> representing <see cref="ObjectManager.Me"/>.
        /// </summary>
        /// <param name="blip">The control to be drawn.</param>
        /// <param name="screen">The control on which to draw <paramref name="blip"/>.</param>
        /// <param name="tp">Shows the name of <see cref="blip"/> if it impliments <see cref="INamed"/></param>
        public static void DrawWowBlip(WowBlip blip, Control screen, ToolTip tp)
        {
            var current = GetWowBlipByGuid(screen, blip.BlipObject.GUID);

            if (Settings.Screen.Exclusive && !(blip.BlipObject.IsMe))
            {
                if (current == null && !blip.Tracked)
                    return;

                if (current != null && !current.Tracked)
                    return;
            }

            var x = MathFunctions.RelativeCoordinate(ObjectManager.Me.X, blip.BlipObject.X, screen.Width/2F);
            var y = MathFunctions.RelativeCoordinate(ObjectManager.Me.Y, blip.BlipObject.Y, screen.Height/2F);
            var p = new Point(y, x);

            if (current != null)
            {
                current.Location = p;
                current.Refresh();
                return;
            }

            screen.Controls.Add(blip);

            blip.Location = p;

            if (blip.BlipObject is INamed)
            {
                tp.SetToolTip(blip, ((INamed) blip.BlipObject).Name);
            }
        }

        /// <summary>
        /// Finds a blip currently displayed by the <see cref="WowObject.GUID"/> of its 
        /// <see cref="WowBlip.BlipObject"/>
        /// </summary>
        /// <param name="screen">Radar screen containing the blips.</param>
        /// <param name="guid">The numberic GUID of the <see cref="WowObject"/></param>
        /// <returns>The blip containing the <see cref="WowObject"/> with the provided GUID. <c>null</c> if no such
        /// blip was found.</returns>
        public static WowBlip GetWowBlipByGuid(Control screen, ulong guid)
        {
            var blips = screen.Controls.OfType<WowBlip>();

            try
            {
                return blips.FirstOrDefault(blip => blip.BlipObject.GUID == guid);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Refreshes the supplied screen with the wow objects.
        /// </summary>
        /// <param name="screen"></param>
        /// <param name="tp"></param>
        public static void RefreshScreen(Control screen, ToolTip tp)
        {
            // Update our memory cache from WoW.
            ObjectManager.Pulse();

            // If Me is not set, something is wrong.
            if (ObjectManager.Me == null) return;
            if (ObjectManager.Me.GUID == 0)
            {
                ObjectManager.Reset();
                return;
            }

            CleanBlips(screen);

            WowUnitBlip me = null;
            WowUnitBlip target = null;

            foreach (var wowGameObject in ObjectManager.GameObjects)
            {
                DrawWowBlip(new WowGOBlip(wowGameObject), screen, tp);
            }

            // No reason to draw these.  They have no coordinates.
            //foreach (var wowDynamicObject in ObjectManager.ObjectsOfType<WowDynamicObject>())
            //{
            //    DrawWowBlip(new WowDynamicObjectBlip(wowDynamicObject), screen, tp);
            //}

            foreach (var unit in ObjectManager.GetObjectsOfType<WowUnit>(true, true))
            {
                WowUnitBlip blip;
                if (!(unit is WowPlayer))
                {
                    blip = new WowUnitBlip(unit);
                }
                else
                {
                    blip = new WowPlayerBlip((WowPlayer) unit);
                    if (blip.BlipObject.IsMe)
                    {
                        blip = new WowMeBlip((WowPlayer) unit);
                        me = blip;
                    }
                }

                DrawWowBlip(blip, screen, tp);

                if (ObjectManager.Me.Target == unit.GUID) target = blip;
            }

            if (target != null) target.BringToFront();
            if (me != null) me.BringToFront();

            //screen.Refresh();
        }

        /// <summary>
        /// Draws our circular radar screen.
        /// </summary>
        /// <param name="zoom">Magnitude of zoom into the radar</param>
        /// <returns>Image to be set as the <see cref="Form.BackgroundImage"/> of our screen.</returns>
        public static Image ScreenImage(float zoom)
        {
            var bm = new Bitmap((int) (542/2.5F*Settings.Screen.Zoom), (int) (542/2.5F*Settings.Screen.Zoom),
                                PixelFormat.Format24bppRgb);
            var rec = new Rectangle(0, 0, bm.Width, bm.Height);

            using (var g = Graphics.FromImage(bm))
            {
                g.Clear(Settings.Colors.RadarToClear);
                g.SmoothingMode = SmoothingMode.None;
                using (var sb = new SolidBrush(Settings.Colors.RadarToClear))
                {
                    g.FillRectangle(sb, rec);
                }

                if (!Settings.Screen.HUDMode)
                    using (var sb = new SolidBrush(Settings.Colors.Radar))
                    {
                        g.FillEllipse(sb, rec);
                    }
            }

            return bm;
        }
    }
}
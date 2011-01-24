using System.ComponentModel;
using System.Drawing;
using BlackRain;
using Radar.Blips;

namespace Radar.Screen
{
    internal class BlipDrawer : BackgroundWorker
    {
        #region Properties

        public Radar Screen { get; private set; }
        public WowBlip ToDraw { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Instantiates a new BackgroundWorker whose only purpose is to draw blips.
        /// </summary>
        /// <param name="screen">The form containing the blips.</param>
        /// <param name="toDraw">Blip being drawn</param>
        public BlipDrawer(Radar screen, WowBlip toDraw)
        {
            Screen = screen;
            ToDraw = toDraw;
        }

        #endregion

        #region Methods

        #region Protected

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            var current = Utilities.Radar.GetWowBlipByGuid(Screen, ToDraw.BlipObject.GUID);

            if (Settings.Screen.Exclusive && !(ToDraw.BlipObject.IsMe))
            {
                if (current == null && !ToDraw.Tracked)
                    return;

                if (current != null && !current.Tracked)
                    return;
            }

            var x = Utilities.MathFunctions.RelativeCoordinate(ObjectManager.Me.X, ToDraw.BlipObject.X, Screen.Width/2F);
            var y = Utilities.MathFunctions.RelativeCoordinate(ObjectManager.Me.Y, ToDraw.BlipObject.Y, Screen.Height/2F);
            var p = new Point(y, x);

            if (current != null)
            {
                e.Result = new DrawerResults
                               {
                                   Blip = current,
                                   Exists = true,
                                   Location = p
                               };
                return;
            }

            ToDraw.Location = p;

            e.Result = new DrawerResults
                           {
                               Blip = ToDraw
                           };
        }

        #endregion

        #endregion
    }

    internal class DrawerResults
    {
        #region Properties

        public WowBlip Blip { get; set; }

        public bool Exists { get; set; }

        public Point Location { get; set; }

        #endregion
    }
}
using System.Drawing;
using System.Drawing.Drawing2D;
using Radar.Blips;

namespace Radar.Settings
{
    public static class Screen
    {
        #region Fields

        private static float _zoom = 2.5F;
        private static GraphicsPath _shapeGO;
        private static GraphicsPath _shapePlayer;
        private static GraphicsPath _shapeUnit;
        //private static GraphicsPath _pathPointer;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets whether the radar is in exclusive mode.
        /// </summary>
        /// <remarks>Exclusive mode is when the user only wants the radar to pain the tracked objects.</remarks>
        public static bool Exclusive { get; set; }

        /// <summary>
        /// Gets or sets whether the radar is in HUD mode.
        /// </summary>
        /// <remarks>HUD mode makes the background invisible, making it useable as an on-screen HUD.</remarks>
        public static bool HUDMode { get; set; }

        public static GraphicsPath ShapeGO
        {
            get
            {
                if (_shapeGO == null)
                {
                    _shapeGO = new GraphicsPath();
                    _shapeGO.AddRectangle(new Rectangle(WowBlip.TOTAL_WIDTH/4, WowBlip.TOTAL_HEIGHT/2,
                                                        WowBlip.TOTAL_WIDTH/2, WowBlip.TOTAL_HEIGHT/2));
                }

                return _shapeGO;
            }
        }

        public static GraphicsPath ShapeUnit
        {
            get
            {
                if (_shapeUnit == null)
                {
                    _shapeUnit = new GraphicsPath();
                    _shapeUnit.AddEllipse(WowBlip.TOTAL_WIDTH/4, WowBlip.TOTAL_HEIGHT/2, WowBlip.TOTAL_WIDTH/2,
                                          WowBlip.TOTAL_HEIGHT/2);
                }

                return _shapeUnit;
            }
        }

        public static GraphicsPath ShapePlayer
        {
            get
            {
                if (_shapePlayer == null)
                {
                    _shapePlayer = new GraphicsPath();
                    _shapePlayer.AddPolygon(new[]
                                                {
                                                    new Point(WowBlip.TOTAL_WIDTH/2, WowBlip.TOTAL_HEIGHT/2),
                                                    new Point(WowBlip.TOTAL_WIDTH, WowBlip.TOTAL_HEIGHT),
                                                    new Point(0, WowBlip.TOTAL_HEIGHT)
                                                });
                }

                return _shapePlayer;
            }
        }

        /// <summary>
        /// Gets or sets the zoom magnitude tothe radar.
        /// </summary>
        /// <value>A <see cref="float"/> between .5 and 2.  If the value is not within the limits, 
        /// the appropriate limit will be used.</value>
        public static float Zoom
        {
            get { return _zoom; }
            set
            {
                if (value < .5F)
                {
                    _zoom = .5F;
                }
                else if (value > 2.5F)
                {
                    _zoom = 2.5F;
                }
                else
                    _zoom = value;
            }
        }

        #endregion
    }
}
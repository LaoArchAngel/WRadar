using System.Drawing;
using System.Drawing.Drawing2D;
using BlackRain.Common.Objects;
using BlackRain.WowObject;
using Radar.Tracking;

namespace Radar.Blips
{
	class WowDynamicObjectBlip : WowBlip
	{
		#region Properties

		protected override Color BlipColor
		{
			get { return Settings.Colors.UnitDead; }
		}

		public new WowDynamicObject BlipObject { get; set; }

		#endregion

		#region Constructor

        public WowDynamicObjectBlip(WowDynamicObject wowGameObject)
            : base(wowGameObject)
        {
            BlipObject = wowGameObject;
        }

		#endregion

		#region Methods

		#region Implimented

        /// <summary>
        /// Draws the shape for the GameObject.  Rectangle.
        /// </summary>
        /// <param name="g"><see cref="Graphics"/> object drawing the blip.</param>
		protected override void DrawShape(GraphicsPath g)
		{
			g.AddRectangle(new Rectangle(0, 5, 10, 5));
		}

		#endregion

		#endregion
	}
}

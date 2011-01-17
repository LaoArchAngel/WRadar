using System.Drawing;
using System.Drawing.Drawing2D;
using BlackRain.Common.Objects;
using Radar.Tracking;

namespace Radar.Blips
{
	class WowGOBlip : WowBlip
	{
		#region Properties

		protected override Color BlipColor
		{
			get { return Settings.Colors.GameObject; }
		}

		public new WowGameObject BlipObject { get; set; }

		#endregion

		#region Constructor

        public WowGOBlip(WowGameObject wowGameObject) : base(wowGameObject)
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
            g.AddRectangle(new Rectangle(TOTAL_WIDTH/4, TOTAL_HEIGHT/2, TOTAL_WIDTH/2, TOTAL_HEIGHT/2));
		}

		#endregion

		#endregion
	}
}

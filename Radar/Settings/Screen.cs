using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Radar.Settings
{
	public static class Screen
	{
		#region Fields

		private static float _zoom = 2.5F;

		#endregion

		#region Properties

        public static bool HUDMode { get; set; }

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
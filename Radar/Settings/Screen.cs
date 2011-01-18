using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace Radar.Settings
{
	public static class Screen
	{
		#region Fields

		private static float _zoom = 2.5F;
	    //private static GraphicsPath _pathPointer;

		#endregion

		#region Properties

        /// <summary>
        /// Gets or sets whether the radar is in exclusive mode.
        /// </summary>
        /// <remarks>Exclusive mode is when the user only wants the radar to pain the tracked objects.</remarks>
        public static bool Exclusive { get; set; }
        
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
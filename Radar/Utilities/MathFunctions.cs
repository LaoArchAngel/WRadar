using System;
using RadarSettings = Radar.Settings;

namespace Radar.Utilities
{
	class MathFunctions
	{
		public static float RadianToDegree(float rotation)
		{
			return (float)(rotation * (180 / Math.PI));
		}

		public static int RelativeCoordinate(float myCoord, float otherCoord, float centerOffset)
		{
			return (int)((myCoord - otherCoord) * RadarSettings.Screen.Zoom + centerOffset);
		}
	}
}

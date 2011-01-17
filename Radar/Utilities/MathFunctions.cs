using System;

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
			return (int)((myCoord - otherCoord) * Settings.Screen.Zoom + centerOffset);
		}
	}
}

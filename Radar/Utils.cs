using System;
using System.Collections.Generic;
using System.Linq;
using BlackRain.Common.Objects;

namespace Radar
{
	class Utils
	{
		public static float RadianToDegree(float rotation)
		{
			return (float)(rotation * (180 / Math.PI));
		}

		public static WowObject GetObjectByGuid(List<WowObject> allWoWObjects, ulong guid)
		{
			return allWoWObjects.FirstOrDefault(o => o.GUID == guid);
		}
	}
}

using System.Collections.Generic;
using System.Linq;
using BlackRain.Common.Objects;
using BlackRain.WowObject;
using BlackRain.WowObjects;

namespace Radar.Utilities
{
	class ObjectQueries
	{
		/// <summary>
		/// Gets a <see cref="WowObject"/> from a list by its <see cref="WowObject.GUID"/> property.
		/// </summary>
		/// <param name="allWoWObjects">List of <see cref="WowObject"/>s to search.</param>
		/// <param name="guid">The GUID we're searching for.</param>
		/// <returns><see cref="WowObject"/> with the given GUID. <c>null</c> if no match is found.</returns>
		public static WowObject GetObjectByGuid(List<WowObject> allWoWObjects, ulong guid)
		{
			return allWoWObjects.FirstOrDefault(o => o.GUID == guid);
		}
	}
}

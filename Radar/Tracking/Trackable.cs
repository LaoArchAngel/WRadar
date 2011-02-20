using System;
using BlackRain.WowObjects;
using BlackRain.WowObjects.Contracts;

namespace Radar.Tracking
{
    /// <summary>
    /// This abstract class contains defining behavior and default values for all trackable objects.
    /// </summary>
    public class Trackable
    {
        #region Properties

        public string Name { get; set; }

        public string Pattern { get; set; }

        #endregion

        public bool IsMatch(WowObject wowObject)
        {
            var named = wowObject as INamed;

            if (named == null) return false;

            return (named.Name.Equals(Pattern, StringComparison.InvariantCultureIgnoreCase) ||
                    Utilities.Tracking.WildCardMatches(named.Name.ToUpperInvariant(), Pattern.ToUpperInvariant()));
        }
    }
}

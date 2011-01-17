using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Radar.Tracking;

namespace Radar.Settings
{
    internal static class Tracking
    {
        #region Fields

        private static List<TrackingList> _trackingLists;
        private static TrackingList _default;

        #endregion

        #region Properties

        public static List<TrackingList> TrackingLists
        {
            get { return _trackingLists ?? (_trackingLists = new List<TrackingList> {Default}); }
        }

        public static TrackingList Default
        {
            get { return _default ?? (_default = new TrackingList("Default")); }
        }

        #endregion
    }
}
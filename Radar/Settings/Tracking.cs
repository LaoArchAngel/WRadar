using System.Collections.Generic;
using System.IO;
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

        #region Methods

        public static void LoadTrackingLists()
        {
            foreach (var file in Directory.GetFiles(Persistance.SaveDir.ToString()))
            {
                var tlist = TrackingList.Load(file);

                if (tlist.Name == "Default")
                {
                    _default = tlist;
                }
            }
        }

        #endregion
    }
}
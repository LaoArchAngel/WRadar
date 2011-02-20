using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radar.Tracking;

namespace UnitTests
{
    [TestClass]
    public class TrackingTests
    {
        [TestMethod]
        public void TrackignListSave()
        {
            var tlist = new TrackingList("Test");
            var track = new Trackable {Name = "Alpha", Pattern = "Alpha"};
            tlist.Trackables.Add(track);
            tlist.SoundFile = "TestSound";

            TrackingList.Save(tlist);
        }

        [TestMethod]
        public void TrackingListLode()
        {
            const string listName = "LoadTest";
            const string trackName = "BravoName";
            const string trackPattern = "BravoPattern";
            const string soundFile = "BravoSound";

            var tlist = new TrackingList(listName);
            tlist.Trackables.Add(new Trackable{Name = trackName, Pattern = trackPattern});
            tlist.SoundFile = soundFile;
            TrackingList.Save(tlist);

            foreach (var file in Directory.GetFiles(string.Format("{0}", Radar.Settings.Persistance.SaveDir)))
            {
                tlist = TrackingList.Load(file);
            }

            Assert.AreEqual(listName, tlist.Name, "List name mismatch");
            Assert.IsNotNull(tlist.Trackables, "List is null");
            Assert.AreEqual(1, tlist.Trackables.Count, "List count incorrect");
            Assert.AreEqual(trackName, tlist.Trackables[0].Name, "Trackable name mismatch.");
            Assert.AreEqual(trackPattern, tlist.Trackables[0].Pattern, "Pattern mismatch.");
            Assert.AreEqual(soundFile, tlist.SoundFile, "SoundFile mismatch");
        }
    }
}

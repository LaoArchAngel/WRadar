using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using BlackRain.WowObjects;

namespace Radar.Tracking
{
	[XmlRoot("TrackingList")]
    internal class TrackingList : List<Trackable>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name of the tracking list.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Sound file specified for this list.
        /// </summary>
        public string SoundFile { get; set; }

        #endregion

        #region Constructors

        public TrackingList(string name)
        {
            Name = name;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Checks if the supplied object matches any <see cref="Trackable"/> in itself.
        /// </summary>
        /// <param name="wowObject">Any object of (sub)type <see cref="WowObject"/></param>
        /// <param name="alreadyTracked">Whether or not the blip containing <paramref name="wowObject"/> is currently tracked.</param>
        /// <returns><c>TRUE</c> if any <see cref="Trackable"/> in this list matches <see cref="wowObject"/>.</returns>
        internal bool IsTracked(WowObject wowObject, bool alreadyTracked)
        {
            if (Exists(t => t.IsMatch(wowObject)))
            {
                // Play our tracking sound if we have not done so already.
                if (!alreadyTracked)
                {
                    if (!string.IsNullOrEmpty(SoundFile))
                        Settings.Sounds.List.Sounds[SoundFile].Play();
                    else
                        Settings.Sounds.List.Default.Play();
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Saves this TrackingList and then saves each of its Trackables.
        /// </summary>
        /// <param name="list">The TrackingList to be saved out to a file.</param>
        internal static void Save(TrackingList list)
        {
        	var serializer = new XmlSerializer(list.GetType());

            using (
                TextWriter writer =
                    new StreamWriter(string.Format("{0}\\{1}_{2}.xml", Settings.Persistance.SaveDir.FullName,
                                               list.GetType().Name, list.Name)))
            {
                serializer.Serialize(writer, list);
            }
        }
        
        /// <summary>
        /// Loads a TrackingList from the given file.
        /// </summary>
        /// <param name="listFile">The filename (including path) of the serialized TrackingList.</param>
        /// <returns>Deserialized TrackingList.</returns>
        internal static TrackingList Load(string listFile)
        {
        	TrackingList loaded;
        	
        	using(var fs = new FileStream(listFile, FileMode.Open))
        	{
        		var serializer = new XmlSerializer(typeof(TrackingList));
        		loaded = (TrackingList)serializer.Deserialize(fs);
        	}
        	
        	return loaded;
        }

        #endregion
    }
}
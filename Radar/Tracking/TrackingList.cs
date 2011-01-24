using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using BlackRain.WowObjects;

namespace Radar.Tracking
{
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
        /// Saves this TrackingList and the saves each of its Trackables.
        /// </summary>
        internal void Save()
        {
            var serializer = new XmlSerializer(GetType());

            using (
                TextWriter writer =
                    new StreamWriter(string.Format("{0}\\{1}_{2}.xml", Settings.Persistance.SaveDir.FullName,
                                                   GetType().Name, Name)))
            {
                serializer.Serialize(writer, this);
            }

            SaveTrackables();
        }

        /// <summary>
        /// Saves each of its <see cref="Trackable"/> objects to an XML file.
        /// </summary>
        internal void SaveTrackables()
        {
            // TODO: Save each trackable into its own serialized xml file.
            throw new NotImplementedException();
        }

        #endregion
    }
}
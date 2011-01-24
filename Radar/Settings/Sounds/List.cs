using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;

namespace Radar.Settings.Sounds
{
    internal static class List
    {
        #region Constants

        private const string SOUND_DIRECTORY = @".\Settings\Sounds";

        #endregion

        #region Properties

        public static SoundPlayer Default { get; private set; }
        public static Dictionary<String, SoundPlayer> Sounds { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a new wav file to the available sounds for tracking.
        /// </summary>
        /// <param name="soundPath">Full path of the new sound.</param>
        public static void Add(string soundPath)
        {
            var newSound = new FileInfo(soundPath);

            if (!newSound.Exists || !newSound.Extension.Equals(".wav")) return;

            var name = newSound.Name;
            var index = 0;

            while (Sounds.ContainsKey(name))
            {
                name = string.Format("{0}_{1:D3}.wav", name.Remove(-4), index++);
            }

            newSound = newSound.CopyTo(string.Format("{0}\\{1}", SOUND_DIRECTORY, name));
            var sound = new SoundPlayer(newSound.FullName);
            sound.LoadAsync();

            Sounds.Add(name, sound);
        }

        /// <summary>
        /// Loads each of the sounds available for tracking use to memory.
        /// </summary>
        public static void Load()
        {
            // Only load if not yet loaded.
            if (Sounds != null)
                return;

            Sounds = new Dictionary<string, SoundPlayer>();

            var dir = new DirectoryInfo(SOUND_DIRECTORY);

            foreach (var fileInfo in dir.GetFiles("*.wav"))
            {
                var s = new SoundPlayer(fileInfo.FullName);
                s.LoadAsync();

                Sounds.Add(fileInfo.Name, s);
            }

            if (Sounds.Count > 0)
                Default = Sounds.First().Value;
        }

        #endregion
    }
}
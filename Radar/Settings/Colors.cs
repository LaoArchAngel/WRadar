using System;
using System.Drawing;

namespace Radar.Settings
{
    public static class Colors
    {
        #region Fields

        private static Color _gameObject = Color.OrangeRed;
        private static Color _pet = Color.Cyan;
        private static Color _petDead = Color.LightCyan;
        private static Color _playerDead = Color.PaleVioletRed;
        private static Color _playerMe = Color.Black;
        private static Color _playerOpposing = Color.DarkViolet;
        private static Color _playerSame = Color.GreenYellow;
        private static Color _radar = Color.LightGray;
        private static Color _target = Color.Red;   
        private static Color _targetDead = Color.Gold;
        private static Color _tracked = Color.WhiteSmoke;
        private static Color _unit = Color.Blue;
        private static Color _unitDead = Color.LightBlue;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the color to be applied to <see cref="Blips.WowGOBlip"/> controls.
        /// </summary>
        public static Color GameObject
        {
            get { return _gameObject; }
            set { _gameObject = value; }
        }

        public static Color Pet
        {
            get { return _pet; }
            set { _pet = value; }
        }

        public static Color PetDead
        {
            get { return _petDead; }
            set { _petDead = value; }
        }

        /// <summary>
        /// Gets or sets the color to be applied to <see cref="Blips.WowPlayerBlip"/> controls when the <see cref="BlackRain.Common.Objects.WowPlayer"/> is dead.
        /// </summary>
        public static Color PlayerDead
        {
            get { return _playerDead; }
            set { _playerDead = value; }
        }

        public static Color PlayerMe
        {
            get { return _playerMe; }
            set { _playerMe = value; }
        }

        public static Color PlayerOpposing
        {
            get { return _playerOpposing; }
            set { _playerOpposing = value; }
        }

        public static Color PlayerSame
        {
            get { return _playerSame; }
            set { _playerSame = value; }
        }

        public static Color Radar
        {
            get { return _radar; }
            set { _radar = value; }
        }

        public static Color RadarToClear
        {
            get { return Settings.Colors.Radar == Color.White ? Color.Black : Color.White; }
        }

        public static Color Target
        {
            get { return _target; }
            set { _target = value; }
        }

        public static Color TargetDead
        {
            get { return _targetDead; }
            set { _targetDead = value; }
        }

        public static Color Tracked
        {
            get { return _tracked; }
            set { _tracked = value; }
        }

        public static Color Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }

        public static Color UnitDead
        {
            get { return _unitDead; }
            set { _unitDead = value; }
        }

        #endregion
    }
}
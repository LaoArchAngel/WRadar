using System;
using System.Windows.Forms;
using RadarSettings = Radar.Settings;

namespace Radar.Utilities.Forms.Settings
{
	public partial class Colors : Form
	{
		#region Fields
		
		private static Colors _colorSettings = new Colors();
		
		#endregion
		
		#region	Properties
		
		public static Colors ColorSettings { get {return _colorSettings;} }
		
		#endregion
		
		#region Constructors

		public Colors()
		{
			InitializeComponent();
		}

		#endregion

		#region Event Handlers

		private void LoadColorDialog(object sender, EventArgs eventArgs)
		{
			var btn = sender as Button;

			if (btn == null) return;

			var colorDiag = new ColorDialog
			{
				AnyColor = true,
				SolidColorOnly = true
			};

			if (colorDiag.ShowDialog() != DialogResult.OK)
			{
				return;
			}

			if (btn == GoBtn) RadarSettings.Colors.GameObject = colorDiag.Color;
			if (btn == MeBtn) RadarSettings.Colors.PlayerMe = colorDiag.Color;
			if (btn == PetsBtn) RadarSettings.Colors.Pet = colorDiag.Color;
			if (btn == PetsDeadBtn) RadarSettings.Colors.PetDead = colorDiag.Color;
			if (btn == PlayersDeadBtn) RadarSettings.Colors.PlayerDead = colorDiag.Color;
			if (btn == PlayersOppBtn) RadarSettings.Colors.PlayerOpposing = colorDiag.Color;
			if (btn == PlayersSameBtn) RadarSettings.Colors.PlayerSame = colorDiag.Color;
			if (btn == RadarBtn) RadarSettings.Colors.Radar = colorDiag.Color;
			if (btn == TargetBtn) RadarSettings.Colors.Target = colorDiag.Color;
			if (btn == TargetDeadBtn) RadarSettings.Colors.TargetDead = colorDiag.Color;
			if (btn == UnitsBtn) RadarSettings.Colors.Unit = colorDiag.Color;
			if (btn == UnitsDeadBtn) RadarSettings.Colors.UnitDead = colorDiag.Color;

			btn.BackColor = colorDiag.Color;
		}

		#endregion
	}
}
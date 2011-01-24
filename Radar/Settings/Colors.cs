using System.Drawing;
using BlackRain.WowObjects;

namespace Radar.Settings
{
	public static class Colors
	{
		#region Properties

		/// <summary>
		/// Gets or sets the color to be applied to <see cref="Blips.WowGOBlip"/> controls.
		/// </summary>
		public static Color GameObject
		{
			get { return Properties.Colors.Default.GameObject; }
			set
			{
				Properties.Colors.Default.GameObject = value;
				Properties.Colors.Default.Save();
			}
		}

		public static Color Pet
		{
			get { return Properties.Colors.Default.Pet; }
			set
			{
				Properties.Colors.Default.Pet = value;
				Properties.Colors.Default.Save();
			}
		}

		public static Color PetDead
		{
			get { return Properties.Colors.Default.PetDead; }
			set
			{
				Properties.Colors.Default.PetDead = value;
				Properties.Colors.Default.Save();
			}
		}

		/// <summary>
		/// Gets or sets the color to be applied to <see cref="Blips.WowPlayerBlip"/> controls when the <see cref="WowPlayer"/> is dead.
		/// </summary>
		public static Color PlayerDead
		{
			get { return Properties.Colors.Default.PlayerDead; }
			set
			{
				Properties.Colors.Default.PlayerDead = value;
				Properties.Colors.Default.Save();
			}
		}

		public static Color PlayerMe
		{
			get { return Properties.Colors.Default.PlayerMe; }
			set
			{
				Properties.Colors.Default.PlayerMe = value;
				Properties.Colors.Default.Save();
			}
		}

		public static Color PlayerOpposing
		{
			get { return Properties.Colors.Default.PlayerOpposing; }
			set
			{
				Properties.Colors.Default.PlayerOpposing = value;
				Properties.Colors.Default.Save();
			}
		}

		public static Color PlayerSame
		{
			get { return Properties.Colors.Default.PlayerSame; }
			set
			{
				Properties.Colors.Default.PlayerSame = value;
				Properties.Colors.Default.Save();
			}
		}

		public static Color Radar
		{
			get { return Properties.Colors.Default.Radar; }
			set
			{
				Properties.Colors.Default.Radar = value;
				Properties.Colors.Default.Save();
			}
		}

		public static Color RadarToClear
		{
			get { return Radar == Color.White ? Color.Black : Color.White; }
		}

		public static Color Target
		{
			get { return Properties.Colors.Default.Target; }
			set
			{
				Properties.Colors.Default.Target = value;
				Properties.Colors.Default.Save();
			}
		}

		public static Color TargetDead
		{
			get { return Properties.Colors.Default.TargetDead; }
			set
			{
				Properties.Colors.Default.TargetDead = value;
				Properties.Colors.Default.Save();
			}
		}

		public static Color Unit
		{
			get { return Properties.Colors.Default.Unit; }
			set
			{
				Properties.Colors.Default.Unit = value;
				Properties.Colors.Default.Save();
			}
		}

		public static Color UnitDead
		{
			get { return Properties.Colors.Default.UnitDead; }
			set
			{
				Properties.Colors.Default.UnitDead = value;
				Properties.Colors.Default.Save();
			}
		}

		#endregion
	}
}
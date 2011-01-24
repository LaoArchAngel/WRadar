using System;
using System.Windows.Forms;

namespace Radar
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

            Settings.Sounds.List.Load();

			Application.Run(new Screen.Radar());
		}
	}
}

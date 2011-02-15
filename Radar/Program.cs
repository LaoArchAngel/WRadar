using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Radar
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.ThreadException += PrintError;
            AppDomain.CurrentDomain.UnhandledException += PrintError;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Utilities.Security.Log.Info("Initializing Sound Settings.");
            Settings.Sounds.List.Load();

            Utilities.Security.Log.Info("Loading Radar.");
            Application.Run(new Screen.Radar());
        }

        private static void PrintError(object sender, ThreadExceptionEventArgs args)
        {
        	Utilities.Security.Log.Error(args.Exception);
        }

        private static void PrintError(object sender, UnhandledExceptionEventArgs args)
        {
        	Utilities.Security.Log.Error((Exception)args.ExceptionObject);
        }
    }
}
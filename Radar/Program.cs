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

            Settings.Sounds.List.Load();
            Settings.Tracking.LoadTrackingLists();

            Application.Run(new Screen.Radar());
        }

        private static void PrintError(object sender, ThreadExceptionEventArgs args)
        {
            using (var writer = new StreamWriter("error.log", false))
            {
                writer.Write(args.Exception.ToString());
            }
        }

        private static void PrintError(object sender, UnhandledExceptionEventArgs args)
        {
            using (var writer = new StreamWriter("error.log", false))
            {
                writer.Write(args.ExceptionObject.ToString());
            }
        }
    }
}
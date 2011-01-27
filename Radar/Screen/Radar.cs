using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using BlackRain;
using BlackRain.WowObjects.Contracts;
using Radar.Blips;

namespace Radar.Screen
{
    public partial class Radar : Form
    {
        #region Fields

        private delegate void AddBlipCallback(DrawerResults results);

        #endregion

        #region Constructors

        public Radar()
        {
            InitializeComponent();
            ObjectManager.Pulsed += Pulsed;
        }

        #endregion

        #region Event Handlers

        internal void BlipDrawn(object sender, RunWorkerCompletedEventArgs completedEventArgs)
        {
            var results = completedEventArgs.Result as DrawerResults;

            if (results == null) return;

            //lock (results.Blip.BlipObject)
            //{
            if (results.Exists)
            {
                results.Blip.Location = results.Location;
                results.Blip.Refresh();
                return;
            }

            Controls.Add(results.Blip);

            if (results.Blip.BlipObject is INamed)
            {
                //tp.SetToolTip(results.Blip, ((INamed) results.Blip.BlipObject).Name);
            }

            if (results.Blip.BlipObject.IsMe)
            {
                results.Blip.BringToFront();
            }
            //}
        }

        private void Pulsed(bool success)
        {
            Action action = () => Utilities.Radar.RefreshScreen(this, tp);
            if (success)
                BeginInvoke(action);

            action = () => PulseTimer.Start();
            BeginInvoke(action);
        }

        #region Controls

        /// <summary>
        /// Loads a list of WoW instances whenever the context menu is loaded.
        /// </summary>
        /// <param name="sender"><see cref="RadarMenu"/></param>
        /// <param name="e">Arguments</param>
        private void LoadWowInstances(object sender, CancelEventArgs e)
        {
            wowInstances.DropDownItems.Clear();
            var processes = Process.GetProcessesByName("Wow");

            foreach (var menuItem in processes.Select(process => new ToolStripMenuItem
                                                                     {
                                                                         Name = String.Format("wow{0}", process.Id),
                                                                         Text = process.Id.ToString()
                                                                     }))
            {
                menuItem.Click += ProcessSelected;
                wowInstances.DropDownItems.Add(menuItem);
            }
        }

        /// <summary>
        /// Initializes our <see cref="ObjectManager"/> to the selected Wow instance.
        /// </summary>
        /// <param name="sender">A menu item under <see cref="wowInstances"/></param>
        /// <param name="e">Arguments</param>
        private static void ProcessSelected(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;

            if (menuItem == null) return;

            var id = Convert.ToInt32(menuItem.Text);
            var proc = Process.GetProcessById(id);

            if (ObjectManager.Me.BaseAddress == IntPtr.Zero)
            {
                ObjectManager.Initialize(proc);
            }
            else
            {
                ObjectManager.Reset(proc);
            }
        }

        /// <summary>
        /// Handles the tick even from <see cref="PulseTimer"/>
        /// </summary>
        /// <param name="sender"><see cref="PulseTimer"/></param>
        /// <param name="e">Arguments</param>
        private void PulseTick(object sender, EventArgs e)
        {
            if (!ObjectManager.Initialized)
            {
                return;
            }

            PulseTimer.Stop();
            var pulse = new Thread(ObjectManager.Pulse);

            pulse.Start();
        }

        #endregion

        private static void QuitRadar(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        private void LoadMenu(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.H:
                    Settings.Screen.HUDMode = !Settings.Screen.HUDMode;
                    BackgroundImage = Utilities.Radar.ScreenImage(Settings.Screen.Zoom);
                    break;
                case Keys.Q:
                    if (e.Control) QuitRadar(null, EventArgs.Empty);
                    break;
                case Keys.T:
                    Utilities.Tracking.ListEditor.ShowDialog();
                    break;
                case Keys.X:
                    Settings.Screen.Exclusive = !Settings.Screen.Exclusive;
                    break;
            }
        }
    }
}
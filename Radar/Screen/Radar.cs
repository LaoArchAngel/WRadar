﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BlackRain.Common.Objects;

namespace Radar.Screen
{
    public partial class Radar : Form
    {
        #region Fields

        #endregion

        #region Constructors

        public Radar()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

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

            foreach (var process in processes)
            {
                var menuItem = new ToolStripMenuItem
                                   {
                                       Name = String.Format("wow{0}", process.Id),
                                       Text = process.Id.ToString()
                                   };

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

            if (ObjectManager.Initialized)
                ObjectManager.Reset(id);
            else
                ObjectManager.Initialize(id);
        }

        /// <summary>
        /// Handles the tick even from <see cref="PulseTimer"/>
        /// </summary>
        /// <param name="sender"><see cref="PulseTimer"/></param>
        /// <param name="e">Arguments</param>
        private void PulseTick(object sender, EventArgs e)
        {
            PulseTimer.Stop();
            Utilities.Radar.RefreshScreen(this, tp);
            PulseTimer.Start();
        }

        #endregion

        private static void QuitRadar(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion
    }
}